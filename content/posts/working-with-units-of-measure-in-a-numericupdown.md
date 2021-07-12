+++
title = "Working with Units of Measure in a NumericUpDown"
date = "2008-12-11T12:10:00Z"
categories = ["Code"]
tags = ["Silverlight", "Microsoft"]
draft = false
+++

One of the great controls released with the [Silverlight Toolkit](http://www.codeplex.com/Silverlight) is the NumericUpDown. Sure it may seem like just a basic textbox that allows user input with the added glory of a spinner that makes it easy to nudge values up or down with a click, which in and of itself is a great benefit, but there is also some lesser known plumbing that allows users to easily extend this control to provide some great user experiences.

One of my favorite user experiences is the way the UpDowns, or spinners as some call them, work in Microsoft Word when you're adjusting your margins. The first great thing is that you see a suffix indicating your current unit of measure. The second, and cooler, thing is if your default measurement unit is inches and you type 10mm it'll automatically convert 10 millimeters into inches for you, which I think is brilliant especially considering how often UpDowns are used to represent measurements.

[![image](/images/CreatingaMeasurementUpDownfromaNumericUp_image_8_thumb.png "image")](/images/CreatingaMeasurementUpDownfromaNumericUp_image_8.png)

Using two handy virtuals in NumericUpDown, FormatValue and ParseValue, the same functionality can be created in Silverlight. I show you how to get started and leave the monkey work of length conversion to you :)

## Step 1: Reference the Silverlight Toolkit

The first step is to download the [Silverlight Toolkit](http://www.codeplex.com/Silverlight) if you haven't already, unzip it, create a new Silverlight Application project (I called mine PageLayout because I was inspired by the Page Layout section in Word) and add a reference to Microsoft.Windows.Controls.Input.

[![Microsoft.Windows.Controls.Input Reference](/images/CreatingaMeasurementUpDownfromaNumericUp_2_thumb.png "Microsoft.Windows.Controls.Input Reference")](/images/CreatingaMeasurementUpDownfromaNumericUp_2.png)

## Step 2: Create The LengthUpDown Class

Do the usual right-click Add Class dance and name it LengthUpDown.cs. We want to descend LengthUpDown from NumericUpDown so add a using statement referencing the toolkit namespace: Microsoft.Windows.Controls. At this point you should have:

```csharp
using Microsoft.Windows.Controls;

namespace PageLayout
{
    public class LengthUpDown : NumericUpDown
    {

    }
}
```

## Step 3: FormatValue & ParseValue

So far everything has been prep, let's do something interesting. UpDownBase, the class NumericUpDown base derives from, exposes two useful virtual methods: FormatValue and ParseValue.

FormatValue is responsible for formatting the actual Value as a string for the user. It is purely for display purposes so you can format it however you like. You could return the word &ldquo;three&rdquo; for the value 3 or in our case append a suffix representing the current measurement unit, such as &ldquo;mm&rdquo;.

ParseValue goes the other direction, it takes the user-entered string and converts it back to a double. This is where you could for example take the word &ldquo;three&rdquo; and convert it to 3 or in our case scan the string to see if there is a unit suffix such as mm, cm, pt or px and do the appropriate conversion before returning the value.

The basic skeleton for our LengthUpDown starts something like this:

```csharp
using System;
using Microsoft.Windows.Controls;

namespace PageLayout
{
    public class LengthUpDown : NumericUpDown
    {
        ///
        /// Formats the value for display in the control.
        ///
        protected override string FormatValue()
        {
            string suffix = DetermineMeasurementSuffix();
            return base.FormatValue() + suffix;
        }

        private string DetermineMeasurementSuffix()
        {
            throw new NotImplementedException();
        }

        ///
        /// Parses the value the user entered and converts it to the
        /// correct value.
        ///
        protected override double ParseValue(string text)
        {
            double length = ConvertLength(text);
            return length;
        }

        private double ConvertLength(string text)
        {
            throw new NotImplementedException();
        }
    }
}
```

## Step 4: Length Conversion

In an effort not to introduce too many concepts at once and to keep the code samples short I've omitted all the actual conversion logic. In the next few days I'll post a fully working version that converts between common units of linear measure. If you're bored or ambitious go ahead and implement them, they're fairly easy for a limited number of measurement units. Here is a little peak at a fun little fluent-interface conversion class that I created (and that will be included in the upcoming project):

```csharp
if (suffix != String.Empty)
{
    LengthUnit fromUnit = SuffixToLengthUnit(suffix);
    return new ConvertLength(length).From(fromUnit).To(DefaultLengthUnit);
}
```

## Step 5: Using It

Once you've implemented your conversion logic, hopefully in another class to maximize unit testing, then you'll want to actually use your new control. For my example I created the control directly in the project so it's easy to get it rocking in the application.

Open the page.xaml and add the project's namespace to the XAML so you can use your new control and plop down an instance of it, leaving you with:

```xml
<UserControl x:Class="PageLayout.Page"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="clr-namespace:PageLayout"
    Width="400" Height="300">

    <Grid x:Name="LayoutRoot" Background="White">
        <local:LengthUpDown Value="10" />
    </Grid>
</UserControl>
```

Run the project and you should see a LengthUpDown looking control in the middle of the page.

## Step 6: The Next Step

As I mentioned I'll be posting a more completely control in the coming days but for now you have everything you need to add custom prefixes and suffixes to numeric values in your UpDown controls.
