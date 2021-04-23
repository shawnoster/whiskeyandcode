---
title: "AWS CLI"
date: "2021-04-22T20:28:40-07:00"
tags: ["aws", "tech"]
categories: ["tech"]
showFullContent: false
draft: false
---

# AWS CLI

## What To Know

- You need your AWS access key, secret access key and MFA device token
- `awscli` is the Amazon command line, mostly used to get the urls of thousands of images
- `aws-mfa` helps with the whole MFA/2-Factor tango

## Install

1. Install `awscli` & `aws-mfa`

   ```bash
   $ pip3.7 install awscli --upgrade --user
   $ pip3.7 install aws-mfa --upgrade --user
   ```

1. Configure AWS
 
   If you've never configured AWS CLI on your machine make sure you have your AWS keys and then do the following:

   ```bash
   $ aws configure
   AWS Access Key ID [None]: #<ask #infrastructure in Slack>
   AWS Secret Access Key [None]: #<ask #infrastructure in Slack>
   Default region name [None]: #<Enter to take the default>
   Default output format [None]: #<Enter to take the default>
   ```

   The other option is you've already configured the AWS CLI in Windows and can copy your config.

   ```bash
   $ mkdir ~/.aws
   $ cp /mnt/c/Users/Shawn/.aws/* ~/.aws
   ```

1. Configure Two-Factor Authentication (MFA/2FA). Edit `~/.aws/credentials`

   ```bash
   # 1. rename [default] to be [default-long-term]
   # 2. add your aws_mfa_device
   # 3. save and exit
   # 
   # it should look like this
   [default-long-term]                                                                                                                                                                 
   aws_access_key_id = <whatever was there>
   aws_secret_access_key = <whatever was there>
   aws_mfa_device = #<looks like arn:aws:iam::111111111111:mfa/shawn>
   ```

1. Refresh your MFA token

   ```bash
   $ aws-mfa
   INFO - Validating credentials for profile: default
   INFO - Short term credentials section default is missing, obtaining new credentials.
   Enter AWS MFA code for device [arn:aws:iam::111111111111:mfa/shawn] (renewing for 43200 seconds): #<however you get your 2FA tokens, do it now>
   ```

1. Test it

   ```bash
   $ aws s3 ls
   ```

   If you see a long scrolling list of files and folders everything is good. If you don't, cut a ticket.

## Using 2FA aws-cli

```bash
aws sts get-session-token --serial-number arn-of-the-mfa-device --token-code code-from-token

set AWS_ACCESS_KEY_ID=<Access-Key-as-in-Previous-Output>
set AWS_SECRET_ACCESS_KEY=<Secret-Access-Key-as-in-Previous-Output>
set AWS_SESSION_TOKEN=<Session-Token-as-in-Previous-Output>
```   

## Notes And Stuff

These steps are cobbled together from:

- [Install the AWS Command Line Interface on Linux](https://docs.aws.amazon.com/cli/latest/userguide/awscli-install-linux.html)
- [aws-mfa: Easily manage your AWS Security Credentials when using Multi-Factor Authentication (MFA)](https://github.com/broamski/aws-mfa)
