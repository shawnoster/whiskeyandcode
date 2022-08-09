---
title: "How to Love Markdown"
date: "2022-08-09"
categories:
- Best Practices
draft: false
---

# Markdown

## Overview

Welcome to a quick tour of Markdown, where it came from, why I love it, how to use it.

## What is Markdown?

[Many sites][fireball] offer a much better overview of what Markdown is but the tl;dr is Markdown is a markup DSL designed to be human-readable that can also be rendered into semantically correct XHTML.

_Readability, however, is emphasized above all else. A Markdown-formatted document should be publishable as-is, as plain text, without looking like it’s been marked up with tags or formatting instructions._

Due to its concise yet natural syntax and easy readability as plain-text it's become the defacto standard in most community forums (Reddit, StackOverflow), blogging and documentation platforms (Hugo, Jekyll, readthedocs.io), and of course every online wiki.

All modern editors support it some form, from syntax highlighting, live previews, and [linting][vscode-lint].

## Why I 💗 Markdown

I find great joy and beauty in tools that have been paired down to their simplest form, at an abstraction level that's not condescending, that's internally consistent, while remaining highly compossible.

### Spend more time editing, less time formatting

Most online rich-text/HTML editors inject massive amounts of garbage HTML, which I take personally. To the point where I'll spend hours cleaning up rarely referenced online wiki pages that were composed with an HTML editor. Sharepoint and Google Wiki I'm looking at you.

## A Tour via Tips

### Format w/ intent

One of my personal coding principles is never break your user's trust with UX inconsistences. I picked this up from the Windows Phone design studio and it's always stuck with me. Feature adoption drops significantly when a feature isn't consistent. 

When a user can't predict when and where a feature will work they'll start doubting it (_"What did I do wrong? It worked over there"_) then avoiding it (_"obviously I don't know how to use that feature so I'll just avoid it"_).

* pick a formatting style and stick with it
  * just as with code, consistency, even if you hate it, makes refactoring a sane option
  * pay special attention to inline code references, such as `CosmosDbFailover` and make sure all code references are formatted the same, otherwise cognitive pattern matching goes out the window
* common drift areas to watch for
  * mixing bullet style (either `*` or `-`, but pick one, `*` is more "standard")
  * forgetting the space between a heading hash and the first character, such as `#Title` compared to the correct `# Title`

### Don't fight the constraints, work with them

* trust in the content, not the formatting
* simplify the design instead of hacking around Markdown
* there is rarely a need to mix HTML elements in w/ Markdown
* layout the document knowing it'll be read in plain-text as much as rendered HTML  
* write for the content, not the render. If you can't make sense of the text until it's been rendered then the problem is probably with the content structure

### When stuck take inspiration from others

* it's common to know a layout isn't working well but not know why
* instead of adding more bold/italic/block quotes look for similar examples
* Github is a great go-to for inspiration

### Avoid too many call-outs

Call-outs in this context are those eyeball-grabbing points of interest, usually in the form of a bolded IMPORTANT, a block quoted pro-tip or helpful hint. Used sparingly they hold the line remarkably well. Add too many though and the message gets lost from the constant context switching. If everything is important then suddenly nothing is important.

If more than "some percentage" of a document is call-outs the issue is often one of mixing tones or intent, such as shifting between exposition, extemporization, and detailed steps. The shift back and forth becomes a siren song for call-outs. 

Depending on the intent it's better to pick a single tone or group similar tones together.

For install steps it's especially important to keep everything concise and to keep the chatter to a minimum. Reducing each step to basics gives the impression that everything in the list is critical without having to tag every other step with a call-out.

### Code

Representing code in Markdown has so little overhead while offering so much value, that I often take it as a personal affront when not used.

#### Code Blocks

Use triple ticks to demarcate multi-line code blocks.

```json
{
    "userId": "1234-ABCD-9876-DCBA"
}
```

Tell Markdown what language to use for syntax highlighting

```powershell
# Convert Date and Time To UTC Time
$a = Get-Date
$a.ToUniversalTime()
```

#### Inline Code References

* code can be inline, such as _"class `Zuul` has a dependency on `GateKeeper`"_.
* even minimal syntax highlighting makes a huge difference

### General

Tips that didn't play well with the other groups, but I think are important.

* Use emoji, but with intent, and with purpose
* Don't be scared of white-space
  * space between hash and text
  * CRLF between headers
* Think in terms of outline/TOC  
* Use citation references for link-heavy documents
* Don't worry about ordered list numbering
  1. this
  1. much better
  1. works
* Take the extra minute to do look up how to do something

## Useful Links

Links to things mentioned or hinted.

* [Daring Fireball - Markdown Reference][fireball]
* [Daring Fireball - Dingus][dingus] - an online Markdown playground
* [David Anson's Markdown Linter for VSCode][vscode-lint]
* [Hugo Open-Source Static Site Generator][hugo]
* [Jekyell Static Site Generator][jekyell]

[fireball]: https://daringfireball.net/projects/markdown/ "Daring Fireball"
[dingus]: https://daringfireball.net/projects/markdown/dingus "Dingus"
[vscode-lint]: https://github.com/DavidAnson/vscode-markdownlint "David Anson's VSCode Markdown linter"
[hugo]: https://gohugo.io/ "Hugo"
[jekyell]: https://jekyllrb.com/ "Jekyell Static Site Generator"
