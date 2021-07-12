+++
title = "How to Version your Software"
date = "2007-04-22T07:50:00Z"
categories = ["Code"]
tags = ["best practices"]
draft = false
+++

Most developers live and breath version numbers, yet there are a few that either don't or don't really have a good rule of thumb on what their versions should mean. There are also quite a few people that have to deal with versions that aren't developers, such as tech support, marketing and new team members. For those people it's always a good idea for everyone to be on the same page.

## What's in a version?

So you have version 1.5.4.675, what does that mean? First, the different parts are, in order, major, minor, release and build number. I first wrote this up as four separate paragraphs sharing all my golden nuggets of wisdom but realized in this day and age sometimes the Cliff-Notes version is better. Here is what the various parts of a version number mean and when they should be incremented:

### Major

- All features across the same version should be either 100% compatible or in rare conditions gracefully degrade.  
- File formats should be compatible, all 1.x versions should open, save and edit 1.x versions.  
- For commercial products all updates in the 1.x line should be free  
- Only release a new major version if;
  - the flow of the application has been noticeably changed,  
    - there are a significant number of new high-visibility, high-usability features,  
    - the user interface has drastically changed.
    - New major versions should always be able to import or open older versions.

One key point is that only new highly usable features should mark a new major version. New major versions usually mean an upgrade cost and nothing is more annoying than buying a new version only to find the new features are only useful to about 1% of the install base. I've seen several products try to push a new version with inflated features that don't actually offer any benefit.

### Minor

- New non-breaking small feature, meaning it still works with other version with the same major version.  
- Bug fixes that apply to everyone.  
- You'll want everyone to be running the latest minor version so be prepared to make this available to everyone.  
- Tech support should usually make sure the end-user is on the latest minor version before going farther.  *
 Installing the newest minor version should be painless. All user settings should transfer over seamlessly.

### Release

This gets a little murky for some and there are a lot of schools of thought on this one, here is mine:

- Represents the release of the current major.minor version.  
- Increase the release when you do small, infrequently encountered bug fixes.  
- Not everyone needs to be on the latest release, only those affected by certain issues.  
- If you do Betas and Release Candidates this is the place to note that. If you release RC1 as version 2.5.0 and someone finds a bug you update the release to 2.5.1.  
- Resets back to 0 every time the minor version changes.

That last point is where a lot of people get into knife-fights. Some think release should mean the number of times a product has actually been "released" into the public. If that's how you think then by all means go for it. Personally I think of it as a version number for the version number, in other words, how many times did I release version 3.1?

### Build

- Always increments.  
- Never gets reset.  
- Most useful for bug reporting.  
- Should only get incremented by the "official" build box.

The last point might need some explaining. For a solo developer this just means each time you build the software from your machine. For a large team though, with each developer probably compiling the application a few hundred times each day, this build number would get big fast as well as quickly lose it's meaning. Instead, developers on a team usually have one machine that is the official build machine, where nothing but the compiler and any needed libraries and components are installed. This insures a consistent, clean, known build each time.

And Bob's your uncle. Pretty basic stuff. While there are different schools of thoughts on versioning one thing that should be clear is that everyone on your team, including managers, marketing, support and developers on other teams, should all be on the same page when it comes to versions.
