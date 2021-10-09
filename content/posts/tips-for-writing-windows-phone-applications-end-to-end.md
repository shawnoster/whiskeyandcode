---
title: Tips for Writing Windows Phone Applications End-to-End
date: 2012-02-06T01:35:08Z
categories:
    - Windows Phone
draft: false
---

I'm currently working on a [GoodReads](http://www.goodreads.com/) client for Windows Phone and while I've written a ton of phone code for various demos, API smoke testing, targeted "how do I" questions, etc. it's an entirely different beast to write an application end-to-end. The technical questions are often the easiest and if you've been coding for more than a few years (or months, you rockstar you) the problems and questions that keep you up at night shift from technical ("how do I save an image to the phone?") to architectural ("what's the best pattern for integrating a REST client into my caching framework?").

As a knowledge and data capturing exercise I'm collecting the various articles, resources and code snippets that I found extremely helpful as I fleshed out my application, grouped by the order I came across the issues and roughly the order I architected my application.

This is a "live" document that will to continue to grow as I finish my application. Also if you've found articles that made a key difference in your application development let me know so I can check them out!

## User Experience/UI Design

[![Kudu UI Sketch](/images/IMG_0117_thumb.jpg "Kudu UI Sketch")](/images/IMG_0117.jpg)

Close down Visual Studio, stop building up your class library and do something that you've been told is anathema to good development. Start with your UI and build out from there. It is key you understand the layout of your application, roughly what each page will look, what functions it'll perform, what states it can be in. Seriously. I crafted this lovely rich client that modeled my entire backend in a clean, crisp way and then I threw it all away. Why? Because when I started mapping the client to my UI I was making 3 or 4 calls to the backend when if I'd just understand HOW I'd be displaying it I would have crafted my middle-layer differently. It's one of the dirty secrets of creating lean and mean apps, you do end up building you middle-tier to optimize for the end result, not as some model that has been delivered from high on top.

* When you need a little more structure than just a piece of blank paper try the [Windows Phone Sketch Pad](http://www.uistencils.com/products/windows-phone-sketch-pad) from UI Stencils. I love this sketch pad and it helped me a ton in crafting my UI and work flow.

* Make sure you're familiar with the [User Experience Design Guidelines for Windows Phone](http://msdn.microsoft.com/en-us/library/hh202915(v=vs.92).aspx) over on MSDN as you start thinking about your application.

* The [Windows 7 Snipping Tool](http://windows.microsoft.com/en-US/windows7/products/features/snipping-tool). It's already on your machine (you are running Win7 right?) and I use it about a dozen times a day to screen grab my current page and drop it into Paint.NET to take pixel measurements to make sure my UI is as close Metro design guidelines as possible.  

## Architecture

* You'll need to think about caching if you deal with any significant amount of data and on a mobile device that pretty much means any data at all. I'm using Shawn Burke's excellent web request data caching framework [AgFx](http://agfx.codeplex.com/).

* I am using a form of MVVM but I haven't jumped on board with either Prism or MVVM Light, mostly because I'm a nerd and I don't trust anyone else's code until I've written my own framework, formed my own opinion of how things should be done and then adopt the one that I best align with.  

## Login/Authentication

A great number of applications are skins over some backend that requires a login and these days there is a good chance it's via OAuth. It's actually not that hard but it can be a huge in the arse to debug and get just right as each back-end does things just slightly differently. Here are the articles that helped me along:

* From my colleague Sam Jarawan I cribbed a bunch of code from his article, "[Building a 'real' Windows Phone 7 Twitter App Part 2 - oAuth](http://samjarawan.blogspot.com/2010/09/building-real-windows-phone-7-twitter_18.html)"

* I used both excellent .NET REST helper libs [Hammock](https://github.com/danielcrenna/hammock) & [RestSharp](http://restsharp.org/). I ran into some issues with params with square brackets using Hammock so had to switch to RestSharp but I honestly couldn't find any major different between the two to recommend one over the other. RestSharp seems to have a slightly more active community and docs.

* A lot of apps simply won't work if you don't log in so you want to conditionally show a login page based on some state. For that turn to Peter Torr's blog post, "[Redirecting an initial navigation](http://blogs.msdn.com/b/ptorr/archive/2010/08/28/redirecting-an-initial-navigation.aspx)".  

## Certification

* My app hasn't yet been submitted for certification but I've already been using the [Windows Phone 7 Application Certification Cheat Sheet](http://www.silverlightshow.net/items/Windows-Phone-7-Application-Certification-Cheat-Sheet.aspx) to make sure my app will sail through without any issues.  

## Tools

My supporting cast of tools.

* [Git](http://code.google.com/p/msysgit/) - Whether you're a lone wolf, a pack of one, coding the next great thing or a corporate developer you need to version control. If you're in a company you probably already have a solution but if you're a coffee shop coder you may not be using anything and that my friend is a mistake. You'll get on a caffeine buzz and decide to refactor your entire application only to get distracted and find your app in pieces wishing you could just get back to how everything was pre-latté. There are a ton of great source control systems but lately I've been using git like all the cool kids. To do local versioning is a snap, without the need for a server or service running. I also still love Subversion and the server I put in place at my last job is still rocking along being a source control hero.

* [Dropbox](https://www.dropbox.com/) - I code on three different machines and Dropbox makes it possible for me not to worry if I have the latest source for my project. Best of all it works well with my source control so I get portability as well as versioning.
