# Kubernetes

## Setup

```bash
$ kubectl apply -f configmap.yml
configmap/ticketingapi-configmap created
$ kubectl apply -f secret.yml
secret/ticketingapi-secret created
$ kubectl apply -f deployment.yml
deployment.apps/ticketingapi created
$ kubectl apply -f svc.yml
service/ticketingapi created
```

## Status

### Minikube

```bash
$ minikube service ticketingapi
Opening kubernetes service default/ticketingapi in default browser...
```

## Delete

```bash
$ kubectl delete -f configmap.yml
configmap/ticketingapi-configmap deleted
$ kubectl delete -f secret.yml
secret/ticketingapi-secret deleted
$ kubectl delete -f deployment.yml
deployment.apps/ticketingapi deleted
$ kubectl apply -f svc.yml
service/ticketingapi deleted
```