---
categories:
- blogging
tags:
- home-automation
- IPFS
- Hugo
- Fleek.co
draft: false
title: 'Fleek.co + Hugo Extended'
date: 2021-04-25
description: Getting Hugo extended working with Fleek.co hosting
---

# Fleek.co Hosting and Hugo Extended

I've been exploring distributed low-level systems, such as transport protocols, packet-level encryption, and immutability in a decentralized system (blockchain). Part of that is rebooting my blog and hosting it via [Fleek](https://fleek.co/) over the [IPFS](https://ipfs.io/) protocol.

Hugo is my static site generator of choice and [Go with Hugo and Fleek](https://blog.fleek.co/posts/go-with-hugo-and-fleek) is a great tutorial to get started. Everything worked pretty much as advertised until I picked a theme, [MemE](https://themes.gohugo.io/hugo-theme-meme/), that required the extended version of Hugo that supports Sass/SCSS.

## Build a Custom Docker Image From Fleek's Dockerfile

Fleek's deployment pipeline allows the use of any Docker Hub image as the binary of your site's build step. The supported build systems are Docker images, with their Dockerfile's helpfully commited to Github.

I cloned the official Dockerfiles, updated them to point to Hugo extended, and published a new Docker image to use in the deployment settings on Fleek.

### Create Docker repository

Fleek only accepts Docker images from Docker Hub so sign-up if you don't already have one. You get one free repository per account (or is it one image? IDK, I only needed one).

1. Create a new repository: `<username>/huge-extended-for-fleek`.

### Create Dockerfile file

1. Grab the latest Hugo Dockerfile from [Fleek's Docker Image Github repo](https://github.com/FleekHQ/site-builder-docker-images)

1. Created a new folder to stash the Dockerfile

   ```powershell
   mkdir c:\repos\docker\hugo-extended
   cd c:\repos\docker\hugo-extended
   ```

1. I did a hack-and-slash and hard-coded the entire Hugo version. I'm not even using HUGO_VERSION, that's how late at night it was.

   ```docker
   ARG NODE_VERSION

   FROM node:latest

   ARG HUGO_VERSION=_extended_0.82.1

   RUN apt-get update && apt-get install -y wget

   RUN wget https://github.com/gohugoio/hugo/releases/download/v0.82.1/hugo_extended_0.82.1_Linux-64bit.tar.gz && \
       tar -xf hugo_extended_0.82.1_Linux-64bit.tar.gz -C /usr/local/bin && \
       hugo version && rm hugo_extended_0.82.1_Linux-64bit.tar.gz

   RUN wget -q -O - https://raw.githubusercontent.com/canha/golang-tools-install-script/master/goinstall.sh | bash
   ```

1. Build the image

   ```bash
   docker build -t <username>/hugo-extended-for-fleek .
   ```

### Publish Docker image

1. Publish it to Docker Hub

   ```bash
   docker push <username>/hugo-extended-for-fleek:latest
   ```

### Use new Docker image

1. Go to your host in Fleek
1. Find Docker image
1. Replace w/ `<username>/hugo-extended-for-fleek:latest`
1. Trigger a new deploy

## Done

And that's that.
