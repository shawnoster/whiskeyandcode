## Overview

- `rbenv`, a Ruby version manager, is used to manage different versions
- `ruby-build` is installed as a `rbenv` plug-in to handle pulling and building Ruby from source

## Install

### rbenv

1. Install essential build tools, most importantly an ANSI-standard C compiler, which `ruby-build`, via `rbenv`, needs in order to compile Ruby.

```bash
# safe to skip if you've built Python 3.7.2 from source but there's
# no harm in running it again if you're unsure
$ sudo apt install build-essential
```

1. Install `rbenv`. These instructions are the fast and furious version of the official [Basic GitHub Checkout](https://github.com/rbenv/rbenv#basic-github-checkout) instructions.

```bash
# clone rbenv source to ~/.rbenv
$ git clone https://github.com/rbenv/rbenv.git ~/.rbenv

# compile dynamic bash extension to speed up rbenv, verified
# this works on Ubuntu 18.04 WSL
$ cd ~/.rbenv && src/configure && make -C src
```

1. Add the path and init code to your `~/.profile`

```bash
# rbenv path
export PATH="$HOME/.rbenv/bin:$PATH"

# init rbenv on shell start
if which rbenv > /dev/null; then eval "$(rbenv init -)"; fi
```

1. Reload your environment

```bash
$ source ~/.profile
```

1. Install `ruby-build`

```bash
# install as an rbenv plugin
$ mkdir -p "$(rbenv root)"/plugins
$ git clone https://github.com/rbenv/ruby-build.git "$(rbenv root)"/plugins/ruby-build
```

1. Verify everything is configured correctly

```bash
# verify
$ curl -fsSL https://github.com/rbenv/rbenv-installer/raw/master/bin/rbenv-doctor | bash
Checking for `rbenv' in PATH: /home/shawn/.rbenv/bin/rbenv
Checking for rbenv shims in PATH: OK
Checking `rbenv install' support: /home/shawn/.rbenv/plugins/ruby-build/bin/rbenv-install (ruby-build 20190130-4-g0e33b11)
Counting installed Ruby versions: 2 versions
Checking RubyGems settings: OK
Auditing installed plugins: OK    
```


# Ruby Recipes

## Dumping Files

Write an array to a file

```ruby
open('/tmp/missing_70025.txt', 'w') { |f|
    f << missing_source_urls.join("\n")
}
```

## CSV

Read a CSV into an array of hashes

```ruby
require 'csv'

# with headers
data = CSV.read('favorite_foods.csv', headers: true)
```
