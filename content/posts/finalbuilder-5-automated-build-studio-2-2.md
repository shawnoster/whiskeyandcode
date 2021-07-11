+++
title = "FinalBuilder 5 & Automated Build Studio 2.2"
date = "2006-11-30"
categories = ["Code"]
draft = false
+++

A few review notes, comparing two popular automated build tools, [FinalBuilder 5.0](http://www.finalbuilder.com/finalbuilder.aspx "FinalBuilder 5.0 Home Page") and [Automated Build Studio 2.2](http://www.automatedqa.com/products/abs/index.asp "Automated Build Studio Home Page"). These are just notes I'm making as I try and port an old [WANT](http://sourceforge.net/projects/want/ "WANT Home Page") script (like ANT, but more focused on Delphi). I'm still trying to decide which one I like better and these notes are to help me, and possibly you, decide.

### The Points:

* **1** means "nice feature" or "that's nicely implemented".
* **2** means "rocking feature" or "that was implemented well".
* **3** means "killer feature" or "this is how software is supposed to be done." 

One of the first things I wanted to do was create a group of actions for checking out the latest code. I quickly found it in ABS's "Standard" category while I had to resort to using the Filter box in FB to finally find it under "Flow Control". While it may be a flow control action I never would have looked there so, **ABS 1**.

The Subversion Checkout action in FB is non-intuitive. It asks for a Source and Destination. Do those parameters make sense to anyone that has actually used svn? ABS kicks it's butt all over the place on this, asking for what you would expect: URL and Work folder. **ABS 2**.

FB has a cool variable picker that shows you all the built-in variables as soon as you type a %. This is great except that a) you have to know that variables start with % and b) you can't use the mouse to click on a variable to select it. ABS has a button you can click to show a list of all variables available. While this may be a little more cumbersome if you know exactly what you're looking for it is much more helpful. **ABS 1**.

Both products fail to show you what the actual value of the built-in variables are though. For example I'm trying to specify a project file for a HTML Help Compiler project and I know I want it relative to my build file but do I specify a backslash after `%FBPROJECTDIR%` or not? Same with ABS. No points to either.

I had to specify the path the the HTML Help Compiler in FB while ABS just seems to know. **ABS 1**.

When you run scripts in FB you can stay in the "Design View", with a progress bar appearing next to each action as it processes. This is nice for when you're building/debugging your scripts. ABS takes you automatically to it's Log and Summary screen instead. While you still get a step-by-step breakdown of what it's doing it takes you out of the context of your script. You can prevent ABS from automatically switching and it'll show you what step it's currently on but if something fails you can't tell from Macro pane which operation failed. **FB 1**.

Both products have a detailed report of the last build status but ABS seems to want to always compare it against the last successful macro run. I'm just starting with these products but I fail to see the use. Personally it just takes up space and the good news is you can remove it. While I can configure ABS to be more to my liking I always feel you've gone back a step in usability anytime the user has to reconfigure the UI. **FB 1**.

Both failed to pick up the user override variables in BDS 2006. If you have [RemObjects](http://www.remobjects.com/ "RemObjects Home Page") installed you probably also have an Everwood and RemObjects SDK user override environment variables that are used inside your library path like this $(Everwood)Bin, etc. Both ABS and DB choked on this and I'm still waiting for a resolution. RemObjects is a pretty popular library for Delphi so I doubt I'm the first to hit this. On the plus side, FB did leave me with a much better error message of "Error expanding variables in Library Path : Variable : Everwood - does not exist!" instead of ABS's "Fatal: F1026 File not found: 'uROClasses.dcu'". I'm giving **FB 1** for the better message. If either of the products had successfully compiled while the other failed that would have been an instant 3 points but sadly they both dropped the ball.

_I'm still reviewing the products so this page will be updated after I make it past compiling my project._