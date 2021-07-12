+++
title = "Sublime Text: Fashion and Form Text Editing"
date = "2012-02-23T19:58:00Z"
categories = ["Code"]
tags = ["Sublime"]
draft = false
+++

I have an odd love of text editors, though considering I love to code perhaps it's not that odd at all.  I've gone through quite a few over the years, I was a huge [TextPad](http://www.textpad.com/) fan for a long time and I still pull it up now and then but then I saw a bunch of screen shots of [TextMate](http://macromates.com/) on Mac and realized the bar had been reset.  From there I was on a search for an editor that was both smart AND sexy and I went through a bunch of editors looking for "the right one", from [E Text Editor](http://www.e-texteditor.com/) (nice but made me install cygwin for full power) to [Intype](http://inotai.com/intype/) (beautiful and had a great start but languished for a year though I hear they're working again in earnest) and finally to [Sublime Text 2](http://www.sublimetext.com/) which is what this post is all about.

I've been using Sublime for about a year, since roughly Build 2020 of Subliime Text 2 and the project just keeps getting better and better.  I highly recommend you grab the [development builds](http://www.sublimetext.com/2) and install the latest as they come down the pipe.  Sublime is even nice enough to let you know when there are new builds available.

![Sublime Text Main](/images/SublimeTextMain.png "Sublime Text Main")

## Why Use Anything Besides Visual Studio?

Why indeed since I sling a lot of C# during my day?  First is the **speed**, VS does a lot for you and sometimes you pay that cost and when I just want to work with text I reach for Sublime.

**Snippet support**.  It's super fast to create new snippets as well as build in some intelligence via regex.  It's probably just me but creating new snippets in VS always seems like a heavy process but it's so easy with Sublime I find myself creating them for any block code more than two lines long.  I have one cool snippet for creating new properties with a backing private variable and it takes care of creating both the public and private variables and correctly casing each one, something I don't believe you can do in VS.

**Multiple Selection**. This is a must have for any modern editor and it's best if you see it in action but roughly if you Ctrl select multiple words and then start typing all of the selected items will start updating.  Great for quickly changing types such swapping from a Grid to StackPanel in XAML.

**Auto-Complete.** You won't lose any of your fancy auto-complete either, Sublime uses the current syntax bundle to parse your files and determine what should be considered key words.

**Jump To.** Ctrl+P to jump to any file in your project. Ctrl+, to jump to any symbol. Ctrl+Shift+P to look at all available commands and snippets.  Awesome and super fast.

**Project Management.** Drag & drop a folder into Sublime and now all your jump to features become much more powerful as you can move between files in your project.

**And so much more.**  Seriously. Support for TextMate bundles, great color themes, code-folding, macro support, margin guides, a ton of extensibility, active forums, weekly updates, etc.

## Pro-Tips & Downloads

1. Keep your Sublime configuration in sync between computers with DropBox (see [Using Dropbox to sync Sublime Text settings across Windows computers](http://juhap.iki.fi/misc/using-dropbox-to-sync-sublime-text-settings-across-windows-computers/)).

2. If you use VS don't forget to setup Sublime as an External Tool.  I'm constantly moving between VS & Sublime and since both programs are great about picking up changes this is a great combo.

3. Install [Sublime Package Control](http://wbond.net/sublime_packages/package_control).  Think of it as gems or NuGet for Sublime.  After you install it browse some of the cool packages available.  My current favs are:

    * Sublime TFS - check out, commit & via history for files under TFS control.
    * sublime-github - A great list of commands for managing your Gists from Github.
    * SublimeAStyleFormatter - A pretty code formatter for C#.
    * Theme - Soda -  A nice dark theme for the entire editor itself.

4. Check out what others are saying ([Rob Conery](http://wekeroad.com/2012/01/13/sublime-text-the-text-editor-youll-fall-in-love-with-3/))

5. Check out this great list of pro-tips ([Sublime Text 2 Tips and Tricks (Updated)](http://net.tutsplus.com/tutorials/tools-and-tips/sublime-text-2-tips-and-tricks/))

6. If you edit in XAML here is a XAML bundle I ported (it's basically a copy of the XML bundle and a porting of some of the TextMate snippets from the [Microsoft Gestalt project](http://visitmix.com/labs/gestalt/)).

    * [XAML Sublime Bundle](/downloads/XAML.zip)
