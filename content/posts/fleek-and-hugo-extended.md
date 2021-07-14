+++
title = "Fleek.co and Hugo Extended"
description = "Getting Hugo extended working with Fleek.co hosting"
date = "2021-04-25"
categories = ["Code"]
tags = ["Home Automation", "IPFS", "Hugo", "Fleek.co", "Docker"]
draft = false
+++

I've been exploring distributed low-level systems, such as transport protocols, packet-level encryption, and immutability in a decentralized system (blockchain). Part of that is rebooting my blog and hosting it via [Fleek](https://fleek.co/) over the [IPFS](https://ipfs.io/) protocol.

Hugo is my static site generator of choice and [Go with Hugo and Fleek](https://blog.fleek.co/posts/go-with-hugo-and-fleek) is a great tutorial to get started. Everything worked pretty much as advertised until I picked a theme, [MemE](https://themes.gohugo.io/hugo-theme-meme/), that required the extended version of Hugo that supports Sass/SCSS.

## Build a Custom Docker Image From Fleek's Dockerfile

Fleek's deployment pipeline allows the use of any Docker Hub image as the binary of your site's build step. The supported build systems are Docker images, with their Dockerfile's helpfully committed to Github.

I cloned the official Dockerfiles, updated them to point to Hugo extended, and published a new Docker image to use in the deployment settings on Fleek.

### Create Docker repository

Fleek only accepts public Docker images hosted on Docker Hub, so sign-up for a free account if you don't have one. You get one free repository per account (or is it one image? IDK, I only needed one).

1. Create a new repository: `<docker username>/huge-extended-for-fleek`.

### Create Dockerfile file

I'm doing this on a Windows box but the steps are basic enough that they should work everywhere, with appropriate tweaks.

1. Grab the latest Hugo Dockerfile from [Fleek's Docker Image Github repo](https://github.com/FleekHQ/site-builder-docker-images)

1. Created a new folder to stash the Dockerfile

   ```powershell
   # these are simplified paths, in practice I use Dropbox to keep my files casually backed-up
   # and put all source-type files under a \source folder.
   #
   # # where it lives on my machine:
   # C:\Users\Shawn\Dropbox\source\docker\hugo-extended-for-fleek   
   #
   mkdir c:\repos\docker\hugo-extended
   cd c:\repos\docker\hugo-extended
   ```

1. I did a hack-and-slash and hard-coded the entire Hugo version. I'm not even using HUGO_VERSION, that's how late at night it was.

   ```docker
   ARG NODE_VERSION

   FROM node:latest

   ARG HUGO_VERSION=_extended_0.85.0

   RUN apt-get update && apt-get install -y wget

   RUN wget https://github.com/gohugoio/hugo/releases/download/v0.85.0/hugo_extended_0.85.0_Linux-64bit.tar.gz && \
      tar -xf hugo_extended_0.85.0_Linux-64bit.tar.gz -C /usr/local/bin && \
      hugo version && rm hugo_extended_0.85.0_Linux-64bit.tar.gz
      
   RUN wget -q -O - https://raw.githubusercontent.com/canha/golang-tools-install-script/master/goinstall.sh | bash
   ```

1. Build the image

   ```bash
   docker build -t <your docker username>/hugo-extended-for-fleek:85.0 .
   ```

### Publish Docker image

1. Publish it to Docker Hub

   ```bash
   docker push <your docker username>/hugo-extended-for-fleek:85.0
   ```

### Use new Docker image

1. Find your site under the Hosting section on [Fleek.co](https://fleek.co/)
1. Go to Settings -> Build & Deploy -> Specify Docker Image
1. Edit Settings
1. Replace contents with `<your docker username>/hugo-extended-for-fleek:85.0`
   - (or use mine: `shawnoster/hugo-extended-for-fleek:85.0`)
1. Trigger a new deploy

![](/images/fleek-and-hugo-extended_2021-07-13-17-09-55.png)

## Done

And that's that.

There are lots of great hugo images out there but the ones I found all required some fiddling to get them to work w/ Fleek.co while this image could be optimized it does work seamlessly with Fleek.co.

You can always skip the above steps and use the image directly if you're looking for a drop-in replacement.

**Huge Extended (85.0) for use with Fleek.co:** [shawnoster/hugo-extended-for-fleek](https://hub.docker.com/r/shawnoster/hugo-extended-for-fleek)
