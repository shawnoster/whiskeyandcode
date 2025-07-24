---
title: New Computer Setup Checklist
date: '2022-04-10'
categories:
  - tech
tags:
  - setup
draft: false
lastmod: '2025-07-23'
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

```
# Nerd Fonts, call after installing Oh My Posh
oh-my-posh font install
```

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
winget install jqlang.jq
winget install Git.Git
winget install 1password-cli
winget install Microsoft.PowerToys
winget install voidtools.Everything
winget install Wox.Wox
winget install Volta.Volta
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
# Shawn Oster's PowerShell settings
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

#
# Tab-completion
#

# 1Password CLI
op completion powershell | Out-String | Invoke-Expression

# AWS CLI
Register-ArgumentCompleter -Native -CommandName aws -ScriptBlock {
    param($commandName, $wordToComplete, $cursorPosition)
    $env:COMP_LINE = $wordToComplete
    if ($env:COMP_LINE.Length -lt $cursorPosition) {
        $env:COMP_LINE = $env:COMP_LINE + " "
    }
    $env:COMP_POINT = $cursorPosition
    aws_completer.exe | ForEach-Object {
        [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_)
    }
    Remove-Item Env:\COMP_LINE
    Remove-Item Env:\COMP_POINT
}

# dotnet CLI
#
# https://docs.microsoft.com/en-us/dotnet/core/tools/enable-tab-autocomplete
Register-ArgumentCompleter -Native -CommandName dotnet -ScriptBlock {
    param($commandName, $wordToComplete, $cursorPosition)
    dotnet complete --position $cursorPosition "$wordToComplete" | ForEach-Object {
        [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_)
    }
}

# winget
Register-ArgumentCompleter -Native -CommandName winget -ScriptBlock {
    param($wordToComplete, $commandAst, $cursorPosition)
    [Console]::InputEncoding = [Console]::OutputEncoding = $OutputEncoding = [System.Text.Utf8Encoding]::new()
    $Local:word = $wordToComplete.Replace('"', '""')
    $Local:ast = $commandAst.ToString().Replace('"', '""')
    winget complete --word="$Local:word" --commandline "$Local:ast" --position $cursorPosition | ForEach-Object {
        [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_)
    }
}

