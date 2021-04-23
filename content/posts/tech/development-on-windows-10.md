# Welcome

- Windows 10-centric focusing on dual development between Ubuntu and Windows
- Opinionated install locations, versions, and workflow
- Installation of all repros needed to run a local dev environment
- Written to be both concise and informative for the developer new to Linux
- Citing of helpful external pages

## Opinionated Setup

- Source is cloned into a root source folder, `spare5`, that's shared between Windows and Ubuntu
    - Windows - `C:\Users\shawn\spare5`
    - Ubuntu - `~/spare5`
- Visual Studio Code is used to edit source files in Windows
- Git is configured to auto adjust line-endings and prune deleted remote branches on pull
- Ubuntu system and environment config is handled in `~/.profile` (vs `~/.bash_profile`)
    - WSL Ubuntu 18.04 install includes a useful and working `.profile` which is why I picked it
    - if instructed to update `.bash_profile` or if asked to pick between the two go with `.profile`, because...
    - if a `.bash_profile` is also present `.profile` WON'T run so pick one, be consistent, delete the other

## Conventions

- Steps are split by framework and repro for easier processing
  - Steps build on each other, follow them in order
  - Don't move on to the next one if there are any errors/concerns
- Replace `shawn` with your username
- `$` mean "run from the Ubuntu prompt"
- `$` commands followed by non-dollar signed lines represent the output of that command
- Text between `<` and `>` are what to do in response to prompts
- `nano` is an easy editor for people new to Linux wondering how to edit files

## Install

### Frameworks and Tooling

1. [Ubuntu](https://github.com/spare5/tam-life/wiki/Ubuntu)
1. [Git](https://github.com/spare5/tam-life/wiki/Git)
1. [Node and NPM](https://github.com/spare5/tam-life/wiki/Node-and-NPM)
1. [Python 3.x](https://github.com/spare5/tam-life/wiki/Python-3.x)
1. [Ruby](https://github.com/spare5/tam-life/wiki/Ruby)
1. [Redis](https://github.com/spare5/tam-life/wiki/Redis)
1. [PostgresSQL](https://github.com/spare5/tam-life/wiki/PostgreSQL)
1. [AWS-CLI](https://github.com/spare5/tam-life/wiki/AWS-CLI)

### Database

1. [Database](https://github.com/spare5/tam-life/wiki/Setup-the-Database)

### Source

1. [spare5-web](https://github.com/spare5/tam-life/wiki/Source:-spare5_web)
1. [media_prelude](https://github.com/spare5/tam-life/wiki/Source:-media_prelude)
1. [spare5_image_server](https://github.com/spare5/tam-life/wiki/Source:-spare5_image_server)
1. [web-ux](https://github.com/spare5/tam-life/wiki/Source:-web_ux)
1. [tam.py](https://github.com/spare5/tam-life/wiki/tam.py)

### Putting It All Together

1. [Run All The Things](https://github.com/spare5/tam-life/wiki/Run-All-The-Things)

### Tips

1. [For Ubuntu](https://github.com/spare5/tam-life/wiki/Ubuntu-Tips)
1. [For Windows](https://github.com/spare5/tam-life/wiki/Windows-Tips)
1. [Visual Studio Code](https://github.com/spare5/tam-life/wiki/Setting-up-Visual-Studio-Code-with-Ruby)