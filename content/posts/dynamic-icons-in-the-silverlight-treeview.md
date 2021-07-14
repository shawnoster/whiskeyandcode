+++
title = "Dynamic Icons in the Silverlight TreeView"
date = "2008-11-07T00:35:00Z"
categories = ["Code"]
tags = ["Silverlight", "Microsoft"]
draft = false
+++

A common question in the [forums](http://silverlight.net/forums/35.aspx) has been how to get dynamic icons in the [Silverlight Toolkit](http://www.codeplex.com/Silverlight) TreeView and luckily there are quite a few options.

## The Icon

Before you can make the icon dynamic you need a place to put it. The basic idea is to create a HierarchicalDataTemplate and make room for an image:

```xml
<stackpanel.resources>
    <controls:hierarchicaldatatemplate
        x:key="TaxonomyTemplate"
        itemssource="{Binding Subclasses}">
        <stackpanel orientation="Horizontal">
            <contentpresenter margin="0 0 4 0" content="???" />
            <textblock text="{Binding Classification}" />
        </stackpanel>
    </controls:hierarchicaldatatemplate>
</stackpanel.resources>

<controls:treeview
    x:name="MasterTree"
    itemtemplate="{StaticResource TaxonomyTemplate}" />
```

I've added a ContentPresenter and the Content is what we're interested in setting dynamically.

## Option #1 - The Fixed Template

If you have a rigidly defined hierarchy where you know the exact icon you want at each level you're in luck, there is already a sample showing how to do just that in the NestedHierarchicalDataTemplate scenario, using three separate HierarchicalDataTemplates, one for each level. This has the advantage of being easy for your designers to style the icons independent of the code, the obvious downside is it's a fixed structure.

## Option #2 - Binding to a Property

Another option is to add an Icon property to your object and bind the Content directly to it, like this:

```xml
<contentpresenter margin="0 0 4 0" content="{Binding Icon}" />
```

In your descendent classes you can override the Icon property and return the appropriate image for that class. You can even go further and return different images based on state, such as availability, status, quantity, etc.

Object model purists may be frothing at the mouth, since I dared put UI information into my objects, and in some scenarios I'd completely agree but what we're doing here is creating UI model objects, not business model objects. It's a common pattern and has the great benefit of making your UI testable from inside unit tests instead of having to rely solely on UI macro recorder/playback frameworks. I go so far as to recommend that if you're doing a lot with states like icons, if something checked, multi-selection, color-coding, etc. that you create objects that sit between your business object and the actual UI elements.

Anytime you find yourself trying to get directly at a control to set/check state ask yourself if there is something you could be binding to instead.

## Option #3 - The ValueConverter

If you're binding directly to business objects or really don't like the idea of adding an Icon property to your objects (you know who you are) then you can take all that logic and roll it up into a value converter. IValueConverters are these great things that convert between two different types of values (I know, shocking). A classic example is [converting between a boolean and the Visibility enum](http://www.jeff.wilcox.name/2008/07/13/visibility-type-converter/). We're going to apply the same concept but this time convert between a type (our business object) and an icon.

First, we need a ValueConverter, what I'm calling the IconConverter:

```csharp
public class IconConverter : IValueConverter
{
    public object Convert(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        if (value is Domain)
        {
            // return icon for Domain
        }

        if (value is Family)
        {
            // return icon for Family
        }

        if (value is Genus)
        {
            // return icon for Genus
        }

        return null;
    }

    public object ConvertBack(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```

Next, add it as a resource in your application so you can use it in your XAML (you will probably also need to add your project's namespace to the XAML, that is where &ldquo;local&rdquo; comes from in my sample):

```xml
<usercontrol.resources>
    <local:iconconverter x:key="IconConverter" />
</usercontrol.resources>
```

Last, set the binding on the content presenter so it knows to use the converter when trying to determine the icon:

```xml
<controls:hierarchicaldatatemplate
    x:key="TaxonomyTemplate"
    itemssource="{Binding Subclasses}">
    <stackpanel orientation="Horizontal">
        <contentpresenter
            margin="0 0 4 0"
            content="{Binding Converter={StaticResource IconConverter}}" />
        <textblock text="{Binding Classification}" />
    </stackpanel>
</controls:hierarchicaldatatemplate>
```

This technique has the advantage of centralizing everything as well as being usable on any type of object you're using in your TreeView, whether they all descend from a common base-type or not and if you put it in the application's resources you can use it throughout your application. It is also still very testable from a unit test, which is always a plus.

The downside is that the **is** operator is expensive in terms of performance so if you have a lot of different classes you're checking against, with a lot of items in the tree you may hit some perf issues. This can be mitigated by keying off of other data that may be unique to your class-hierarchy.

## DataType

The WPF crowd is probably jumping up and down saying, "But wait, wait, what about DataTarget?!" In WPF one way you'd handle dynamic icons is to create a HierarchialDataTemplate per class you wanted to style and set its DataType property so when that Type appeared in the TreeView it would get its custom style. It works great and is a tasty way to handle these situations but alas it's not supported in Silverlight. Personally I actually prefer option #2 and #3 if all you're doing is changing icons.

## Limitless Options

For every option I've proposed here there are probably a dozen others based on your specific needs, business objects and user interface. If you come up with a great solution or have a situation that you don't feel is covered here then please either leave a comment or visit us in the [forums](http://silverlight.net/forums/35.aspx).
