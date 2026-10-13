#!/usr/bin/env bash

# Builds the site on Cloudflare Workers.
# The meme theme needs an old Hugo (removed APIs in 0.128+), and the extended
# build, because the theme compiles Sass.

set -euo pipefail

HUGO_VERSION=0.128.2

build_temp_dir=$(mktemp -d)
trap 'rm -rf "${build_temp_dir}"' EXIT

echo "Installing Hugo extended ${HUGO_VERSION}..."
curl -sfL --output-dir "${build_temp_dir}" -O "https://github.com/gohugoio/hugo/releases/download/v${HUGO_VERSION}/hugo_extended_${HUGO_VERSION}_linux-amd64.tar.gz"
mkdir -p "${HOME}/.local/hugo"
tar -C "${HOME}/.local/hugo" -xf "${build_temp_dir}/hugo_extended_${HUGO_VERSION}_linux-amd64.tar.gz"
export PATH="${HOME}/.local/hugo:${PATH}"

hugo version
hugo --gc --minify
