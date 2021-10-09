---
title: Adding Silverlight Toolkit Controls to the Visual Studio and Blend Toolbox
date: "2009-02-04"
categories:
- Silverlight
draft: false
---

Now that title is a mouth-full. I've seen a few questions in the [Silverlight.net forums](http://silverlight.net/forums/35.aspx) asking how to get the [Silverlight Toolkit](http://www.codeplex.com/Silverlight) controls into the toolbox/asset library of Visual Studio 2008 and/or [Expression Blend 2](http://www.microsoft.com/expression/products/Overview.aspx?key=blend). There are a bunch of great posts scattered among the tubes on how to do this but I wanted to explain both Visual Studio 2008 and Blend 2 in one post. Plus it'll segue nicely into an upcoming post :)

## Download the Silverlight Toolkit

1. Download the latest release of the [Silverlight Toolkit](http://www.codeplex.com/Silverlight/Release/ProjectReleases.aspx?ReleaseId=19172) (December 2008 as of this post).
2. Unzip to a folder of your liking (I use the highly imaginative `C:\Source\Silverlight Toolkit December 2008`).

## Adding to the Visual Studio 2008 Toolbox

You can add the controls to any tab in the Toolbox you like, for this example I'm going to create a new tab, Silverlight Toolkit.

1. Right-click anywhere in the Toolbox and select **Add Tab**, name it Silverlight Toolkit.
2. Right-click in the empty space of the Silverlight Toolkit group and select **Choose Items**.
3. Select the Silverlight Components tab.
4. Click Browse and browse to Binaries folder, adding `Microsoft.Windows.Controls`, `Microsoft.Windows.Controls.Input` and `Microsoft.Windows.Controls.DataVisualization`.
5. The controls will now appear in your Toolbox.

![Silverlight Toolkit controls in Visual Studio 2008 toolbox](/images/Silverlight%20Toolkit%20controls%20in%20Visual%20Studio%202008%20Toolbox.png "Silverlight Toolkit controls in Visual Studio 2008 toolbox")

## Adding to Expression Blend 2 Asset Library

Adding controls to Blend is even easier, though you do have to repeat this process for each new project. Also because making controls available in Blend requires you to add references to your project, thus increasing your download size, you should only add references to the assemblies you need. Bit of a chicken and egg issue. To help you decide which assemblies to add I included a breakdown of which controls are in what assembly after these instructions.

1. In your Project pane right-click on References, select Add Reference&hellip;.
2. Add references to Microsoft.Windows.Controls, Microsoft.Windows.Controls.DataVisualization, Microsoft.Windows.Controls.Input.

   ![Blend 2 Project Pane](/images/Blend%20Project%20Pane.PNG "Blend 2 Project Pane")

3. The controls will now appear in the Custom Controls section of the Asset Library.

![Blend 2 Asset Library](/images/Blend%202%20Asset%20Library.PNG "Blend 2 Asset Library")

## What's In Each Assembly?

`Microsoft.Windows.Controls`

* AutoCompleteBox
* DockPanel
* Expander
* HeaderedContentControl
* HeaderedItemsControls
* Label
* TreeView
* TreeViewItem
* Viewbox
* WrapPanel

`Microsoft.Windows.Controls.Input`

* ButtonSpinner
* NumericUpDown

`Microsoft.Windows.Controls.DataVisualization`

* Charting (with associated Axis, DataPoint and Series).

## Getting Support, Offering Feedback

As always the best place to get support for the Silverlight Toolkit is to post in [our forum on Silverlight.net](http://silverlight.net/forums/35.aspx). If you have a feature request or bug please file it in our [Issue Tracker](http://www.codeplex.com/Silverlight/WorkItem/List.aspx) and get some votes behind it. We look carefully at those numbers when we decide how to prioritize the bug fixes.

(Updated to include warning about adding assemblies you don't need in Blend and what controls are in each assembly, plus fixed the title tag on a few images)
