---
title = "ASP.NET MVC Makes .NET Fun Again"
date = 2007-12-14T11:27:00Z
categories = ["Code"]
tags = ["ASP.NET", "MVC", ".NET"]
draft = false
---

I've been dabbling in the Ruby on Rails world for awhile and I've always been drawn to the very clean separation of the Model-View-Controller framework, something Rails pretty much nailed in their implementation. I've done a few small Rails sites here and there, played with it enough to be dangerous but I didn't use it enough in my daily life to really get it under my belt. At the same time I was doing a lot of ASP.NET work and felt like I was constantly fighting the WebForms architecture to get it to produce proper stateless standards-compliant web applications that were based around the concept of request/response. I'd disable ViewState, override Inits(), hack into the page lifecycle and ignore server controls so I had real control the HTML output and get back my CSS id selectors. In a very bad way WebForms reminded me of VB6 and all the hacks I had to do during my stint with that language.

The most frustrating point came when the CSS Adapters were released and touted as some kind of panacea to those that cared about web standards when in reality they are more akin to giving a woman with a horrible breast job a big baggy sweater with a picture of a nice rack on the front. Sure, it may be a pretty picture but the scar tissue and ugly layers are still there.

I think I got some of my faith back after I started reading [Rob Conery's blog](http://blog.wekeroad.com/) because in him I found a Rails enthusiast who still enjoyed the many good aspects of ASP.NET and C#. Instead of just jumping ship he was bringing some of the better elements, and more importantly concepts, over to the .NET side with the [SubSonic project](http://www.subsonicproject.com/). Then he somehow got mixed up with some other crazy people like [Phil Haack](http://haacked.com/), [Scott Guthrie](http://weblogs.asp.net/scottgu/) and [Scott Hanselman](http://www.hanselman.com/blog/) and now we have the [ASP.NET 3.5 Extensions Preview](http://asp.net/downloads/3.5-extensions/) which contains a juicy little nugget otherwise known as ASP.NET MVC.

After wading through the bits, doing a few sample projects and generally taking their version of MVC for a walk-about I can say I'm once again excited about .NET. Sure there are some rough spots and some areas that are a bit too "chewy" (you know a line of code that's a 100 characters long and includes at least three generics and two type casts? yeah, that's chewy) and design decisions that some people are taking umbrage over but all in all it feels useful, feels clean and feels like real programming.

In an odd way I have the same feeling I had back in the day when I switched from Visual Basic to [Delphi](http://www.codegear.com/products/delphi/win32) (which I still think is the best tool for creating native Win32 applications), like I once again have control.