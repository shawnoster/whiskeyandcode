---
title: An Opionated Way To Approach Note Taking
date: '2021-09-12T00:09:01.785Z'
draft: false
categories:
    - Code
tags:
    - Dendron
    - notes
    - wiki
lastmod: '2021-09-12T00:09:01.785Z'
---

## An Approach to Figuring Out How to Organize Your Notes

Stop playing around with tools and drooling over bullet jouranals and every shiny new markdown-based system. How do you really take notes? What notes are actually important? Who can see them? Answer those questions and you have a great start to a well-organized system with enough struture to get past obsessing over the best way.

### Step One - Identify What and How you Really Capture Notes

What type of information do you want to really capture, and later find? For me it's:

- Reciepes and food notes and links
- Code snippets for later references and sharing
- Tutorials and runbooks for specific tasks
- Blog plots
- Quotes from friends
- Personal writing thoughts and story ideas
- Very personal booty photos and memories
- Scratch notes
- Daily to-do lists

### Step Two - Group Notes By Sharing Levels

Figure out who can see each type of note, and how you'd like to share them. There's no min or max, different workflows have different audiences. I had three:

- Public - blog posts, code snippets, how-tos
- Personal - writings, scratch notes, personal runbooks, todo lists
- Private - personal conversations, booty, diary

Some things could span all three, such as writing, but I didn't sweat it.

### Step Three - Create a repo per Group

It's very embarrasing to post private thoughts into a public space. Having one repo per group allows better access management and exposure.

For me I have:

- notes-public (public repo)
- notes-personal (private repo)
- notes-private (private repo)

### Step Four - Initialize Dendron, Add All Three Vaults

Follow the excellent guide.

### Step Five - Create Templates for Each Note Type

- notes-public/templates/reciepe
  - adds Food and Reciepe categories
  - adds Date
  - Provides basic template
  - lastupdated
- notes-public/templates/snippet
- notes-personal/templates/daily
- notes-personal/templates/writing
- notes-personal/templates/dnd
- notes-personal/templates/writing

- notes-private/templates/diary