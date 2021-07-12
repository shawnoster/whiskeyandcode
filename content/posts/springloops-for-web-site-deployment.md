+++
title = "Springloops for Web Site Deployment"
date = "2008-04-24T09:30:21Z"
categories = ["Code"]
tags = ["CI/CD"]
draft = false
+++

One of my clients recently switched hosting providers which threw me for a loop because I was doing all their web site deployment using Subversion. I'd make a change on my development box, commit it, ssh over to their host and issue a matching svn update. It worked great and gave me a big warm fuzzy.

The new host sadly doesn't have svn installed and while I could probably bug them to install it for me I thought I'd see what others out there were doing when it came to shared hosting. Seems svn+rsync is a popular choice along with variations on that theme but I wanted something simpler. Enter Springloops.

[Springloops](http://springloops.com/) is basically a hosted svn repository that will push your changes via FTP to a deployment server, but that doesn't truly convey just how smooth an experience it really is. Getting set up is a snap, the interface is well thought out and has a great aesthetic. You know there is a svn repository behind the interface but it's presented in a very non-threatening for the non-nerd way.

Once you've imported all your files, using whatever svn client you like, you setup a deployment server, giving it your FTP host, path and log in information and from that point on deployment is as simple as a button click. All of this for free and if you step up to one of their paid plans you get automatic deployment, large storage, more deployment servers and more depending on the level you pick.

All in all I actually like this solution better than what I had before because it's easier for others to interact with your site as well as push deployments. Anyone looking for a way to use version control (you are using version control, right?) with shared hosting should definitely give Springloops a try.
