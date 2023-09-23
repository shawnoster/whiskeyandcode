---
title: My Approach to Note Taking using Dendron
date: "2021-09-12"
categories:
  - Whiskey
tags:
  - dendron
  - knowledge management
draft: false
---

# Using Dendron - An Opionated Approach

## My Dendron Setup

1. Initialize a Dendron work space
1. Organize notes based on privacy levels
1. Create a storage location for each privacy level
1. Create default templates for each note type

### Step One - Initialize a Single Dendron Workspace

#### Goals

- A single location for all notes to reduce location confusion
- Backup for items not yet commited to a repo

#### Steps

1. Open Visual Studio Code
1. Install the [Dendron extension](https://marketplace.visualstudio.com/items?itemName=dendron.dendron)
   - I skip Dendron Markdown Shortcuts because it re-maps `Ctrl+B` and I'm too lazy to re-map and re-learn
1. Run `Dendron: Initialize Workspace` from the command palette
   - I used `/Dendron` at the root of my Dropbox folder for extra backup

### Step Two - Organize notes based on privacy levels

Storing information based on privacy level enforces good privacy practices, increases sharing options, and allows for multiple storage locations with their own access permissions.

I use three:

- `notes-public` (public Github repo)
  - blog posts
  - code snippets
  - reciepes
- `notes-personal` (private Github repo)
  - writing ideas
  - D&D notes and ideas
  - setup guides for my personal life
  - random scratch notes
- `notes-<company>` (private repo hosted on a company server)
  - meeting notes
  - company-specific setup guides
  - action items

My public and private repos live in a personal Github account and work notes live in a company hosted Azure Repo. This keeps work content seperate from personal while allowing me to pull down my public notes onto my work laptop.

### Step Three - Create a storage location for each privacy level

Dendron stores notes in vaults and supports multiple vaults and vault locations. By default are local file-system vault is used, with files stored in the workspace root. It also supports git-based vaults, allowing easier sharing, backup, and providing a single source of truth. It also allows access to your notes on machines that only have a browser.

[Using Dendron with Github and Git](https://mstempl.netlify.app/post/dendron-git/) provides detailed steps for creating and connecting git-based vaults, here are the cliff notes.

For each privacy level:

1. Create a new Github repo
1. Open your Dendron workspace
1. Add each vault via `Dendron: Vault Add`
   - choose `remote` and `custom`
   - enter the clone URL of your repo

Work vaults should be created inside your company, we use Azure Repos.

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

---

## Initiailze A Dendron Workspace


1. Install the [Dendron VSCode extensions](https://marketplace.visualstudio.com/items?itemName=dendron.dendron)

1.
1. I picked my Dropbox root: `C:\Users\shawn\Dropbox\Dendron`
   - provides an extra layer of backup
   - follows my existing pattern of using Dropbox as my main user "root" for documents
   - making it a folder off the root highlights it's importance



### Repos for Work Notes

-

