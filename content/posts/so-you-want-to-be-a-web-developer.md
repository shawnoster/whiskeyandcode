+++
title = "So You Want To Be a Web Developer"
date = "2008-04-03T13:45:00Z"
categories = ["Code"]
tags = ["web"]
draft = false
+++

I just had a friend at work ask that most innocuous of questions, "So, what should I learn if I want to be web developer?" which led us into a pretty good discussion about all things web related and to give him (Hi Nat!) a place to reference my ramblings I thought I'd jot down what I suggested.

## Define "Web Developer"

Web developer can pretty much mean anything these days so I find it best to ask yourself what it is you really want to do. I've been in shops where web developer meant just HTML/CSS while in others the dev does it all, from comps to HTML to database interaction. In my friend's case it meant creating a dynamic database-driven website from nothing more than a designer's comps and the napkin the business leaders scribbled on in between rounds of golf. Which was good because that's how I define it.

## Learn HTML/CSS

You've gotta learn the basic currency of the web before you can get fancy pants on it so getting a solid understanding of good, standards-based semantic HTML and CSS (vs. table tag soup) is key. Regardless of which whiz-bang rocket framework you use in the end it all comes down to pushing HTML so you need to know how to craft good basic pages.

I also suggest forgetting about Dreamweaver, FrontPage or any other HTML editor, for now. In fact I'd suggest using just a really solid text editor like [TextPad](http://www.textpad.com/), [InType](http://intype.info/home/index.php) or [E](http://www.e-texteditor.com/). My current favorite is InType because it doesn't require the cygwin install like E yet it has better syntax highlighting and snippet expansion than TextPad. When learning HTML you want to be as close to the metal as possible.

There are a ton of great books and websites out there teaching this stuff. Two of my favorites are ["Bulletproof Web Design"](http://www.simplebits.com/publications/bulletproof/) and ["Web Standards Solutions"](/blog/admin/Pages/Web%20Standards%20Solutions), both by [Dan Cederholm](http://www.simplebits.com/), who presents web design (as in the HTML, not Photoshop comp work) in a real-world, useful manner. Good stuff.

## Learn JavaScript

I'm still iffy on this one since you could argue that JavaScript could come later but I feel it's best to at least get a rudimentary understanding of JavaScript to learn the basics like client-side validation, confirmation boxes and how to use one of the various JavaScript libraries out there like [Prototype](http://www.prototypejs.org/), [jQuery](http://jquery.com/), [ExtJS](http://extjs.com/). Most server-side frameworks try to color the basic way you use JavaScript which I feel can dilute a person's understanding of just what client-side coding is all about.

## Pick Your Poison (Server-Side Framework)

Ahh, the golden ring, the big prize, what it's all about, at least for me, the server-side framework that makes all the magic happen when it comes to dynamic page generation. This was probably the hardest thing to guide him on because I've worked with most of the major frameworks and they all have pros and cons. The big three to me are [ASP.NET](http://asp.net/), [Rails](http://www.rubyonrails.org/) and [PHP](http://www.php.net/). They all have great support, vibrant communities and very active development. There is also Java, but I was badly scarred when I learned Java's AWT and Swing frameworks so I'm going to completely ignore it since even thinking about it again makes me whimper :)

### [ASP.NET](http://asp.net/)

I'm a little biased towards .NET because it offers a great springboard in terms further types of development. Want to do create a desktop application? No problem, you already know the IDE and C# (OK, or Visual Basic). Feel like being more creative and want to do something Flashy? .NET has you covered with [Silverlight](http://silverlight.net/). It's like a gateway drug of development, especially once you start factoring in things like [IronPython](http://www.codeplex.com/Wiki/View.aspx?ProjectName=IronPython), [IronRuby](http://www.ironruby.net/) and [MVC](http://www.asp.net/mvc/). And despite what some people say ASP.NET isn't just for corporate drones, there's no Web 2.0 site out there that can't be coded in .NET. Downsides are that it's a little more complex to get started and that it'll warp your fragile little mind when it comes to the bastard child that is WebForms.

### [Rails](http://www.rubyonrails.org/)

I think learning [Ruby](http://www.ruby-lang.org/en/) (the language of Rails) is a great addition to any developer's knowledge, regardless of what they code in by day. If someone is interested strictly in single focus, highly dynamic web sites and really has an aversion to Microsoft this is where I'd steer them. It's a much better abstraction of the web than .NET's WebForms and you can really get rocking quickly without having to understand much with Rails. The downside is finding jobs in your area looking for entry-level Rails devs.

### [PHP](http://www.php.net/)

This is sort of the monkey in the middle. There are a ton of great PHP jobs but it's lost a little of it's hipster sizzle, which isn't exactly a bad thing. PHP is a great choice for the newbie consultant looking to work with small to medium-sized companies because there are a lot of CMS packages in PHP and you can get solid PHP hosting for a song.

## Summary

In the end I suggested that he go through job descriptions he was interested in (shhh, don't tell his boss) and see what they were asking for in terms of knowledge. This brings up another good point, why do you want to be a web developer? If it's just for a better job then I stand by my suggestion. On the other hand if it's because you want to do Website X or Project Y then that completely changes the game and makes it easier. You pick the technology and learning curve that will get you quickest to your goal. In the end users could care less if your site is in Rails, .NET or PHP.