# volta
#
# generate with `volta completions powershell`
Register-ArgumentCompleter -Native -CommandName 'volta' -ScriptBlock {
    param($wordToComplete, $commandAst, $cursorPosition)

    $commandElements = $commandAst.CommandElements
    $command = @(
        'volta'
        for ($i = 1; $i -lt $commandElements.Count; $i++) {
            $element = $commandElements[$i]
            if ($element -isnot [StringConstantExpressionAst] -or
                $element.StringConstantType -ne [StringConstantType]::BareWord -or
                $element.Value.StartsWith('-') -or
                $element.Value -eq $wordToComplete) {
                break
            }
            $element.Value
        }) -join ';'

    $completions = @(switch ($command) {
            'volta' {
                [CompletionResult]::new('--verbose', '--verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
                [CompletionResult]::new('--very-verbose', '--very-verbose', [CompletionResultType]::ParameterName, 'Enables trace-level diagnostics')
                [CompletionResult]::new('--quiet', '--quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
                [CompletionResult]::new('-v', '-v', [CompletionResultType]::ParameterName, 'Prints the current version of Volta')
                [CompletionResult]::new('--version', '--version', [CompletionResultType]::ParameterName, 'Prints the current version of Volta')
                [CompletionResult]::new('-h', '-h', [CompletionResultType]::ParameterName, 'Print help (see more with ''--help'')')
                [CompletionResult]::new('--help', '--help', [CompletionResultType]::ParameterName, 'Print help (see more with ''--help'')')
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
                [CompletionResult]::new('help', 'help', [CompletionResultType]::ParameterValue, 'Print this message or the help of the given subcommand(s)')
                break
            }
            'volta;fetch' {
                [CompletionResult]::new('--verbose', '--verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
                [CompletionResult]::new('--very-verbose', '--very-verbose', [CompletionResultType]::ParameterName, 'Enables trace-level diagnostics')
                [CompletionResult]::new('--quiet', '--quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
                [CompletionResult]::new('-h', '-h', [CompletionResultType]::ParameterName, 'Print help')
                [CompletionResult]::new('--help', '--help', [CompletionResultType]::ParameterName, 'Print help')
                break
            }
            'volta;install' {
                [CompletionResult]::new('--verbose', '--verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
                [CompletionResult]::new('--very-verbose', '--very-verbose', [CompletionResultType]::ParameterName, 'Enables trace-level diagnostics')
                [CompletionResult]::new('--quiet', '--quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
                [CompletionResult]::new('-h', '-h', [CompletionResultType]::ParameterName, 'Print help')
                [CompletionResult]::new('--help', '--help', [CompletionResultType]::ParameterName, 'Print help')
                break
            }
            'volta;uninstall' {
                [CompletionResult]::new('--verbose', '--verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
                [CompletionResult]::new('--very-verbose', '--very-verbose', [CompletionResultType]::ParameterName, 'Enables trace-level diagnostics')
                [CompletionResult]::new('--quiet', '--quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
                [CompletionResult]::new('-h', '-h', [CompletionResultType]::ParameterName, 'Print help')
                [CompletionResult]::new('--help', '--help', [CompletionResultType]::ParameterName, 'Print help')
                break
            }
            'volta;pin' {
                [CompletionResult]::new('--verbose', '--verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
                [CompletionResult]::new('--very-verbose', '--very-verbose', [CompletionResultType]::ParameterName, 'Enables trace-level diagnostics')
                [CompletionResult]::new('--quiet', '--quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
                [CompletionResult]::new('-h', '-h', [CompletionResultType]::ParameterName, 'Print help')
                [CompletionResult]::new('--help', '--help', [CompletionResultType]::ParameterName, 'Print help')
                break
            }
            'volta;list' {
                [CompletionResult]::new('--format', '--format', [CompletionResultType]::ParameterName, 'Specify the output format')
                [CompletionResult]::new('-c', '-c', [CompletionResultType]::ParameterName, 'Show the currently-active tool(s)')
                [CompletionResult]::new('--current', '--current', [CompletionResultType]::ParameterName, 'Show the currently-active tool(s)')
                [CompletionResult]::new('-d', '-d', [CompletionResultType]::ParameterName, 'Show your default tool(s)')
                [CompletionResult]::new('--default', '--default', [CompletionResultType]::ParameterName, 'Show your default tool(s)')
                [CompletionResult]::new('--verbose', '--verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
                [CompletionResult]::new('--very-verbose', '--very-verbose', [CompletionResultType]::ParameterName, 'Enables trace-level diagnostics')
                [CompletionResult]::new('--quiet', '--quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
                [CompletionResult]::new('-h', '-h', [CompletionResultType]::ParameterName, 'Print help (see more with ''--help'')')
                [CompletionResult]::new('--help', '--help', [CompletionResultType]::ParameterName, 'Print help (see more with ''--help'')')
                break
            }
            'volta;completions' {
                [CompletionResult]::new('-o', '-o', [CompletionResultType]::ParameterName, 'File to write generated completions to')
                [CompletionResult]::new('--output', '--output', [CompletionResultType]::ParameterName, 'File to write generated completions to')
                [CompletionResult]::new('-f', '-f', [CompletionResultType]::ParameterName, 'Write over an existing file, if any')
                [CompletionResult]::new('--force', '--force', [CompletionResultType]::ParameterName, 'Write over an existing file, if any')
                [CompletionResult]::new('--verbose', '--verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
                [CompletionResult]::new('--very-verbose', '--very-verbose', [CompletionResultType]::ParameterName, 'Enables trace-level diagnostics')
                [CompletionResult]::new('--quiet', '--quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
                [CompletionResult]::new('-h', '-h', [CompletionResultType]::ParameterName, 'Print help (see more with ''--help'')')
                [CompletionResult]::new('--help', '--help', [CompletionResultType]::ParameterName, 'Print help (see more with ''--help'')')
                break
            }
            'volta;which' {
                [CompletionResult]::new('--verbose', '--verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
                [CompletionResult]::new('--very-verbose', '--very-verbose', [CompletionResultType]::ParameterName, 'Enables trace-level diagnostics')
                [CompletionResult]::new('--quiet', '--quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
                [CompletionResult]::new('-h', '-h', [CompletionResultType]::ParameterName, 'Print help')
                [CompletionResult]::new('--help', '--help', [CompletionResultType]::ParameterName, 'Print help')
                break
            }
            'volta;use' {
                [CompletionResult]::new('--verbose', '--verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
                [CompletionResult]::new('--very-verbose', '--very-verbose', [CompletionResultType]::ParameterName, 'Enables trace-level diagnostics')
                [CompletionResult]::new('--quiet', '--quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
                [CompletionResult]::new('-h', '-h', [CompletionResultType]::ParameterName, 'Print help (see more with ''--help'')')
                [CompletionResult]::new('--help', '--help', [CompletionResultType]::ParameterName, 'Print help (see more with ''--help'')')
                break
            }
            'volta;setup' {
                [CompletionResult]::new('--verbose', '--verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
                [CompletionResult]::new('--very-verbose', '--very-verbose', [CompletionResultType]::ParameterName, 'Enables trace-level diagnostics')
                [CompletionResult]::new('--quiet', '--quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
                [CompletionResult]::new('-h', '-h', [CompletionResultType]::ParameterName, 'Print help')
                [CompletionResult]::new('--help', '--help', [CompletionResultType]::ParameterName, 'Print help')
                break
            }
            'volta;run' {
                [CompletionResult]::new('--node', '--node', [CompletionResultType]::ParameterName, 'Set the custom Node version')
                [CompletionResult]::new('--npm', '--npm', [CompletionResultType]::ParameterName, 'Set the custom npm version')
                [CompletionResult]::new('--pnpm', '--pnpm', [CompletionResultType]::ParameterName, 'Set the custon pnpm version')
                [CompletionResult]::new('--yarn', '--yarn', [CompletionResultType]::ParameterName, 'Set the custom Yarn version')
                [CompletionResult]::new('--env', '--env', [CompletionResultType]::ParameterName, 'Set an environment variable (can be used multiple times)')
                [CompletionResult]::new('--bundled-npm', '--bundled-npm', [CompletionResultType]::ParameterName, 'Forces npm to be the version bundled with Node')
                [CompletionResult]::new('--no-pnpm', '--no-pnpm', [CompletionResultType]::ParameterName, 'Disables pnpm')
                [CompletionResult]::new('--no-yarn', '--no-yarn', [CompletionResultType]::ParameterName, 'Disables Yarn')
                [CompletionResult]::new('--verbose', '--verbose', [CompletionResultType]::ParameterName, 'Enables verbose diagnostics')
                [CompletionResult]::new('--very-verbose', '--very-verbose', [CompletionResultType]::ParameterName, 'Enables trace-level diagnostics')
                [CompletionResult]::new('--quiet', '--quiet', [CompletionResultType]::ParameterName, 'Prevents unnecessary output')
                [CompletionResult]::new('-h', '-h', [CompletionResultType]::ParameterName, 'Print help')
                [CompletionResult]::new('--help', '--help', [CompletionResultType]::ParameterName, 'Print help')
                break
            }
            'volta;help' {
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
                [CompletionResult]::new('help', 'help', [CompletionResultType]::ParameterValue, 'Print this message or the help of the given subcommand(s)')
                break
            }
            'volta;help;fetch' {
                break
            }
            'volta;help;install' {
                break
            }
            'volta;help;uninstall' {
                break
            }
            'volta;help;pin' {
                break
            }
            'volta;help;list' {
                break
            }
            'volta;help;completions' {
                break
            }
            'volta;help;which' {
                break
            }
            'volta;help;use' {
                break
            }
            'volta;help;setup' {
                break
            }
            'volta;help;run' {
                break
            }
            'volta;help;help' {
                break
            }
        })

    $completions.Where{ $_.CompletionText -like "$wordToComplete*" } |
    Sort-Object -Property ListItemText
}

# winget
Register-ArgumentCompleter -Native -CommandName winget -ScriptBlock {
  param($wordToComplete, $commandAst, $cursorPosition)
  [Console]::InputEncoding = [Console]::OutputEncoding = $OutputEncoding = [System.Text.Utf8Encoding]::new()
  $Local:word = $wordToComplete.Replace('"', '""')
  $Local:ast = $commandAst.ToString().Replace('"', '""')
  winget complete --word="$Local:word" --commandline "$Local:ast" --position $cursorPosition | ForEach-Object {
    [System.Management.Automation.CompletionResult]::new($_, $_, 'ParameterValue', $_)
  }
}

#
# Aliases to common directories
#

# S is for Source
# Root directory for all source code (make sure to set SOURCE_ROOT)
function cds { Set-Location $env:SOURCE_ROOT }
function ss { sonar-scanner.bat -D"sonar.projectKey=$(Get-Location | Split-Path -Leaf)" -D"sonar.python.version=3" -D"sonar.sourceEncoding=UTF-8" }

#
# Environment variables
#
$Env:SOURCE_ROOT = E:
$Env:UV_CACHE_DIR = "E:\.uv"

# 1Password-secured Accounts
#
# IDs are meaningless without the password and thus safe for plaintext
function Set-SecureEnv {
  # Secure variables, pulled from 1Password
  $Env:GITHUB_TOKEN = op read --account guild-education "op://Employee/GitHub - Token - SQA local testing/credential"
  $Env:JF_API_KEY = op read --account guild-education "op://Engineering Tools - Prod/Jellyfish API Token/credential"
  $Env:JIRA_API_KEY = op read --account guild-education "op://Employee/sa-jinx-cli/credential"
  $Env:JIRA_API_USER = op read --account guild-education "op://Employee/sa-jinx-cli/username"
  $Env:JIRA_SERVER_URL = op read --account guild-education "op://Employee/sa-jinx-cli/server"
  $Env:NPM_TOKEN = op read --account guild-education "op://Employee/npm - token - Local CLI/credential"
  $Env:PACT_READONLY_PASSWORD = op read --account guild-education "op://Engineering Tools - Dev/Pact Broker - Readonly/password"
  $Env:SONAR_TOKEN = op read --account guild-education "op://Employee/SonarQube - Docker/token"
  $Env:DATADOG_API_KEY = op read --account guild-education "op://Employee/Datadog - API Key - Self-Serve Workflow/credential"
  $Env:DATADOG_APP_KEY = op read --account guild-education "op://Employee/Datadog - App Key - Self-Serve Script/credential"
}
function secure-groot { Set-Location (Join-Path $env:SOURCE_ROOT groot); op run --account my --env-file=.\app.env -- code . }
function secure-wonka { Set-Location (Join-Path $env:SOURCE_ROOT wonka); op run --account guild-education --env-file=.\wonka\app.env -- code . }

# AWS Profile Switcher
function Switch-AWSProfile {
  # Get all profiles
  $profiles = aws configure list-profiles

  if (-not $profiles) {
    Write-Host "No AWS profiles found." -ForegroundColor Red
    return
  }

  # Use fzf to select a profile
  $selectedProfile = $profiles | fzf --prompt="Select AWS Profile > "

  if ($selectedProfile) {
    $env:AWS_PROFILE = $selectedProfile
    Write-Host "✅ Switched to AWS profile: $env:AWS_PROFILE" -ForegroundColor Green
  }
  else {
    Write-Host "⚠️ No profile selected." -ForegroundColor Yellow
  }
}

# GitHub CLI
function Remove-MergedBranches {
  # Fetch latest changes and prune deleted remote branches
  git fetch --prune

  # Get current branch
  $currentBranch = git rev-parse --abbrev-ref HEAD

  # Get merged branches (excluding main/master and current)
  $mergedBranches = git branch --merged |
      ForEach-Object { $_.Trim() } |
      Where-Object {
          ($_ -ne "main") -and
          ($_ -ne "master") -and
          ($_ -ne $currentBranch) -and
          (-not $_.StartsWith("*"))
      }

  # Get remote branches
  $remoteBranches = git branch -r |
      ForEach-Object { $_.Trim().Replace("origin/", "") }

  # Filter merged branches that are deleted from the remote
  $branchesToDelete = $mergedBranches |
      Where-Object { $remoteBranches -notcontains $_ }

  # Delete the local branches
  foreach ($branch in $branchesToDelete) {
      Write-Host "Deleting local branch: $branch"
      git branch -d $branch
  }
}

# Makefile selector
function bake {
  # Check if Makefile exists in current directory
  if (Test-Path -Path "./Makefile") {
    # Extract make targets (rules) from the Makefile
    $targets = Get-Content "./Makefile" |
    Select-String -Pattern '^([a-zA-Z0-9][a-zA-Z0-9_-]*):' |
    ForEach-Object { $_.Matches.Groups[1].Value } |
    Sort-Object -Unique -CaseSensitive

    # Pipe targets into fzf
    $selected = $targets | fzf --prompt "Select Make target: "

    if ($selected) {
      # Run the make command
      $command = "make $selected"
      Write-Host "Running: $command"
      Invoke-Expression $command
    }
  }
  else {
    Write-Warning "No Makefile found in the current directory."
  }
}

# SonarQube
function ss { sonar-scanner.bat -D"sonar.projectKey=$(Get-Location | Split-Path -Leaf)" -D"sonar.python.version=3" -D"sonar.sourceEncoding=UTF-8" }

# Prompt
oh-my-posh init pwsh --config "$env:POSH_THEMES_PATH/amro.omp.json" | Invoke-Expression
Import-Module Terminal-Icons
if ($host.Name -eq 'ConsoleHost') {
  Import-Module PSReadLine
}
```
