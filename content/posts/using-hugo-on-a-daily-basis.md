+++
title = "Using Hugo (a static site generator) on a Daily Basis"
date = "2021-07-12"
categories = ["Code"]
tags = ["Hugo"]
draft = false
+++

## Summary

A bunch of tools, heavily inspired by Christian Mohn's [My Hugo and Visual Studio Code Workflow](https://vninja.net/2020/02/12/my-hugo-workflow/), to streamline blogging via Hugo.

## Visual Studio Extensions

### Markdown Linting

David Anson's [vscode-markdownlist][markdownlist] helps keep your Markdown tidy and it plugs into the `Auto Fix...` command to quickly cleanup files.

### Paste Image

I agree with Mr. Mohn, [Paste Image][pasteimage] is a great Markdown image insertion extension. I use the default `/static` folder to store an `/images` sub-folder, with relative links in my Markdown.

```bash
# my Hugo image and post structure
/whiskeyandcode/content/posts
/whiskeyandcode/static/images
```

I define my paste settings in a VSCode workspace instead of User since these often change depending on the site.

```json
{
    "pasteImage.path": "${projectRoot}\\static\\images\\",
    "pasteImage.basePath": "${projectRoot}/static/images",
    "pasteImage.showFilePathConfirmInputBox": false,          # set to true for "debugging"
    "pasteImage.prefix": "/images/",
    "pasteImage.namePrefix": "${currentFileNameWithoutExt}_"
}
```

### Better TOML Front Matter Formatting

I prefer toml for it's concise, single-line array format. To get better toml front matter highlighting install [Better TOML][better-toml].

<!-- links -->
[markdownlist]: https://github.com/DavidAnson/vscode-markdownlint
[pasteimage]: https://github.com/mushanshitiancai/vscode-paste-image
[better-toml]: https://github.com/bungcip/better-toml
