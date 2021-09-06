---
title: "A Distiller Knock-Off"
date: 2006-09-23
categories: ["Code"]
tags: ["Delphi"]
draft: false
---

One of the software projects I work on involves printing color-coded, barcoded labels. Yes, exactly, the height of fun. Often I need to validate that a code change I just made hasn't completely messed up the rendering engine. Because resolution is a huge issue in things like barcodes I need to actually print through a printer driver vs. just doing a screen preview. Being a good recycling citizen I hate wasting paper, hence where Adobe's Acrobat Distiller and my cheap ass nature come into the picture. I like the concept of Distiller, I don't like paying for it.

So, I took a bunch of freely available tools, namely [GhostScript](http://www.cs.wisc.edu/~ghost/), [RedMon](http://www.cs.wisc.edu/~ghost/redmon/), and a Xerox DocuColor40 printer driver and rolled them into a [simple NSIS install](http://nsis.sourceforge.net/Main_Page) to create a Distiller Knock-Off. I did have to write a small [Win32 Delphi](http://www.turboexplorer.com/) application to do a little file management between RedMon and GhostScript but all it really does is shuffle files between the temp folder. I picked a DocuColor40 simply because I wanted the option to print to a 11x17 sheet of paper and I needed a PostScript driver.

You can get it here: [Distiller-KO](/downloads/Distiller-KO.exe)
