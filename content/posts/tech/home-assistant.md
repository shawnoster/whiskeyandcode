---
title: Hello nested tags
tags: [tech, automation, home-assistant]
---

# Home Assistant

## Installing / Updating

```bash
ssh root@192.168.1.116

# pull latest homeassistant image

# if this returns "Image is up to date" then you can stop here
docker pull homeassistant/home-assistant:stable

# stop the running container
docker stop home-assistant

# remove it from Docker's list of containers
docker rm home-assistant

# start
docker run -d --restart=always --name="home-assistant" -v /home/homeassistant:/config -v /etc/localtime:/etc/localtime:ro --net=host homeassistant/home-assistant:stable
```

```bash
export GITLAB_HOME=/home/gitlab

sudo docker run --detach \
  --hostname gitlab.example.com \
  --publish 443:443 --publish 80:80 --publish 22:22 \
  --name gitlab \
  --restart always \
  --volume $GITLAB_HOME/config:/etc/gitlab \
  --volume $GITLAB_HOME/logs:/var/log/gitlab \
  --volume $GITLAB_HOME/data:/var/opt/gitlab \
  gitlab/gitlab-ee:latest
```

## Accessing config

To use VS Code I mounted the Antsle's home assistant config folder into my WSL instance, which I then use VSCode's remoting to access.

```bash
sshfs root@192.168.1.116:/home/homeassistant/ ~/homeassistant/
```

## Configure

1. Reserve IP address via MAC in router to always use the same IP
1. Open `configuration.yaml` in vscode

```yaml
homeassistant:
  name: Home
  external_url: "http://belltown.duckdns.org:8123"
  internal_url: "http://192.168.1.116:8123"
```

## Making it public

1. Setup a dynamic DNS - https://www.duckdns.org
1. Forward port 8123 to HA Docker image

## Installing integrations

### Spotify

```
Client ID: 41aa18ad24194d6b91374407f9179124
Client Secret: fd538c35676a429aa820fed62794e6bc

http://belltown.duckdns.org:8123/auth/external/callback
http://belltown.duckdns.org:8123/auth/external/callback
https://accounts.spotify.com/authorize?response_type=code&client_id=41aa18ad24194d6b91374407f9179124&redirect_uri=http://belltown.duckdns.org:8123/auth/external/callback&state=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJmbG93X2lkIjoiMWNlMzMyYzcyMDc4NDFiZDljNzJjZjBhMmUxNWE0NTcifQ.uzN2BHjIoeuk4TLmR4nzkXojX2UP2IVTeI2f_pIa1wU&scope=user-modify-playback-state,user-read-playback-state,user-read-private,playlist-read-private,playlist-read-collaborative,user-library-read,user-top-read,user-read-playback-position,user-read-recently-played,user-follow-read

https://accounts.spotify.com/authorize?response_type=code&client_id=41aa18ad24194d6b91374407f9179124&redirect_uri=http://192.168.1.116:8123/auth/external/callback&state=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJmbG93X2lkIjoiNTlhZmEzN2ViNzIxNDIyZDlhOTAyMjVlMjc2ZDEyYzIifQ.ADmhJWEjJA5FYeqozE7hZlOZ-bUanZlCCHrB64jjtOw&scope=user-modify-playback-state,user-read-playback-state,user-read-private,playlist-read-private,playlist-read-collaborative,user-library-read,user-top-read,user-read-playback-position,user-read-recently-played,user-follow-read
```

https://open.spotify.com/show/4Zkj8TTa7XAZYI6aFetlec?si=uNLALulhQC6ARe_QJ41rbQ
https://open.spotify.com/playlist/5syrTT7xKMr8OzhYO5ANuu?si=r9Dh3IqmR96nonfW4vmsWw

## Setting up Influx DB

### Docker

```bash
mkdir /home/influx-data && cd /home/influx-data

docker run \
    -d \
    --name influxdb \
    -p 8086:8086 \
    --volume $PWD:/root/.influxdbv2 \
    influxdb:2.0.4