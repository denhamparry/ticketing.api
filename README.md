# Ticketing.API

A ticketing system to demo Kubernetes

## Setup

```bash
$ docker run --name ticketing.mongo -d mongo
...
$ docker run --name ticketing.api -p 3000:80 --link ticketing.mongo:ticketing.mongo -d denhamparry/ticketing.api
...
```
