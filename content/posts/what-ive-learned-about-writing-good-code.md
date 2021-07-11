+++
title = "What I Have Learned About Writing Good Code"
date = "2007-05-03"
categories = ["Code"]
tags = ["best practices"]
draft = false
+++

There are lessons you learn in school and there are the things you learn along the way. I've been developing software for 25 years, since I was 8, starting with a book called "[Your First BASIC Program](https://www.goodreads.com/book/show/4488063-your-first-basic-program)" that my dad bought me because we had a PC while all my friends were playing StarBlazers on their Apple IIs. He said if I wanted to play games then I could write one myself.  At the time I was a bit disappointed (OK, crushed) but now... well, Dad, thank you.

These are some of the things I didn't learn in school, but wish I had:

## Use Version Control

Even if you're a solo developer get into the habit of using a version control system. For one it gets you used to the concepts of version control which you'll definitely need if you work with a larger team and secondly it offers another level of protection. My current favorite is [subversion](http://subversion.tigris.org/), it's easy to install, has a great command-line and GUI client and it's free.

One more bit, commit often. Think of commits as "undo checkpoints". You thought replacing every instance of the base class across 50 project files was a great idea but then realized your idea sorta sucks? No problem, you can restore all 50 of those files back to their pristine state. No undo buffer will help you the way a good VCS will.

## Use the Native Naming, Coding and Formatting Style or "When In Rome"

Before you decide to reinvent the wheel look to the native language for hints on code formatting, variable naming, indenting and method naming. Fight the urge to use your own style or to use your favorite formatting from another language. There are a few reasons:

### Maintenance

Some poor schmuck down the line will probably have to look at your code and they will probably disagree with your highly stylized use of brackets. At least the native style of formatting will be familiar to them as a common baseline.

### Fighting the IDE

If you're using an IDE it'll probably have some form of code completion, with some built-in templates for basic things like loops, classes, closures, etc. Those templates will more than likely be in the "native style" and you'll either spend all your time fixing the formatting or worse you'll create a mishmash of your style plus the IDEs, which creates confusion.

### Avoids Fights

Everyone loves to fight about how to format code, picking the native coding style means you're the only one with an actual real argument, everything else is just opinion.

## Sharing Code

Sometimes you'll have bits of code that don't work and you'll post a snippet on a forum or newsgroup. It's much easier for everyone to help out if the code looks familiar. Anytime I see some really crazy formatted code from someone asking for help I skip right over it. I don't have time to puzzle over their code AND their strange formatting.

## Catalog your Knowledge

Whether it's a blog, a wiki, del.icio.us or just a big fat txt file you'll want a way to collect the bits. As a developer you absorb an amazing amount of information each day and you're bound to forget that exact command-line parameter you need to get something working. Trust me, it's easier to spend 5 minutes writing a blog post or tagging it in del.icio.us than to have to spend another 30 minutes later hunting it back down.

## Don't Be a Bigot

Don't attack someone just because they don't code in your language or tool of choice. I see so much energy wasted by people putting down one language or another. Ruby on Rails developers bashing ASP.NET coders, ASP.NET users coming down on Flash programmers, Delphi developers ripping apart .NET. Every language and framework has strengths and weaknesses and given the huge number of tools there will be many ways to accomplish the same goals, none of them more correct than the other.

## Don't become a Framework Programmer

I've sat through some pretty painful interviews where I asked basic programming questions only to answered with, "well, first I'd download this library and then..." or "I'd use this helper method...". When I asked how they'd do it without that library or method I either got blank looks, or my favorite answer, "well, then it couldn't be done".

Knowing that there are great frameworks out there, whether they be .NET, the VCL or Rails, is great, and knowing how to squeeze all the performance out of them is a worthy skill but you will always hit points where you have to go outside the framework. If you understand programming concepts you can always learn new languages pretty quickly but if all your knowledge is sunk into a single framework it's going to make the transition rough.

Understanding programming as a concept vs. a set of syntax and framework calls also opens up a huge number of resources for you. Not every article will be written in your language and there is no reason to ignore a great idea just because it's not tailored for your framework/language of choice.

## Don't just Copy And Paste Code

I have a phrase I use at work that I'm pretty sure annoys the hell out of co-workers, it goes like this, "Don't just copy and paste code, instead copy, **understand** and THEN paste". There is a wealth of code samples out there but if you don't really understand what it is you are using then it's going to be a pain in the arse later to debug. We all have times we just want to get something working but if you don't really understand the code you're using then you're always going to be dependent upon someone else. It's also important to remember that just because it turned up on the internet doesn't mean it's actually good code.

## Understand the Sugar

Lately I've seen a few examples in Ruby, JavaScript and C# showing off some great syntactical sugar, shortcuts that make it easy to do things in one line that used to take five or six. They are impressive and definitely time saving but they come with a cost, usually in terms of performance.

One example is working with collections in Ruby. Someone posted a snippet showing how you could replace a "bulky, ugly for-loop" that gathered objects that met a certain criteria and then did "something" to them with a single line of Ruby code. The Ruby looked sexy, it was small, it was readable, it got ohhs and ahhs. The for-loop was the underdog at 9 lines, it used nothing but the most basic language constructs. The problem was the fact that the single-line of code actually went through the collection 4 separate times while the old-school for-loop did it in a single pass.

There are quite a few times where the sugar outweighs the performance hit but it's important to understand what that sugar is really doing.

## Code for Maintenance

Pretend you're in that movie "[Memento](http://www.imdb.com/title/tt0209144/ "Memento")" and that you forget everything about your project every night. You should be able to figure out what's going on the next day fairly quickly just from how the project is structured, it's class names and coding style. Your variable names should make sense, methods should be tidy, there shouldn't be 15 layers you have to drill through just to do something that should be simple.

Here is a dirty little secret, the easier it is for someone else to understand your code the easier it is for you to hand it off. If you're the only one that can make sense of your code you are going to tied to that project forever. Forget getting first pick of new projects, you're now kept in reserve incase you have to do maintenance on your project.

## Code for Now

As developers we love to code for that future when we may need to add another database back-end or swap out a different rendering engine or port to a different platform. Guess what, unless those things are actually on some roadmap or written on a stone tablet they will either never happen or will happen in such a way that you'll end up rewriting your code anyway. I have a ton of old projects littered with extra layers of abstraction that I've never needed and they've gotten under foot more times than they've been helpful.

Dirty Secret: It's always been easier to add in a new abstraction layer than it has been to work with an existing one that was never used. If you don't need it right now then don't code for it.

## Stay Abreast of the Landscape

You'll never know everything about programming, it's a constantly expanding landscape but it is a good idea to keep abreast of what's going on around you. One of the things that has served me best is knowing just enough about other programming areas that I usually have pretty good idea to know where to look for things.

There is no excuse to not know a little bit about what it is going on these days. It used to be I got most of my information from magazines and newsgroups, now there are also blogs and wikis, community forums and podcasts.

### Dirty Secret #1

Subscribe to at least two different sources that have different views. Everyone is biased and again, not everyone knows everything. Usually between an evangelist and a detractor you'll come close to knowing the "real" story about something.

### Dirty Secret #2

Read even the boring things. We used to get a Delphi magazine at work and at first I'd only read the articles that applied to me. I'd ignore the database and security articles because that's not what I was working on at the time. Then I got bored and started reading the entire thing each month. Later, when I started working on a project that was heavy on DB and security I found I already knew a little something about both.
