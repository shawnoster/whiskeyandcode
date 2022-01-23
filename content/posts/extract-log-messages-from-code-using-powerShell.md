---
title: Extract Log Messages from Code using PowerShell
date: '2022-01-23'
tags:
    - code
    - csharp
draft: false
lastmod: '2022-01-23T22:23:22.580Z'
---

# Extract ILogger Messages from Code using PowerShell

A co-worker asked how to extract log message from code last week and while I would normally use `grep` I thought I'd improve my PowerShell skills since we use it for so many of our internal scripts at work.

Our code uses the C# [ILogger](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.ilogger?view=dotnet-plat-ext-6.0) pattern, with a `LogXxx()` method to Exception, Information, and Warning log events, with a GUID for unique code look-up, and a hopefully helpful log message.

## Get-ChildItems and Select-String

`Get-ChildItems` and `Select-String` are the backbone of most "search in some files for something" operations. Think Unix's `find` and `grep`.

My quick and dirty version is meant to be run in the root folder you're gather logs for and captures the filename, log level, GUID and message. I could wrap it into a nice function but... well, I didn't, mostly because it's Sunday and I'd like to jump back into "Destiny 2" for a bit 😄

```powershell
# get a list of all C# files in the current directory and below
# store the results in a variable to use later and to make the 
# code easier to read
$CodeFiles = Get-ChildItem -Recurse -Path . -File -Filter "*.cs"

# match our standard Log messages pattern, shove those results into another variable
$LogMessages = $CodeFiles | Select-String -Pattern 'Logger\.Log(.*)\(\"(.{36})\"[^\"]+\"([^\"]+)\"'

# build a temp table and for each log message found above shove the bits
# we care about into it
$table = foreach ($LogMessage in $LogMessages) {
    New-Object PSObject -Property @{
        Filename = $LogMessage.Filename
        LogLevel = $LogMessage.Matches.Groups[1].Value
        GUID = $LogMessage.Matches.Groups[2].Value
        Message = $LogMessage.Matches.Groups[3].Value
    }
}

# show the world the greatness
$table | Format-Table
```

And here's what the final output looks like:

```
Filename                             LogLevel  GUID                                 Message
--------                             --------  ----                                 -------
NotificationServiceInterceptor.cs    Exception AE4A8E78-A7A8-4C04-B005-C1A23C45B679 Can't do stuff
BusinessServiceBase.cs               Exception BCDAFE18-9000-0001-ABCD-4A4395F0D8BD Warning Will Robinson, Warning!
```

The most difficult thing was the usual learning curve in figuring out how to access the regex capture groups (the `GUID` and `Message` fields).

## Output to CSV

The table is pretty for the screen but less useful for importing into something like Excel. To dump it to a CSV do either either:

### To `stdout` (the terminal screen)

```powershell
$table | ConvertTo-Csv
```

### To a file

```powershell
$table | Export-Csv -Path ".\log-messages.csv"
```