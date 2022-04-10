---
title: Secure Personal Secrets using Environment Variables and 1Password CLI
date: '2021-12-05'
categories:
    - Code
tags:
    - cli
    - security
draft: false
lastmod: '2022-04-09'
---

> 2022.04.08 -  - Since writing this a new version of the 1Password CLI came out (2.0) that handles setting environment variables in a much slicker way. The below steps will still work but I suggest checking out the official "[Load secrets into the environment](https://developer.1password.com/docs/cli/secrets-environment-variables)" [1Password CLI](https://developer.1password.com/docs/cli) docs first.
>
> I also fixed a bunch of spelling mistakes and typos.

# Secure Personal Secrets using Environment Variables and 1Password CLI

At work I spend a lot of time ensuring sensitive access credentials such as passwords, API keys, personal access tokens (PATs) and database connection strings are stored in a secure place that's easy to manage and consume by trusted people and systems. Part of that is never duplicating information, instead pulling it directly from a single, trusted source-of-truth.

Personally I store all my sensitive passwords and keys in 1Password but I still copy/paste anything that's not a password into various environment variables and configuration files spread across multiple laptops and environments.

I realized just how silly it was to secure my secrets only to expose them to anyone with access to my machines and how much time I wasted ensuring all my environments were configured correctly and up-to-date.

## Automate 

Taking a cue from my day job I decided to automate the whole thing in a way that made moving between environments easy and secure, that utilized tools I was already using.

Since 1Password is my source of truth where all my secure information is stored I started there. 

## Setup and Configuration

### Install CLI tools - 1Password CLI, jq, httpie

> 2022.04.10 - Another reminder that [1Password CLI 2](https://developer.1password.com/docs/cli) now handles all of this for you!

1. [Install the 1Password CLI](https://support.1password.com/command-line-getting-started/)
1. [Install jq](https://stedolan.github.io/jq/download/)
1. [Install httpie](https://httpie.io/download)

`jq` is a CLI for querying and manipulating JSON, which comes in handy when dealing with REST responses. 

`httpie` is my preferred `curl` replacement. `jq` and `httpie` aren't strictly required but they're such useful general tools, why not install them?

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

There are various ways from here to extract just the needed value, including 1Password's built-in mini query language:

```bash
op get item HASS_REST --fields credential
```

### Automate Setting Secure Environment Variables

One of the most common uses for secure values, at least for me at home, is setting various environment variables. Given the whole point of this is to automate this whole process I wrote two scripts, one to set environment variables with my personal tokens and another to clear them.

#### Securing a session

**PowerShell**

```powershell
# secure-env.ps1
#
# "Secures" a session by writing sensitive keys as session environment
# variables. Not exactly secure but it does reduce surface area and ensures
# the latest values are always being used

# sign-in to 1Password
Invoke-Expression $(op signin my);

# set HASS_REST env variable
Write-Output "Setting Home Assistant REST PAT - HASS_REST..."
$env:HASS_REST=$(op get item HASS_REST --fields credential)

# Gladios says hello
Write-Output "Unbelievable. You, [subject name here] must be the pride of [subject hometown here.]"
```

**Ubuntu**

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

**PowerShell**

```powershell
# sign in, load secure tokens
./secure-env.ps1

# use said tokens ($HASS_REST)
http --json `
     POST http://monocularjack.duckdns.org:8123/api/services/light/turn_on `
     'Content-Type:application/json' `
     "Authorization: Bearer $env:HASS_REST" `
     'entity_id=light.hue_bulb_office'
```

**Ubuntu**

```bash
# sign in, load secure tokens
./secure-env.sh

# use said tokens ($HASS_REST)
http --json \
     POST http://monocularjack.duckdns.org:8123/api/services/light/turn_on \
     'Content-Type:application/json' \
     "Authorization: Bearer $HASS_REST" \
     'entity_id=light.hue_bulb_office'
 ```
 
 **Output**
 
 ```powershell
 HTTP/1.1 200 OK
Content-Encoding: deflate
Content-Length: 277
Content-Type: application/json
Date: Mon, 06 Dec 2021 22:17:06 GMT
Server: Python/3.9 aiohttp/3.7.4.post0

[
    {
        "attributes": {
            "friendly_name": "Office Ceiling",
            "max_mireds": 454,
            "min_mireds": 153,
            "supported_color_modes": [
                "color_temp"
            ],
            "supported_features": 43
        },
        "context": {
            "id": "1b2f8d40c8cdcaafe60e1eec4ea13d19",
            "parent_id": null,
            "user_id": "9cb3b341377e4c759007eb27c2ad5dc2"
        },
        "entity_id": "light.hue_bulb_office",
        "last_changed": "2021-12-06T22:17:06.319723+00:00",
        "last_updated": "2021-12-06T22:17:06.319723+00:00",
        "state": "off"
    }
]
 ```

## Conclusion

That's the rough version of how to incorporate a password manager into your daily life without spamming secure keys across all your environments.

A lot has been left to the reader (any me), a few things on my to-do list are:

- Create both PowerShell and bash scripts
- Write a script to clear variables and log out
- Stash the scripts in a public Github repo to make it easier to bootstrap a new machine

Have fun and stay secure!
