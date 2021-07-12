+++
title = "Windows Phone Toolkit - September 2012 Release"
date = "2012-10-15T01:47:49Z"
categories = ["Code"]
tags = ["Microsoft", "Windows Phone", "Silverlight"]
draft = false
+++

A few astute people ([@Patric68](http://twitter.com/Patric68),&nbsp; [@scottisafool](http://twitter.com/scottisafool)) have noticed that we pushed out the [September 2012 release of the Windows Phone Toolkit](http://silverlight.codeplex.com/releases/view/94435).&nbsp; This was a soft launch, quietly pushed out because we've been going like crazy with bug fixes, prepping for [Build](http://www.buildwindows.com/) and doing a whole host of things and I really wanted to get a build out that had the latest fixes and improvements without blocking on all the paperwork. That's agile baby!

## What's New

## Branding

It's now just the "Windows Phone Toolkit".&nbsp; Honestly "Silverlight for Windows Phone Toolkit" was too much of a mouthful and new developers targeting Windows Phone often don't know of the Silverlight underpinnings.&nbsp; We're slowly transitioning all branding in the source to the shorter version.

## CustomMessageBox

![Sample CustomMessageBox Image](/images/SampleMessageBox.png "CustomMessageBox")

CustomMessageBox is a new control that makes it easy to create, well, custom message boxes that look and feel just like the default ones on the phone.&nbsp; I did a little write-up of it last week in my blog post, "[Welcome CustomMessageBox to the Windows Phone Toolkit](/posts/welcome-custommessagebox-to-the-windows-phone-toolkit/)".

## Rating

![Sample Rating Control Image](/images/SampleRatingControl.png "Rating")

Rating is another new control that does exactly what it says, provides a rating control that matches the Windows Phone UI.&nbsp; Expect a blog post on using it soon but it as always you can see it in action by downloading the sample application from [CodePlex](http://silverlight.codeplex.com).

## Transition Effects

There are new transition effects that make it even easier to match the Windows Phone UX.

* SlideInEffect - Ever notice when you're in a Pivot or Panorama on the phone in one of the native experiences , say the People Hub, how the items in a list slide in on a separate animation as you swipe back and forth?&nbsp; It's subtle but adds a nice level of polish to the whole experience and now it's super easy to add to your application as well.&nbsp; There is a new attached property, toolkit:SlideInEffect that you set on each item in your DataTemplate that controls the order in which elements slide in:

```xml
<DataTemplate>
    <StackPanel Margin="0,0,0,17" Width="432">
        <TextBlock Text="{Binding LineOne}"
                   TextWrapping="Wrap"
                   Style="{StaticResource PhoneTextExtraLargeStyle}"/>
        <TextBlock Text="{Binding LineTwo}"
                   TextWrapping="Wrap"
                   Margin="12,-6,12,0"
                   Style="{StaticResource PhoneTextAccentStyle}"
                   toolkit:SlideInEffect.LineIndex="1"/>
        <TextBlock Text="{Binding LineTwo}"
                   TextWrapping="Wrap"
                   Margin="12,-6,12,0"
                   Style="{StaticResource PhoneTextSubtleStyle}"
                   toolkit:SlideInEffect.LineIndex="2"/>
    </StackPanel>
</DataTemplate>
```

* FeatherTransition - Another common effect seen on Windows Phone is a "feathering" in of the controls on a page such as when you launch the mail app.&nbsp; Notice how the items on the page feather in from top to bottom.

```xml
<!--TitlePanel-->
<StackPanel Grid.Row="0" Margin="12,17,0,28">
    <TextBlock Text="{StaticResource ApplicationTitle}" 
                Style="{StaticResource PhoneTextNormalStyle}"
                toolkit:TurnstileFeatherEffect.FeatheringIndex="0"/>
    <TextBlock Text="turnstilefeathereffect" 
                Margin="9,-7,0,0" 
                Style="{StaticResource PhoneTextTitle1Style}"
                toolkit:TurnstileFeatherEffect.FeatheringIndex="1"/>
</StackPanel>
```

## Distribution / Installation

We've taken a new approach to distribution this time and gone "all-in" on [NuGet](http://nuget.org) as the official way to [install the toolkit](http://nuget.org/packages/SilverlightToolkitWP).&nbsp; We'll no longer be supporting an MSI-based installer as it's not very maintainable or discoverable.&nbsp; NuGet is built into Visual Studio 2012 and is fast becoming the de-facto standard for installing packages and if you haven't already installed the plug-in for Visual Studio 2010 I highly recommend it.

As always you can still either download the source as a zip or from the source control on CodePlex and compiling the assembly yourself.

## Bug Fixes

No release is complete without bug fixes and we have roughly 25 of the top user voted bugs fixed in this release.

## Feedback

As always we love feedback, bug reports, creative uses and ideas.&nbsp; We have more plans for the toolkit in the near future as well so stay tuned!
