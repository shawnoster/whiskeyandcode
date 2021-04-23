---
title: "Ubuntu"
date: "2021-04-22T20:28:40-07:00"
tags: ["ubuntu", "tech"]
categories: ["tech"]
showFullContent: false
draft: false
---

# Ubuntu

## Install

1. Update the system packages

    ```bash
    # think "Windows Update" for linux
    #
    # "sudo apt update" updates the list of system packages and their versions
    # "sudo apt full-upgrade" does the actual packages updates
    # "-y" saves having to press "Y" when asked to continue
    #
    # this will take awhile the first time...
    $ sudo apt update && sudo apt full-upgrade -y
    ```

1. Remove the Windows path from Ubuntu

   By default WSL appends the Windows path to the Ubuntu path, which I find weird and confusing when debugging path issues. I turn it off and suggest you do as well. You need to be on the very latest version of Windows 10, offered via Windows Update, for this to work:

    ```bash
    # edit /etc/wsl.conf, needs admin rights
    $ sudo nano /etc/wsl.conf
    ```

    Add the following

    ```bash
    [interop]
    enabled = false
    appendWindowsPath = false
    ```

    Sign-out or reboot Windows. Exiting out of Ubuntu and re-launching isn't enough for the settings to take.

1. Copy/create your SSH keys into `~/.ssh`

   If you don't have an SSH key follow these instructions [Generating a new SSH key and adding it to the ssh-agent](https://help.github.com/articles/generating-a-new-ssh-key-and-adding-it-to-the-ssh-agent/) which will create a new SSH key in `C:\Users\shawn\.ssh` that can be copied into Ubuntu.

    ```bash
    # assumes an existing SSH key in Windows C:\Users\shawn\.ssh
    $ mkdir .ssh
    $ cp /mnt/c/Users/shawn/.ssh/id* ~/.ssh/
    ```

1. Add the following lines to `~/.ssh/config`

    ```bash
    Host *.spare5.com
    User ubuntu
    IdentityFile ~/.ssh/id_rsa
    ForwardAgent yes
    ServerAliveInterval 240
    ServerAliveCountMax 2
    ```

    Save the file and exit back to the prompt.

1. Set permissions

   ```bash
   $ chmod 600 ~/.ssh/config
   $ chmod 400 ~/.ssh/id_rsa
   ```

1. Start `ssh-agent` automatically so you don't have enter your password every time. Paste the following into `~/.profile`

    ```bash
    env=~/.ssh/agent.env

    agent_load_env () { test -f "$env" && . "$env" >| /dev/null ; }

    agent_start () {
    (umask 077; ssh-agent >| "$env")
    . "$env" >| /dev/null ; }

    agent_load_env

    # agent_run_state: 0=agent running w/ key; 1=agent w/o key; 2= agent not running
    agent_run_state=$(ssh-add -l >| /dev/null 2>&1; echo $?)

    if [ ! "$SSH_AUTH_SOCK" ] || [ $agent_run_state = 2 ]; then
    agent_start
    ssh-add
    elif [ "$SSH_AUTH_SOCK" ] && [ $agent_run_state = 1 ]; then
    ssh-add
    fi

    unset env
    ```

## Tips

### Keep Ubuntu updated

Keep system packages up-to-date (think Windows Update, but manual). I do this a few times a week out of old-habits but most will be fine doing it when they remember, when told or right before installing anything else via `sudo apt`, which most install pages have as a first step.

   ```bash
   # sudo apt update refreshes the list of available system packages
   # sudo apt full-upgrade does the actual update
   # -y means "Yes, don't ask me again, just do it"
   $ sudo apt update && sudo apt full-upgrade -y
   ```

### Create symbolic links for common Windows folders

Windows folders are accessible to Ubuntu via `/mnt/c`, where `c` is your C: drive. This is awesome since it means you can use your favorite Windows and Ubuntu tools on the same file. It's less awesome to have to type the monster paths a dozen times.

   ```bash
   # I use a scratch folder to do quick temp work on exports and try out ideas.
   # Mine is Downloads, Desktop is also common and the truly organized often create
   # a separate "scratch" folder. You do you.
   $ ln -s /mnt/c/Users/shawn/Downloads/ /home/shawn/downloads

   # a lot of data ingestion and delivery happens out of Dropbox
   $ ln -s /mnt/c/Users/Shawn/Dropbox\ \(Mighty\ AI\)/Spare5\ Customer\ Success/ /home/shawn/customers
   ```

   See it in action by changing into your new folders

   ```bash
   $ cd ~/downloads
   $ cd ~/customers
   ```

### Add a token as an environment variable

Calls to scripts often require an API token. I store it as an environment variable to save on copy/pasting. If you don't have a token yet ask someone in #dev to get you one.

Add the following to `~/.profile`

```bash
# Some API key, Personal Access Token, etc.
export SOME_API_TOKEN=<your API token, looks something like XXX:YYY>
```

Save it, reload the shell:

```bash
$ source ~/.profile
```

Check that it stuck

```bash
# env displays all your environment variables
# | (pipe) means send the output to another program
# grep searches for substrings, in this case any line
# containing MIGHTY, such as our new env var
#
$ env | grep SOME_API
SOME_API_TOKEN=XXX:YYY
```

Using it

```bash
$ script --key $SOME_API_TOKEN ...
```

### tmux mouse-support

Add the following to `~/.tmux.conf`

```bash
# Mouse support
set -g mouse  on
```

### Better .dircolors

```bash
$ wget https://raw.githubusercontent.com/seebi/dircolors-solarized/master/dircolors.256dark -o .dircolors
$ source ~/.profile
```

### minimal prompt

```bash
export CLICOLOR=1
PS1='\[\033[37m\]\W\[\033[0m\]$(__git_ps1 " (\[\033[35m\]%s\[\033[0m\])") \$ '
GIT_PS1_SHOWDIRTYSTATE=1
GIT_PS1_SHOWSTASHSTATE=1
GIT_PS1_SHOWUNTRACKEDFILES=1
GIT_PS1_SHOWUPSTREAM="auto"
```

### Constrain memory usage

https://medium.com/@lewwybogus/how-to-stop-wsl2-from-hogging-all-your-ram-with-docker-d7846b9c5b37

### Add to C:\User\<You>\.wslconfig

```
[wsl2]
memory=4GB # Limits VM memory in WSL 2 to 4 GB
processors=5 # Makes the WSL 2 VM use two virtual processors
```

From a PowerShell admin account

```
Restart-Service LxssManager
```

# Docker

https://dev.to/bowmanjd/you-probably-don-t-need-systemd-on-wsl-windows-subsystem-for-linux-49gn
