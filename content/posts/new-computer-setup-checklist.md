---
title: New Computer Setup Checklist
date: '2022-04-10'
categories:
  - tech
tags:
  - setup
draft: false
lastmod: '2022-12-14'
---

# New Computer Setup Checklist

The tools and customizations I like across all my machines in one handy place.

## Windows

Apps are listed in the order I prefer to install them, starting right up front with my password manager to make everything else easier.

### General Utilities

- [1Password](https://1password.com/downloads/windows/)
- [1Password CLI](https://developer.1password.com/docs/cli/get-started)
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
- [volta](https://volta.sh/)

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
winget install 1password-cli
winget install Microsoft.PowerToys
winget install voidtools.Everything
winget install Wox.Wox
```

## Configurations

### Environment Variables

```powershell
SOURCE_ROOT=C:\Users\monoc\Dropbox\source
```

### Git Configuration

```powershell
# set default main branch to `main`
git config --global init.defaultBranch main

# Set user information
git config --global user.name "Shawn Oster"
git config --global user.email "shawn.oster@gmail.com"
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
# PowerShell settings
#
# 1. Open profile settings with `code $PROFILE`
# 2. Paste everything
# 3. Reload shell with `. $PROFILE`
#
using namespace System.Management.Automation
using namespace System.Management.Automation.Language

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

# Tab-completion for 1Password
op completion powershell | Out-String | Invoke-Expression

# volta tab-completion
Register-ArgumentCompleter -Native -CommandName 'volta' -ScriptBlock {
    param($wordToComplete, $commandAst, $cursorPosition)

    $commandElements = $commandAst.CommandElements
    $command = @(
        'volta'
        for ($i = 1; $i -lt $commandElements.Count; $i++) {
            $element = $commandElements[$i]
            if ($element -isnot [StringConstantExpressionAst] -or
                $element.StringConstantType -ne [StringConstantType]::BareWord -or
                $element.Value.StartsWith('-')) {
                break
        }
        $element.Value
    }) -join ';'

    $completions = @(switch ($command) {
        'volta' {
            [CompletionResult]::new('--verbose', 'verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
            [CompletionResult]::new('--quiet', 'quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
            [CompletionResult]::new('-v', 'v', [CompletionResultType]::ParameterName, 'Prints the current version of Volta')
            [CompletionResult]::new('--version', 'version', [CompletionResultType]::ParameterName, 'Prints the current version of Volta')
            [CompletionResult]::new('-h', 'h', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('--help', 'help', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('fetch', 'fetch', [CompletionResultType]::ParameterValue, 'Fetches a tool to the local machine')
            [CompletionResult]::new('install', 'install', [CompletionResultType]::ParameterValue, 'Installs a tool in your toolchain')
            [CompletionResult]::new('uninstall', 'uninstall', [CompletionResultType]::ParameterValue, 'Uninstalls a tool from your toolchain')
            [CompletionResult]::new('pin', 'pin', [CompletionResultType]::ParameterValue, 'Pins your project''s runtime or package manager')
            [CompletionResult]::new('list', 'list', [CompletionResultType]::ParameterValue, 'Displays the current toolchain')
            [CompletionResult]::new('completions', 'completions', [CompletionResultType]::ParameterValue, 'Generates Volta completions')
            [CompletionResult]::new('which', 'which', [CompletionResultType]::ParameterValue, 'Locates the actual binary that will be called by Volta')
            [CompletionResult]::new('use', 'use', [CompletionResultType]::ParameterValue, 'use')
            [CompletionResult]::new('setup', 'setup', [CompletionResultType]::ParameterValue, 'Enables Volta for the current user / shell')
            [CompletionResult]::new('run', 'run', [CompletionResultType]::ParameterValue, 'Run a command with custom Node, npm, pnpm, and/or Yarn versions')
            [CompletionResult]::new('help', 'help', [CompletionResultType]::ParameterValue, 'Prints this message or the help of the given subcommand(s)')
            break
        }
        'volta;fetch' {
            [CompletionResult]::new('-h', 'h', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('--help', 'help', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('-V', 'V', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--version', 'version', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--verbose', 'verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
            [CompletionResult]::new('--quiet', 'quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
            break
        }
        'volta;install' {
            [CompletionResult]::new('-h', 'h', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('--help', 'help', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('-V', 'V', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--version', 'version', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--verbose', 'verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
            [CompletionResult]::new('--quiet', 'quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
            break
        }
        'volta;uninstall' {
            [CompletionResult]::new('-h', 'h', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('--help', 'help', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('-V', 'V', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--version', 'version', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--verbose', 'verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
            [CompletionResult]::new('--quiet', 'quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
            break
        }
        'volta;pin' {
            [CompletionResult]::new('-h', 'h', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('--help', 'help', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('-V', 'V', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--version', 'version', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--verbose', 'verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
            [CompletionResult]::new('--quiet', 'quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
            break
        }
        'volta;list' {
            [CompletionResult]::new('--format', 'format', [CompletionResultType]::ParameterName, 'Specify the output format')
            [CompletionResult]::new('-c', 'c', [CompletionResultType]::ParameterName, 'Show the currently-active tool(s)')
            [CompletionResult]::new('--current', 'current', [CompletionResultType]::ParameterName, 'Show the currently-active tool(s)')
            [CompletionResult]::new('-d', 'd', [CompletionResultType]::ParameterName, 'Show your default tool(s).')
            [CompletionResult]::new('--default', 'default', [CompletionResultType]::ParameterName, 'Show your default tool(s).')
            [CompletionResult]::new('-h', 'h', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('--help', 'help', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('-V', 'V', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--version', 'version', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--verbose', 'verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
            [CompletionResult]::new('--quiet', 'quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
            break
        }
        'volta;completions' {
            [CompletionResult]::new('-o', 'o', [CompletionResultType]::ParameterName, 'File to write generated completions to')
            [CompletionResult]::new('--output', 'output', [CompletionResultType]::ParameterName, 'File to write generated completions to')
            [CompletionResult]::new('-f', 'f', [CompletionResultType]::ParameterName, 'Write over an existing file, if any.')
            [CompletionResult]::new('--force', 'force', [CompletionResultType]::ParameterName, 'Write over an existing file, if any.')
            [CompletionResult]::new('-h', 'h', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('--help', 'help', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('-V', 'V', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--version', 'version', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--verbose', 'verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
            [CompletionResult]::new('--quiet', 'quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
            break
        }
        'volta;which' {
            [CompletionResult]::new('-h', 'h', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('--help', 'help', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('-V', 'V', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--version', 'version', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--verbose', 'verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
            [CompletionResult]::new('--quiet', 'quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
            break
        }
        'volta;use' {
            [CompletionResult]::new('-h', 'h', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('--help', 'help', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('-V', 'V', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--version', 'version', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--verbose', 'verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
            [CompletionResult]::new('--quiet', 'quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
            break
        }
        'volta;setup' {
            [CompletionResult]::new('-h', 'h', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('--help', 'help', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('-V', 'V', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--version', 'version', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--verbose', 'verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
            [CompletionResult]::new('--quiet', 'quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
            break
        }
        'volta;run' {
            [CompletionResult]::new('--node', 'node', [CompletionResultType]::ParameterName, 'Set the custom Node version')
            [CompletionResult]::new('--npm', 'npm', [CompletionResultType]::ParameterName, 'Set the custom npm version')
            [CompletionResult]::new('--pnpm', 'pnpm', [CompletionResultType]::ParameterName, 'Set the custon pnpm version')
            [CompletionResult]::new('--yarn', 'yarn', [CompletionResultType]::ParameterName, 'Set the custom Yarn version')
            [CompletionResult]::new('--env', 'env', [CompletionResultType]::ParameterName, 'Set an environment variable (can be used multiple times)')
            [CompletionResult]::new('--bundled-npm', 'bundled-npm', [CompletionResultType]::ParameterName, 'Forces npm to be the version bundled with Node')
            [CompletionResult]::new('--no-pnpm', 'no-pnpm', [CompletionResultType]::ParameterName, 'Disables pnpm')
            [CompletionResult]::new('--no-yarn', 'no-yarn', [CompletionResultType]::ParameterName, 'Disables Yarn')
            [CompletionResult]::new('-h', 'h', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('--help', 'help', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('-V', 'V', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--version', 'version', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--verbose', 'verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
            [CompletionResult]::new('--quiet', 'quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
            break
        }
        'volta;help' {
            [CompletionResult]::new('-h', 'h', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('--help', 'help', [CompletionResultType]::ParameterName, 'Prints help information')
            [CompletionResult]::new('-V', 'V', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--version', 'version', [CompletionResultType]::ParameterName, 'Prints version information')
            [CompletionResult]::new('--verbose', 'verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
            [CompletionResult]::new('--quiet', 'quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
            break
        }
    })

    $completions.Where{ $_.CompletionText -like "$wordToComplete*" } |
        Sort-Object -Property ListItemText
}

#
# Aliases to common directories
#

# S is for Source
# Root directory for all source code (make sure to set SOURCE_ROOT)
function cds { Set-Location $env:SOURCE_ROOT }

# 1Password-secured Accounts
#
# IDs are meaningless without the password and thus safe for plaintext
function secure-groot { Set-Location (Join-Path $env:SOURCE_ROOT groot); op run --account my.1password.com --env-file=.\app.env -- code . }
function secure-wonka { Set-Location (Join-Path $env:SOURCE_ROOT wonka); op run --account guild-education.1password.com --env-file=.\wonka\app.env -- code . }
```
