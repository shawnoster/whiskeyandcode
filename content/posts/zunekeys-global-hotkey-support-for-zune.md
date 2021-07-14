+++
title = "ZuneKeys: Global Hotkey Support for Zune"
description = "Global hotkey support for the Zune software, similar to Winamp"
date = "2007-07-15"
categories = ["Code"]
tags = ["Zune", "Delphi", "Winamp"]
draft = false
+++

Before Zune I used [Winamp](https://winamp.com/) and one of the things I really liked was it's global hotkey support, the ability to control the player using just hotkeys. Ever since using the Zune I've found myself hitting `Ctrl + Alt + Home` to pause the player about a 100 times so instead of whining about it in yet another blog post I thought I'd actually do something. It was a slow afternoon on a Friday so I whipped up this, [ZuneKeys](/downloads/ZuneKeys.zip), global hotkey support for the Zune software.

## Install

1. [Download ZuneKeys](/downloads/ZuneKeys.zip)
2. Unzip and copy somewhere, personally I use `C:\Program Files\ZuneKeys`
3. Run ZuneKeys.exe...
4. ...and Bob's yer uncle! Now you have global hotkey support for your Zune software.  

I'd suggest adding ZuneKeys to your startup menu so it's always available.

## The Keys

Action          | Shortcut
----------------|-----------------------
Play            | Ctrl + Alt + Insert
Pause           | Ctrl + Alt + Home
Stop            | Ctrl + Alt + End
Previous Track  | Ctrl + Alt + Page Up
Next Track      | Ctrl + Alt + Page Down
Volume Up       | Ctrl + Alt + Up
Volume Down     | Ctrl + Alt + Down
Fast Forward    | Ctrl + Alt + Right
Rewind          | Ctrl + Alt + Left

## How it Works

I'm basically sending the same commands that your fancy media keyboards sends, except I don't use media keyboards as they take up entirely too much space on my already cramped desk. Nothing too magically here. I'm pretty sure the Winamp one actually sends Winamp messages that it knows how to respond to but since the Zune software doesn't have anything like that I'm faking it.

There is no customization of hotkeys and it could probably do a lot more but I wanted to keep it as tiny as possible since I already seem to have a 100 other things running in the background trying to compete for my system's resources. If someone besides me actually uses this puppy I'm sure I could accommodate customized keys or other small enhancements.

This works with the Zune right now because that's where I needed it but it could easily be adapted to work for Windows Media Player, iTunes, Winamp, etc.

Oh, it seems to work just fine under Vista and XP.

## The (Open) Source

It's written in [Delphi](http://www.codegear.com/products/delphi/win32) as a standard Win32 application. Since it's Delphi that means the only thing you need is the EXE, no .NET or Java Virtual Machine needed here. Since I avoided using the VCL and went old-school Windows app it's only 30.5kb instead of the more usual 300kb Delphi app. If you'd like the source just ask, I'll put it some place public or give you access to my subversion repository. A special thanks to [IconBuffet](http://www.iconbuffet.com/) as the icon I'm using is from one of their "Free Delivery" icon sets, Dresden Symphony.

[ZuneKeys source on Github](https://github.com/shawnoster/ZuneKeys)

**UPDATED:** Some people noticed that the source zip was missing ZuneKeys.inc. Sorry for not having it there the first time. I've updated the download with all the files I have in my source folder. I'll probably be moving this to Github or CodePlex so it's more formally hosted and people can share their work.
