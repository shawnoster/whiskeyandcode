+++
title = "C# and Sublime Text 2 PROTIPS"
date = "2012-05-09T07:26:14Z"
categories = ["Code"]
tags = ["C#", "Sublime"]
draft = false
+++

Given how powerful, fast and easy [Sublime Text 2](http://www.sublimetext.com/blog/articles/sublime-text-2-beta) is I find myself editing a great deal of my C# & XAML code in it and then switching to Visual Studio to launch the application. Along those lines I've picked up a few C# Sublime tips.

## 1. Update Your C# Bundle

The syntax and snippet bundle that comes with Sublime is a bit out of date and more importantly it doesn't correctly identify methods so you are missing a huge chunk of the power of the Ctrl+R "jump to method" hotkey. Grab an [updated bundle](https://github.com/wintermi/csharp-tmbundle) over on GitHub.

This is a TextMate bundle so you'll need to do some slicing and dicing to get it to play nicely with Sublime, most notably move the files in the Syntax and Preferences folders into the root of the C# package. If you need more details than that just hit me up and I'll add the step-by-step.

## 2. Add msbuild as a Build System

I do a build sometimes as a quick and dirty syntax & sanity check and it's nice to be able to trigger it from Sublime vs. having to swap back to VS. I whipped this up and dropped it into my `/Sublime Text 2/Packages/User` folder as `msbuild.sublime-build`.

```json
{
    "cmd": ["msbuild"],
    "path": "C:\\Windows\\Microsoft.NET\\Framework\\v4.0.30319",
    "working_dir": "${project_path:${folder}}",
    "file_regex": "^  (.*)\\(([0-9]*),([0-9]*)"
}
```

F7 to compile, F4 to jump to each compiler error (I know, I know, you don't have bugs but that other coder...).

I'm using a hard-coded msbuild location, that's stinky and a better solution would be to use environment variables and such but... Works On My Two Machines That Are Sync'd With Dropbox.

If you have a Sublime project open (which is really a collection folders that act as a scope for searches, I resisted them foreva but am now an addict) this will call msbuild at the project root, otherwise it'll look in the same folder as the file you're editing.

## 3. Create Some Snippets

Visual Studio 2010 ships with some awesome and must-have C# snippets. I haven't tried to recreate them all in Sublime (I really do like VS you know) but there are some tricks Sublime can do that Visual Studio just can't. One nice one is being able to whip up some regex magic on replacements which comes in handy for things like changing the casing between private and public variables. An example will work better:

```xml
<snippet>
    <tabTrigger>propc</tabTrigger>
    <content><![CDATA[
private ${1:string} _${2};
public ${1} ${2/./\u$0/}
{
    get
    {
        return _${2};
    }
    set
    {
        if (_${2} != value)
        {
            _${2} = value;
            OnPropertyChanged("${2/./\u$0/}");
        }
    }
}
]]></content>
    <scope>source.cs</scope>
    <description>Property that raises PropertyChanged</description>
</snippet>
```

Also VS doesn't support XAML snippets and that about makes me cry every time I have to type yet another angle bracket so go ahead and create some tasty XAML snippets. I dropped a few [into a zip here](/downloads/XAML.zip).

Have any other protips for working with C# or XAML inside of Sublime? I'd love to hear them and if you have any questions about my workflow don't be shy.
