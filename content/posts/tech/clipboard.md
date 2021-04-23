---
title: "Shawn's Wiki"
date: "2021-04-22T20:28:40-07:00"
tags: ["tech"]
showFullContent: false
draft: false
---

# Shawn's Wiki

## Ubuntu

### Create a non-root user with admin privileges

```bash
#add
adduser shawn

# verify
cat /etc/passwd

# make an admin
usermod -aG sudo shawn
```

### Rename machine

```bash
sudo nano /etc/hostname
sudo nano /etc/hosts
sudo reboot
```

### Enable passwordless authentication for the new user

On Ubuntu

```bash
ssh-keygen
ssh-copy-id shawn@192.168.1.148
```

Powershell

```powershell
ssh-keygen
type $env:USERPROFILE\.ssh\id_rsa.pub | ssh 192.168.1.148 "cat >> .ssh/authorized_keys"
```

### Update the OS (aka Windows Update for Ubuntu)

Contrary to the hype Linux isn't magic and needs just as much tending to as the next OS. That said the process is much more straightforward.

```bash
sudo apt update
sudo apt upgrade

# run update again to verify everything is current
sudo apt update
```

`apt-get` works as well but `apt` is the new hotness. Remember to run those commands once a week for an updated and shiny install.

### Copying ssh keys into Ubuntu

Assuming the keys have already been copied into your Windows `\User\Shawn\.ssh` folder. I store site specific ssh keys on a USB key that's strongly encrypted. It's not a perfect solution and I'll most likely move such keys into something like 1Password or a self-hosted BitWarden.

```bash
mkdir ~/.ssh
cp /mnt/c/Users/Shawn/.ssh/id* ~/.ssh/

# Set permissions
chmod 600 ~/.ssh/config
chmod 400 ~/.ssh/id_rsa

# edit your ssh config
nano ~/.ssh/config

# Add the following lines, save
Host *.some-site.com
User ubuntu
IdentityFile ~/.ssh/id_rsa
ForwardAgent yes
ServerAliveInterval 240
ServerAliveCountMax 2
```

## Command Line Tips

### Using Aliases to Save Key Strokes

If you can't be bothered to untrain the muscle memory of using the command line instead of PowerShell or bash then at least make your life a little easier by setting up some aliases for often typed commands.  There are mine:

```bash
@echo off

DOSKEY ls=dir
DOSKEY tam=python c:\tam\tam.py $*
DOSKEY pp=python -m json.tool $*
```

_Fun Fact_ The `$*` denotes that everything after the aliaes should be passed through.

### Load them every time

1. Create a bat or cmd file
2. Put all your doskey tricks in it
3. Create a shortcut for c:\windows\system32\cmd.exe
4. In the shortcut's properties change it to `c:\windows\system32\cmd.exe  /K "C:\Users\Shawn\Dropbox (Personal)\Tools\doskey-aliases.cmd"`
5. Change **Start In** to `%HOMEDRIVE%%HOMEPATH%`
6. Save, Run

### Images

In-place resize and do a lossless convert using ImageMagick

```
magick mogrify -resize 1920 -compress Lossless -format png *.png
magick mogrify -resize 1920 -compress Lossless -format png *.jpg
```

### JSON

Pretty-print (format) a JSON file from the command line:

```bash
python -m json.tool file.json > newfile.json
```

Download and convert at the same time:

```bash
curl http://my_url/ | python -m json.tool
```

Alias:

```bash
alias prettyjson='python -m json.tool'
```

Or

```bash
prettyjson_s() {
    echo "$1" | python -m json.tool
}

prettyjson_f() {
    python -m json.tool "$1"
}

prettyjson_w() {
    curl "$1" | python -m json.tool
}
# for all the above cases. You can put this in .bashrc and it will be available every time in shell. Invoke it like prettyjson_s '{"foo": "lorem", "bar": "ipsum"}'.
```

## Antsle

### Creating a virtual nic (Ubuntu)

1. Log into antlet

```bash
ssh 10.1.1.x
```

1. Figure out your other adapter

```bash
ip a
# or
ip addr show
```

1. Edit netplan configuration file

   ```bash
   sudo nano /etc/netplan/50-cloud-init.yaml
   ```

1. Add virtual nic

   ```yaml
   network:
     version: 2
     ethernets:
       eth0:
         dhcp4: true
       eth1:
         dhcp4: true
   ```

1. Apply changes

   ```
   sudo netplan apply
   ```

## Links

- https://docs.godotengine.org/en/stable/community/contributing/best_practices_for_engine_contributors.html
- https://neo4j.com
- https://www.gamedesigning.org/engines/unity-vs-godot/
- https://cloud.google.com/docs/ci-cd
- https://www.typescriptlang.org
- https://cli.github.com/

---

1306619437:AAFiHxYKldiqrCfGms6OyOOLS_nm2ZzmbrQ
https://api.telegram.org/bot1306619437:AAFiHxYKldiqrCfGms6OyOOLS_nm2ZzmbrQ/getUpdates
40064269

---

## Security

### Private DNS

- Trying out nextdns.io, not sure what it's about
