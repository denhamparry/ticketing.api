docker run --name ticketing.mongo -d mongo
docker exec -it ticketing.mongo bash
docker logs ticketing.mongo
docker run -it --rm mongo --help