## Node, npm, nvm


These steps are taken from [How to install Node.js and npm on Ubuntu 18.04](https://linuxize.com/post/how-to-install-node-js-on-ubuntu-18.04/) which seem to be a retread of the [official installation instructions](https://github.com/creationix/nvm#installation).  I repeat them here for ease of use in a very minimal form so if you have any issues check out those two links.

### NVM (Node Version Manager)

NVM is, as the website says, _"A simple bash script to manage multiple active node.js versions"_.

1. Install (or update nvm if it already exists)

   ```bash
   $ curl -o- https://raw.githubusercontent.com/nvm-sh/nvm/v0.37.2/install.sh | bash
   ```

1. Close and reopen your terminal.

1. Verify

   ```bash
   $ nvm --version
   0.34.0
   ```

### Node.js and npm

```bash
$ nvm install node
Downloading and installing node v11.10.0...
Downloading https://nodejs.org/dist/v11.10.0/node-v11.10.0-linux-x64.tar.xz...
############################################################################## 100.0%
Computing checksum with sha256sum
Checksums matched!
Now using node v11.10.0 (npm v6.7.0)
Creating default alias: default -> node (-> v11.10.0)
```

Verify

```bash
$ node --version
v11.10.0
```

### Updating

```bash
# nvm
$ curl -o- https://raw.githubusercontent.com/creationix/nvm/v0.34.0/install.sh | bash
```

### Fixing EACCES: permission denied

https://feitam.es/how-fix-the-error-eacces-permission-denied-unlink-usr-local-bin-jhipster-when-installing-generator-jhipster-library-node-with-npm/

https://docs.npmjs.com/resolving-eacces-permissions-errors-when-installing-packages-globally