# Ticketing.API

A ticketing system to demo Kubernetes

## Setup

```bash
$ docker run --name ticketing.mongo -d mongo
...
docker build -t denhamparry/ticketing.api:local .
docker run --rm -it -p 3000:80 --name ticketing.api --link ticketing.mongo:ticketing.mongo -d denhamparry/ticketing.api:local
...
```

## Start

```bash
$ docker start ticketing.mongo
ticketing.mongo
$ docker start ticketing.api
ticketing.api
```

* [Settings](http://localhost:3000/settings)

## Delete

```bash
$ docker stop ticketing.api
ticketing.api
$ docker stop ticketing.mongo
ticketing.mongo
```