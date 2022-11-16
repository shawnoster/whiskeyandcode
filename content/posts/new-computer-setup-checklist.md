---
title: New Computer Setup Checklist
date: '2022-04-10'
categories:
  - tech
tags:
  - setup
draft: false
lastmod: '2022-04-10'
---

# New Computer Setup Checklist

The tools and customizations I like across all my machines in one handy place.

## Windows

Apps are listed in the order I prefer to install them, starting right up front with my password manager to make everything else easier.

### General Utilities

- [1Password](https://1password.com/downloads/windows/)
- [Everything](https://www.voidtools.com/) (needed for Wox)
- [Python 3](https://www.python.org/downloads/) (needed for Wox)
- [Wox Launcher](https://github.com/Wox-launcher/Wox/releases)

### Editors

- [Visual Studio Code](https://code.visualstudio.com/) (makes editing profile easier via `code $PROFILE`)
- [Caskaydia Cove Nerd Font](https://www.nerdfonts.com/font-downloads) (needed for Oh My Posh)

### CLI

- [Latest PowerShell](https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell-on-windows?view=powershell-7.2)
- [Windows Terminal](https://www.microsoft.com/en-US/p/windows-terminal/9n0dx20hk701?activetab=pivot:overviewtab) (if not already installed)
- [winget](https://docs.microsoft.com/en-us/windows/package-manager/winget/) (if not already installed)
- [Oh My Posh](https://ohmyposh.dev/)
- [jq](https://stedolan.github.io/jq/download/)
- [httpie](https://httpie.io/)
- [git](https://git-scm.com/download/win)

### WSL

Default Ubuntu, from a PowerShell terminal prompt:

```powershell
wsl --install
```

## Winget Installs

Tools installable via `winget`

```powershell
winget install JanDeDobbeleer.OhMyPosh -s winget
winget install stedolan.jq
winget install Git.Git
```

## Configurations

### Git Configuration

```powershell
# set default main branch to `main`
git config --global init.defaultBranch main
```

### Visual Studio Code

#### Extensions

- [GitHub Repositories](https://marketplace.visualstudio.com/items?itemName=GitHub.remotehub) - _Remotely browse and edit any GitHub repository_
- [Rainbow CSV](https://marketplace.visualstudio.com/items?itemName=mechatroner.rainbow-csv) - _Highlight CSV and TSV files, Run SQL-like queries_
- [Remote Repositories](https://marketplace.visualstudio.com/items?itemName=ms-vscode.remote-repositories) - _Remotely browse and edit git repositories_

#### Themes

- [Chandrian](https://marketplace.visualstudio.com/items?itemName=narenranjit.chandrian) - _a semantic syntax highlighting theme_

### Wox Configuration

- Theme | BlurBlack
- Plugin | Web Search | Change `duckduckgo` to `d` for faster typing

### PowerShell Profile

```powershell
#
# Shawn Oster's PowerShell settings
#
# 1. Open profile settings with `code $PROFILE`
# 2. Paste everything
# 3. Reload shell with `. $PROFILE`
#

# Set Oh My Posh prompt
#
# Quick install on Windows with winget: winget install "JanDeDobbeleer.OhMyPosh"
# Full instructions on offical site: https://ohmyposh.dev/docs/
oh-my-posh --init --shell pwsh --config $env:POSH_THEMES_PATH\space.omp.json | Invoke-Expression

# Tab-completion for winget
#
# winget is available in newer versions of Windows
Register-ArgumentCompleter -Native -CommandName winget -ScriptBlock {
    param($wordToComplete, $commandAst, $cursorPosition)
        [Console]::InputEncoding = [Console]::OutputEncoding = $OutputEncoding = [System.Text.Utf8Encoding]::new()
        $Local:word = $wordToComplete.Replace('"', '""')
        $Local:ast = $commandAst.ToString().Replace('"', '""')
        winget complete --word="$Local:word" --commandline "$Local:ast" --position $cursorPosition | ForEach-Object {
            [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_)
        }
}

# Tab-completion for dotnet CLI
#
# https://docs.microsoft.com/en-us/dotnet/core/tools/enable-tab-autocomplete
Register-ArgumentCompleter -Native -CommandName dotnet -ScriptBlock {
    param($commandName, $wordToComplete, $cursorPosition)
        dotnet complete --position $cursorPosition "$wordToComplete" | ForEach-Object {
           [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_)
        }
}

# Aliases to common directories

# R is for repo
# Root directory for all source code
function cdr { Set-Location $env:HOMEPATH\Dropbox\source }
```
