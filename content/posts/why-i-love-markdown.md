---
title: "How to Love Markdown"
date: "2022-08-09"
categories:
- Code
tags:
- Markdown
- Best Practices
draft: false
---

# Markdown

## Overview

Welcome to a quick tour of Markdown, where it came from, why I love it, how to use it.

## What is Markdown?

The [official Daring Fireball site][fireball] offers a much better overview of what Markdown is. The short version is that Markdown is a markup domain-specific language (DSL) designed to be human-readable that can also be rendered into semantically correct XHTML.

The core tenet ripped straight from Daring Fireball:

> Readability, however, is emphasized above all else. A Markdown-formatted document should be publishable as-is, as plain text, without looking like it’s been marked up with tags or formatting instructions.

Due to its concise yet natural syntax and easy readability as plain text, it has become the de facto standard in most community forums (Reddit, StackOverflow), blogging and documentation platforms (Hugo, Jekyll, readthedocs.io), and every online wiki.

All modern editors support it some form, from syntax highlighting, live previews, and [linting][vscode-lint].

## Why learning Markdown is important

It is the **first thing** people see in any Github-hosted project, in the form of a `README.md`. Almost all developer documentation that will ever be written will be done in Markdown, and if it's not, it really, really should be. The entirety of Microsoft's documentation system is a series of Markdown files hosted on Github.

It can be versioned, diff'd between versions, is easy to update from anywhere, using everything from `vim` to `nano` to Visual Studio Code to Sublime to Notepad. If JSON is the language of APIS, and YAML the language of configuration, then Markdown is the language of documentation for developers.

## Why I 💗 Markdown

I find great joy and beauty in tools paired down to their simplest form, at an abstraction level that's not condescending, that's internally consistent while remaining highly compossible.

### Spend more time editing, less time formatting

Most online rich-text/HTML editors inject massive amounts of garbage HTML, which I take personally. To the point where I'll spend hours cleaning up rarely referenced online wiki pages that were composed with an HTML editor. Sharepoint and Google Wiki I'm looking at you.

## A Tour via Tips

### Format w/ intent

One of my coding principles is never to break your user's trust with UX inconsistencies. I picked this up from the Windows Phone Design Studio, which always stuck with me. Feature adoption drops significantly when a feature isn't consistent.

When a user can't predict when and where a feature will work, they'll start doubting it (_"What did I do wrong? It worked over there"_) and then avoiding it (_"I don't know how to use that feature, and that makes me feel dumb, so I'll just avoid it"_).

* pick a formatting style and stick with it
  * just as with code, consistency, even if you hate it, makes refactoring a sane option
  * pay special attention to inline code references, such as `CosmosDbFailover` and make sure all code references are formatted the same otherwise, cognitive pattern matching goes out the window
* common drift areas to watch for
  * mixing bullet style (either `*` or `-` but pick one, `*` is more "standard")
  * forgetting the space between a heading hash and the first character, such as `#Title` compared to the correct `# Title`

### Work with the constraints

* trust in the content, not the formatting
* simplify the design instead of hacking around Markdown
* there is rarely a need to mix HTML elements in w/ Markdown
* layout the document knowing it'll be read in plain text as much as rendered HTML
* write for the content, not the render. If you can't make sense of the text until it's been rendered, then the problem is probably with the content structure

### Using headings like book titles and chapters

A common issue is mixing headings with bold text and swapping them back and forth willy-nilly. In Markdown, a single pound/hash symbol (`#`) is the same as an H1 in HTML or the same as a book title. A double pound/hash (`##`) maps to an H2, which roughly maps to chapter titles in a book.

This is a rough analogy, but it's helpful when structuring content to be reminded that a book should only have a single title or a web page should only have a single H1. All my semantic web developers probably have this drilled into their brains. Instead of viewing a # or H1 as a big, bolded font, it's better to view it as the main topic, book, title, blog post title, etc., and according to semantic HTML, a page should only ever have a single H1.

* headings (H1, H2, H3, etc.) are often used to render a table of contents (TOC)
* view heading levels as an organizational feature instead of formatting
* it's okay to break the Highlander rule that there can only be one H1 when there is intent behind it

### When stuck, take inspiration from others

* it's common to know a layout isn't working well but not know why
* instead of adding more bold/italic/block quotes, look for similar examples
* Github is a great go-to for inspiration

### Avoid too many call-outs

Call-outs in this context are those eyeball-grabbing points of interest in the form of a bolded IMPORTANT, a block-quoted pro-tip, or a helpful hint. Used sparingly, they hold the line remarkably well. Add too many, though, and the message gets lost from the constant context switching. If everything is important, then suddenly nothing is important.

If more than "some percentage" of a document is call-outs, the issue is often one of mixing tones or intent, such as shifting between exposition, extemporization, and detailed steps. The shift back and forth becomes a siren song for call-outs.

Depending on the intent, it's better to pick a single tone or group similar tones together.

For install steps, it's important to keep everything concise and the chatter to a minimum. Reducing each step to basics gives the impression that everything in the list is critical without having to tag every other step with a call-out.

### Code

Representing code in Markdown has little overhead and helps so much when reading large articles that it's one of the first things I teach people.

#### Code Blocks

Use triple ticks (```) to demarcate multi-line code blocks.

**Raw**

<p>
```<br/>
{<br/>
    "userId": "1234-ABCD-9876-DCBA"<br/>
}<br/>
```<br/>
</p>

**Rendered**

```
{
    "userId": "1234-ABCD-9876-DCBA"
}
```

Tell Markdown what language to use for syntax highlighting by adding the language name after the triple ticks, so for JSON it would be `` ```json ``.

**Raw**

<p>
```json<br/>
{<br/>
    "userId": "1234-ABCD-9876-DCBA"<br/>
}<br/>
```<br/>
</p>

**Rendered**

```json
{
    "userId": "1234-ABCD-9876-DCBA"
}
```

#### Inline Code References

Surround text with single ticks (`) to create an inline code reference.

* code can be inline, such as "class `Zuul` has a dependency on `GateKeeper`".
* even minimal syntax highlighting makes a huge difference

### General

Tips that didn't play well with the other groups, but I think are important.

* Use emoji, but with intent and with purpose
* Don't be scared of white-space
  * space between hash and text
  * CRLF between headers
* Think in terms of outline/TOC
* Use citation references for link-heavy documents
* Don't worry about ordered list numbering
* Take the extra minute to do look up how to do something

## Useful Links

Links to things mentioned or hinted.

* [Daring Fireball - Markdown Reference][fireball] - the official site
* [Daring Fireball - Dingus][dingus] - an online Markdown playground
* [David Anson's Markdown Linter for VSCode][vscode-lint] - a great linter to help write better Markdown
* [Hugo Open-Source Static Site Generator][hugo] - Markdown-based static site generator
* [Jekyell Static Site Generator][jekyell] - another Markdown-based static site generator

[fireball]: https://daringfireball.net/projects/markdown/ "Daring Fireball"
[dingus]: https://daringfireball.net/projects/markdown/dingus "Dingus"
[vscode-lint]: https://github.com/DavidAnson/vscode-markdownlint "David Anson's VSCode Markdown linter"
[hugo]: https://gohugo.io/ "Hugo"
[jekyell]: https://jekyllrb.com/ "Jekyell Static Site Generator"
