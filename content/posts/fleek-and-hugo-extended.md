---
title: Fleek.co and Hugo Extended
description: Getting Hugo extended working with Fleek.co hosting
date: '2021-04-25'
categories:
   - Hugo
draft: false
lastmod: '2021-12-28T02:59:58.428Z'
---

# Fleek.co and Hugo Extended

I've been exploring distributed low-level systems, such as transport protocols, packet-level encryption, and immutability in a decentralized system (blockchain). Part of that is rebooting my blog and hosting it via [Fleek](https://fleek.co/) over the [IPFS](https://ipfs.io/) protocol.

Hugo is my static site generator of choice and [Go with Hugo and Fleek](https://blog.fleek.co/posts/go-with-hugo-and-fleek) is a great tutorial to get started. Everything worked pretty much as advertised until I picked a theme, [MemE](https://themes.gohugo.io/hugo-theme-meme/), that required the extended version of Hugo that supports Sass/SCSS.

## Build a Custom Docker Image From Fleek's Dockerfile

Fleek's deployment pipeline allows the use of any Docker Hub image as the binary in a site's build step. The supported build systems are Docker images, with their Dockerfile's helpfully committed to Github.

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
   mkdir c:\repos\docker\hugo-extended-for-fleek
   cd c:\repos\docker\hugo-extended-for-fleek
   ```

1. Added `_extended` into the `wget` call to pull the extended version from [Hugo's release page](https://github.com/gohugoio/hugo/releases). The default image allows passing in the `node` version but Hugo doesn't care so I went with latest.

   ```docker
   FROM node:latest

   ARG HUGO_VERSION=0.91.2

   RUN apt-get update && apt-get install -y wget

   RUN wget https://github.com/gohugoio/hugo/releases/download/v${HUGO_VERSION}/hugo_extended_${HUGO_VERSION}_Linux-64bit.tar.gz && \
      tar -xf hugo_extended_${HUGO_VERSION}_Linux-64bit.tar.gz -C /usr/local/bin && \
      hugo version && rm hugo_extended_${HUGO_VERSION}_Linux-64bit.tar.gz
      
   RUN wget -q -O - https://raw.githubusercontent.com/canha/golang-tools-install-script/master/goinstall.sh | bash
   ```

1. Build the image

   **Ubuntu**

   ```bash
   # there are needed to avoid using Docker buildkit, 
   # which breaks many things
   export DOCKER_BUILDKIT=0
   export COMPOSE_DOCKER_CLI_BUILD=0

   docker build . -t <your docker username>/hugo-extended-for-fleek:91.2
   ```

   **PowerShell**

   ```powershell
   # there are needed to avoid using Docker buildkit, 
   # which breaks many things
   $env:DOCKER_BUILDKIT=0
   $env:COMPOSE_DOCKER_CLI_BUILD=0

   docker build . -t <your docker username>/hugo-extended-for-fleek:91.2
   ```   

### Publish Docker image

1. Publish it to Docker Hub

   ```bash
   docker push <your docker username>/hugo-extended-for-fleek:91.2
   ```

### Use new Docker image

1. Find your site under the Hosting section on [Fleek.co](https://fleek.co/)
1. Go to Settings -> Build & Deploy -> Specify Docker Image
1. Edit Settings
1. Replace contents with `<your docker username>/hugo-extended-for-fleek:91.2`
   - (or use mine: `shawnoster/hugo-extended-for-fleek:91.2`)
1. Trigger a new deploy

![](/images/fleek-and-hugo-extended_2021-07-13-17-09-55.png)

## Done

And that's that.

There are lots of great hugo images out there but the ones I found all required some fiddling to get them to work w/ Fleek.co while this image could be optimized it does work seamlessly with Fleek.co.

You can always skip the above steps and use the image directly if you're looking for a drop-in replacement.

**Huge Extended (85.0) for use with Fleek.co:** [shawnoster/hugo-extended-for-fleek](https://hub.docker.com/r/shawnoster/hugo-extended-for-fleek)
