# Configuration

## In Ubuntu

Nothing to install as `git` is part of the base Ubuntu 18.04 install. These are configuration options that will make you git-abulous!

```bash
# user config
$ git config --global user.name "Shawn Oster"
$ git config --global user.email shawn.oster@gmail.com

# set this to prune deleted remote branches on pull/fetch 
# unless you have a good reason to keep old branches around
$ git config --global remote.origin.prune true

# Windows uses CRLF, Ubuntu uses LF, this option
# makes sure if pushing a Windows file the line
# endings are converted to LF
$ git config --global core.autocrlf input
```

### Command-line completion

Add this to your `~/.bashrc`:

```bash
source /usr/share/bash-completion/completions/git
```

## In Windows

```bash
> git config --global core.autocrlf true
```