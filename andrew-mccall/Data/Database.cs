using System;
using MongoDB.Bson;
using MongoDB.Driver;
using andrew_mccall.Entites;

namespace andrew_mccall.Database
{   
    public class Mongo{

        private MongoClient client;

        public Mongo(){
            this.Connect();
        }

        public MongoClient getClient(){
            return this.client;
        }

        public void Connect(){
            this.client = new MongoClient("mongodb://127.0.0.1:27017/test");
        }

        public IMongoDatabase GetDatabase(String name){
            return this.client.GetDatabase(name);
        }

        public IMongoCollection<BsonDocument> GetCollection(String collection, String database){
            return this.client.GetDatabase(database).GetCollection<BsonDocument>(collection);
        }

    }
}