---
title: Architect your Personal Cloud like a Corporation
date: '2021-12-05'
categories:
    - Code
tags:
    - cli
    - security
draft: false
lastmod: '2021-12-05T19:58:51.478Z'
---

# Architect your Personal Cloud like a Corporation

I spend a lot of time at work ensuring API keys and connection strings are stored in a single place and that it's easy to update them when they change. At home I give almost no thought to where I store personal access tokens, API keys, and ssh keys.

I'd like to say I had a security epiphany and that's what set this whole thing off but mostly it's because I'm lazy and didn't want to set mundane things like environment variables multiple times.

## Setup and Configuration

### Install CLI tools - 1Password CLI, jq, httpie

1Password is my source of truth where all my secure information is stored. `jq` is a CLI for quering and manipulating JSON, which comes in handy when dealing with REST responses. `httpie` is my preferred `curl` replacement. `jq` and `httpie` aren't strictly requied but they're such useful general tools, why not install them?

1. [Install the 1Password CLI](https://support.1password.com/command-line-getting-started/)
1. [Install jq](https://stedolan.github.io/jq/download/)
1. [Install httpie](https://httpie.io/download)

Rinse and repeat for environments.

### Authorize Machine

The first time you sign into 1Password on a new machine, whether via the desktop, browser extension, or CLI, you provide both your password and secret key. This authorizes the machine with 1Password. Subsequent logins will only require the main password.

Same command for both Windows and Ubuntu:

```powershell
# the last two values change depending
# your 1Password account
op signin my.1password.com shawn.oster@gmail.com
```

### Add an API Credential

For this example I added my Home Assistant PAT as an API Credential to 1Password.

![1Password API Credential](/images/hass_rest.png)

### Retrieve a Secure Value

The 1Password CLI docs do an excellent job explaining ways to work with and retrieve stored values but the basics are:

1. Request the specific item, by name or UUID
1. Extract the value to write
1. Write value as an environment variable, or wherever else it needs to go

Dump all values for an entry to get the UUID

```bash
op get item HASS_REST | jq
```

This fetches the entire record for `HASS_REST` as JSON and pipes it through jq to make it easier to read.

There are various ways from here to extract just the needed value, including 1Password's bult-in mini query language:

```bash
op get item HASS_REST --fields credential
```

### Automate Setting Secure Environment Variables

One of the most common uses for secure values, at least for me at home, is setting various environment variables. Given the whole point of this is to automate this whole process I wrote two scripts, one to set environment variables with my personal tokens and another to clear them.

#### Securing a session

```bash
#!/bin/sh

# secure-env.sh
#
# "Secures" a session by writing sensitive keys as session environment
# variables. Not exactly secure but it does reduce surface area and ensures
# the latest values are always being used

# sign-in to 1Password
eval $(op signin my)

echo "Setting Home Assistant REST PAT - HASS_REST..."
hass_rest_credential=$(op get item HASS_REST --fields credential)
export HASS_REST=$hass_rest_credential

# Gladios says hello
echo "Unbelievable. You, [subject name here] must be the pride of [subject hometown here.]"
```

### Test It

Being able to run the following command was the motivation for this blog post, might as well show it off :) This makes a HTTP POST request to my Home Assistant REST API, secured with a PAT, to turn my office's ceiling light on/off from the command line. I suppose I could have gotten up and just flipped a switch, but where's the fun in that?

```bash
# sing in and load secure tokens
./secure-env.sh

# use said tokens ($HASS_REST)
http --json \
     POST http://192.168.1.116:8123/api/services/light/turn_on \
     'Content-Type:application/json' \
     "Authorization: Bearer $HASS_REST" \
     'entity_id=light.hue_bulb_office'
 ```

## Conclusion

That's the rough version of how to incorporate a password manager into your daily life without spamming secure keys across all your environments.

A lot has been left to the reader (any me), a few things on my to-do list are:

- Create both PowerShell and bash scripts
- Write a script to clear variables and log out
- Stash the scripts in a public Github repo to make it easier to bootstrap a new machine

Have fun and stay secure!
