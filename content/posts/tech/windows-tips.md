# Windows

### Create hard link/directory junction

```
# credit: https://www.howtogeek.com/howto/16226/complete-guide-to-symbolic-links-symlinks-on-windows-or-linux/
mklink /J "C:\Users\Shawn\Dropbox\repos\dashboard\content\post" "C:\Users\Shawn\Dropbox\repos\notes\blog"
```

## Wox

An app launcher similar to Alfred on OS X. It can do all sorts of power-user type things but I mostly use it to do quick web searches.

1. Install the latest [Everything](https://www.voidtools.com/)
   - Everything is a super fast file searcher that Wox uses it behind the scenes to do file searches
   - it has a small footprint and has never given me trouble so you're probably safe
   - install it as a service when asked

1. Install the latest [Wox](http://www.wox.one/)

### Adding a Web Search

After it's running add shortcuts for common searches
- `Alt` + `Spacebar` to bring up Wox
- Type `Settings`, <enter>
- From the `Plugin` tab select `Web Searches`

### Common Web Searches

No magic here, just an URL with the search term replaced with `{q}`.

**Serious Eats**
- Title: Serious Eats
- URL: `https://www.seriouseats.com/search?term={q}`
- Action Keyword: se

**The shawnoster/notes github code**
- Title: notes
- URL: `https://github.com/shawnoster/notes/search?utf8=%E2%9C%93&q={q}`
- Action Keyword: notes
