## Overview

### Notes

- Replace calls to `python`/`pip` with `python3.7` and `pip3.7`
- `python3.7` can be aliased to `python3` or `python` *but* I caution against confusing versions
- When using `pip` use `--user` to keep system and user packages separate

## Install on Ubuntu

### Add `--user` script directory to PATH

Packages installed via the `--user` flag are located in `.local/bin`, which isn't added to the PATH by default. Add the following to `~/.profile`:

```bash
# set PATH so it includes user's local bin
PATH="$HOME/$USER/.local/bin:$PATH"
```

After saving and exiting reload your environment with `source ~/.profile`

### Command-line completion

Not required but useful. Requires bash, zsh or fish, no love for Windows AFAIK.

```bash
$ pip3.7 completion --bash >> ~/.profile
$ source ~/.profile
```

### Update `pip`

The package manager `pip` is constantly being updated and it's always a good idea to update when prompted.

```bash
$ pip3.7 install --upgrade pip --user
```

### Verify

```bash
# back to home to verify path
$ cd ~

# verify the right version is installed
$ python3.7 --version
Python 3.7.2

# install the aws cli to test local/bin path
# you'll need this anyway so consider yourself
# ahead of the game
$ pip3.7 install awscli --upgrade --user
$ aws --version
aws-cli/1.16.142 Python/3.7.2 Linux/4.4.0-18362-Microsoft botocore/1.12.132
```

## Install on Windows

Needed for Visual Studio Code debugging, which invokes the Window's Python interpreter.

### Download and Run Installer

[Download the latest Windows x86-64 web-based installer](https://www.python.org/downloads/windows/) then run it using the following options:

   1. Select _"Customize installation"_
   1. "Optional Features", accept the default of everything checked
   1. "Advanced Options", keep the defaults plus:
      - check _"Add Python to environment variables"_
      - check _"Precompile standard library"_
   1. click _"Install"_

### Add user directory to PATH

Add your local path to Python to your user path

   1. `Win` - _View advanced system settings_
   1. click _Environment Variables_
   1. select `Path` under _User variables for ..._
   1. Edit -> New
   1. paste in `%APPDATA%\Python\Python37\Scripts`
   1. OK all the way out, restart any command prompts you had open