# Ticketing.API API

## API Setup

* Setup MongoDB:

```bash
$ dotnet add ticketing.csproj package MongoDB.Driver
Writing...
```

## References

* [ASP.NET Web API and MongoDB](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-2.2&tabs=visual-studio-code)

## RabbitMQ

### Setup RabbitMQ

#### Local

Install RabbitMQ locally:

```bash
$ brew update
Updating Homebrew...
$ brew install rabbitmq
Updating Homebrew...
$ brew upgrade rabbitmq
Updating Homebrew...
$ export PATH=$PATH:/usr/local/sbin
...
```

#### Docker

'''bash
$ docker run -d --name ticketing.messaging rabbitmq:3-management
'''