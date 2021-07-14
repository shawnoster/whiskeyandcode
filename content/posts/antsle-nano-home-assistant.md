+++
title = "Running Home Assistant on an Antsle Nano"
date = "2021-05-11"
categories = ["Code"]
tags = ["Antsle", "Home Assistant", "InfluxDB", "Grafana"]
draft = false
+++

A brief overview of my [Home Assistant](https://www.home-assistant.io/) setup.

This is a tour rather than a step-by-step with the goal of reassuring new Antsle owners that you can run all these wonderful things on it and as a reminder to myself for some of the more common setup steps I run. I also start with a bit of the "why".

## Why Run a Private Cloud?

By a very broad definition I'm running an on-prem private cloud. On-prem meaning all the server software runs on my home hardware, storage and network. Why anyone would want to is a very valid question, since the cloud versions of all this would be much easier to work with.

For me it's **privacy and availability**.

### Privacy

The longer I worked at Mighty AI (Seattle, WA ML training data company since acquired by Uber) helping tease out high-quality, data-rich, accurately annotated, training-set data to feed machine learning, the more aware I became of how much of my digital profile I was giving away. While I love having a history of my location throughout the year via my phone's GPS, I don't like Google having first dibs on it. I like even less the idea of a bad actor getting ahold of that data via a Google breach.

Home Assistant allows me to keep a log of my GPS location, sent directly to my server, stored on my disks, and in a raw format allowing me to run my own ML against it. I can share it with other online services but it's now my choice to share it instead of having to ask a 3rd-party to allow another 3rd-party access.

### Availability

I've experienced my Internet going down too many times to trust in an always-on Internet. I'd rather have access to as many of my services and resources on this side of my ISP as possible.

## Hardware - Antsle Nano

I run most of my home services off an [Antsle Nano](https://go.antsle.com/antsle-nano/), a RasberryPi running Antsle's custom virtualization software that runs Docker and both LXC and KVM images.

![Antsle Dashboard](../images/9ecc9e9fd34c149c60a0666fbb434166aa38574da55e20da2d8576ccedc67af0.png)

It's a cute thing isn't it? I have an older Nano with 4GB and I still run a ton of services off of it without issues. Mostly I play with different tech stacks via Ubuntu VMs. It's also fun to see how small of an image I can make and then network dozens of them together to simulate various cloud architectures.

Aside from spinning up quick Linux distros it's plenty powerful enough to run my favorite home automation platform, Home Assistant.

## Software - Home Assistant

[Home Assistant](https://www.home-assistant.io/) is an open-source home automation platform with a ton of extensibility points and support for pretty much every home IoT device out there.

Since it's a home automation platform it has to be running all the time, making a networked RasberryPi the perfect server to run it on top of. I tried installing it various ways, mostly from source inside of a Ubuntu VM, until I stopped making life hard on myself and switched to the official Docker image.

![Home Assistant Dashboard](../images/db070fac997ec58105692246a8d988c145edcb466c661df0b2dc7ed51cb8fdb4.png)

### Installing Home Assistant on an Antsle Nano

Installation and basic configuration is a matter of pulling down the Docker image, deleting any old ones if doing an upgrade, then restarting the container.

```bash
# ssh into my Antsle Nano
ssh root@192.168.1.116

# pull latest homeassistant image,
# if this returns "Image is up to date" then stop here
docker pull homeassistant/home-assistant:stable

# stop and remove the running container if
# doing an upgrade
docker stop homeassistant
docker rm homeassistant

# start
docker run -d --restart=always \
              --name=homeassistant \
              -v /home/homeassistant:/config \
              -v /etc/localtime:/etc/localtime:ro \
              --net=host \
              homeassistant/home-assistant:stable
```

The trickiest part was making sure the time matched the rest of the machines on my home network. The option `-v /etc/localtime:/etc/localtime:ro` did the trick.

![picture 1](../images/ca797f90dbe1cc5970168f10aa39114010c70dfeb440a4e6a542895cabe1aa3b.png)

### Use VSCode to edit Home Assistent Config

HA stores it's scripts and configurations in a set of yaml files which are mapped to a location on the Nano (`-v /home/homeassistant:/config`). HA has very slick configuration editor but for heavier editing I prefer to use vscode.

I'm rather horrible at vi/vim. so, instead of doing the sane thing and learning it I mount home assistant's config folder into my WSL instance, which I then use [Microsoft's VSCode Remote - WSL extension](https://github.com/Microsoft/vscode-remote-release) to access.

```bash
# map the WSL folder ~/homeassistant/ -> /home/homeassistant/ on the Nano
sshfs root@192.168.1.116:/home/homeassistant/ ~/homeassistant/
```

### Accessing Home Assistant from the Public Internet

Part of the fun of HA is that I can log in from anywhere and control my entire house. To do that you can either pay for Home Assistant Cloud, which handles all the fun, or you can homebrew hack it like I do and use something like duckdns.org.

Nothing too magic here:

1. Reserve IP address via MAC address in router to always use the same IP (this makes things easier, I recommend everyone creates a home network map and reserve IP addresses for all appliances)
1. Setup dynamic DNS with a service like [DuckDNS.org](https://www.duckdns.org)
1. In your router forward port 8123 to the Nano (HA runs on 8123 by default)
1. Edit `configuration.yaml`

   ```yaml
   homeassistant:
     name: Home
     external_url: "http://<your dynamic DNS subdomain>.duckdns.org:8123"
     internal_url: "http://<your internal IP>:8123"
   ```

## Software - InfluxDb

By default HA logs all it's data to a SQLite database. Given the way writes can thrash a SD card it's best to redirect all the data HA generates to something else. There can be more than one "some place" as well. A common setup is to log to MariaDb for persistance and InfluxDb for time-series based logging and activity.

There are **a lot** of great articles out there on InfluxDb and I won't dilute the knowledge pool with my hacked together summary. One thing I did have trouble finding was setting up InfluxDb 2.0 for use with Home Assistant, all while running it on my Nano.

Docker again to the rescue:

```bash
# ssh into the Nano first
$ docker run -d -p 8086:8086 \
      -v $PWD/data:/var/lib/influxdb2 \
      -v $PWD/config:/etc/influxdb2 \
      -e DOCKER_INFLUXDB_INIT_MODE=setup \
      -e DOCKER_INFLUXDB_INIT_USERNAME=influx-admin \
      -e DOCKER_INFLUXDB_INIT_PASSWORD=EatMoreCupcakesAndTacos \
      -e DOCKER_INFLUXDB_INIT_BUCKET=home-assistant \
      influxdb:latest
```

And on the Antsle side, edit `configuration.yaml`:

```yaml
# InfluxDB 2.0
influxdb:
  api_version: 2
  ssl: false
  host: 192.168.1.116 # <- This is my IP, use your own
  port: 8086
  organization: <ID can be found in InfluxDb>
  token: <token from your InfluxDb instance>
  bucket: home-assistant
  tags:
    source: ha
```

Here's a simple chart of my office temperature as reported via Hue Motion Sensor

![InfluxDb](../images/918d5b22f6834c2982135cf9f56b870e1632f00933de6f1afc9c39135c74df5d.png)

## Software - Grafana

Grafana is an amazing open-source visualization platform, yet again Docker to the rescue:

```bash
docker run -d -p 3100:3000 \
           --name=grafana \
           -v grafana-storage:/var/lib/grafana grafana/grafana
```

## Devices, Configurations, Scripts

There's a lot of other great stuff you can do with Home Assistant and I barely scratch the surface with mine but here's what I have configured.

* At 7:45am HA turns on the XBox in my office, starts playing a looping YouTube channel, and turns on my office lights at 70%
* Scanning different QR codes will play various artists and playlists via Spotify on my Sonos system
* All office temperature data is logged to InfluxDb and Grafana
* Integrated [OwnTracks](https://owntracks.org/) to serve as a "Find a Friend" location service, except the data goes directly to my private cloud
* When my partner's phone MAC address is detected on our home network, a bulb in my office blinks twice
