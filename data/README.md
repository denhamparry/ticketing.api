# Ticketing.API Data

## Mongo DB

* From root of API folder:

```bash
mongod --dbpath bin/data
...
```

* From a new window:

```bash
$ mongo
>
$ use TicketingDb
switched to db TicketingDb
$ db.createCollection('Tickets')
{ "ok" : 1 }
```

* Define ticketing schema:

```bash
$ db.Tickets.insertMany([{'Name':'Ellie','Browser':"Safari",'Category':'Talk','Speaker':'Lewis Denham-Parry'}, {'Name':'Laurie','Browser':"Chrome",'Category':'Talk','Speaker':'Lewis Denham-Parry'}])
{
        "acknowledged" : true,
        "insertedIds" : [
                ObjectId("5c1d072cfaf31586ea463c6f"),
                ObjectId("5c1d072cfaf31586ea463c70")
        ]
}
```

* View entities added to the database:

```bash
$ db.Tickets.find({}).pretty()
{
        "_id" : ObjectId("5c1d072cfaf31586ea463c6f"),
        "Name" : "Ellie",
        "Browser" : "Safari",
        "Category" : "Talk",
        "Speaker" : "Lewis Denham-Parry"
}
{
        "_id" : ObjectId("5c1d072cfaf31586ea463c70"),
        "Name" : "Laurie",
        "Browser" : "Chrome",
        "Category" : "Talk",
        "Speaker" : "Lewis Denham-Parry"
}
```

* Database is setup and ready to go!