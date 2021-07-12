+++
title = "Using XP-style, 32-bit png's as icons in Delphi"
date = "2007-05-11T07:39:00Z"
categories = ["Code"]
tags = ["Delphi", "UI"]
draft = false
+++

There are some pretty great looking icons out there, with lovely drop shadows and alpha-blending, problem is they look pretty bad in Delphi since it doesn't fully support them. Below is how I use XP-style, 32-bit png images as icons inside my Delphi applications.

## Create a resource file

1. Get your image into an .ico format. I use [icon sushi](http://www.towofu.net/soft/e-aicon.php "@icon sushi") to convert png images into icos.
2. Create a new text file, save it as icons.rc (you can call it whatever you want).
3. Edit the file and for each icon create an icon resource entry, like this:

   ```res
   icon_edit    ICON    "edit.ico"
   ```

   - _icon\_edit_ is the name of the resource, this is how you'll refer to it in code when you load it.
   - _ICON_ is the type of resource, in this case... well, you get it.
   - _"edit.ico"_ is the name of the icon file and it can include a path. A common pattern I use is to put all my icons in a folder, imaginatively named "icons" and then I include them like this:

   ```res
   icon_edit    ICON    ".iconsedit.ico"icon_copy    ICON    ".iconseditcopy.ico"icon_paste   ICON    ".iconseditpaste.ico"
   ```

4. Compile the resource script into a resource file. I use Borland's Resource Compiler, brcc32. To make it so I don't have to drop down to DOS all the time I create a little batch file that I can double-click. It looks like this:

   ```res
   brcc32 icons.rc
   ```

5. Ie the resource file in your project. You can include a resource in any of your unit files but I prefer to include it in the unit from where I'll be using it, such as the main form or a datamodule. Include it like this:

   ```res
   {$R icons.res}
   ```

## Prepare your Form

1. Add a `TImageList` to your form. Change the `Width` & `Height` properties to match the size of the icons you want to load (32x32 for example).
1. Load this file: [uXPIcons.zip](/downloads/uXPIcons.zip). It has routines that will enable your `TImageList` to support 32-bit XP style icons. I can't take any credit for these routines. I found them on someone elses site describing the exact same thing I am but I can't find it anymore.
1. Unzip and add the uXPIcons.pas unit to your project.
1. Create a new procedure called `InitializeImageList()` or some other fun name.
1. Add the following code to your new procedure:

    ```delphi
    ConvertTo32BitImageList(ImageList1);AddIconResourceToImageList('icon_edit', ImageList1);AddIconResourceToImageList('icon_copy', ImageList1);
    ```

1. `AddIconResourceToImageList` returns an integer which is the index of the icon just added, which can be used to set the `GlyphIndex` for any control that takes both an `ImageList` and a `GlyphIndex`
1. Call `InitializeImageList()` from your `FormCreate()`.
1. Run it and rock.

You'll notice is that now your main application icon has been replaced by the first icon in your resource file. My suggestion is to just make sure your application icon is first in your resource file. It actually works better for me since I often have to create versions of my applications with different main icons and being able to swap them out via different resource files using a build script is much easier.
