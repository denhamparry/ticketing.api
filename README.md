# Ticketing.API

A ticketing system to demo Kubernetes

## Setup

```bash
$ docker run --name ticketing.mongo -d mongo
...
docker run --rm -it -p 3000:80 -p 3001:443 --name ticketing.api --link ticketing.mongo:ticketing.mongo -d denhamparry/ticketing.api:0.0.4
...
```
