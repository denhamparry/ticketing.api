# Ticketing.API

A ticketing system to demo Kubernetes

## Setup

```bash
$ docker run --name ticketing.mongo -d mongo
...
$ docker run --name ticketing.api -p 3000:80 --link ticketing.mongo:ticketing.mongo -d gcr.io/astute-asset-226319/ticketing.api:e837f7c48f6b6962352edc496beb20643f722aa8
...
```