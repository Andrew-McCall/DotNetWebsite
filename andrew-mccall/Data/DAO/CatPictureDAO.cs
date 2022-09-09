using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq; 
using andrew_mccall.Database;
using andrew_mccall.Entites;

namespace andrew_mccall.DAO
{   
    public class CatPictureDAO{

        private IMongoCollection<BsonDocument> catCollection;

        public CatPictureDAO(){
            Mongo db = new Mongo();
            catCollection = db.GetCollection("CatPictures", "AndrewMcCall");
        }

        private CatPicture ModelCatFromBson(BsonDocument document){
            return new CatPicture(document.GetValue("url").ToString());
        }

        public CatPicture getRandom(){
            BsonDocument document = catCollection.AsQueryable().Sample(1).First<BsonDocument>();

            return ModelCatFromBson(document);
        }

        public void Create(CatPicture catPicture){
            BsonDocument document = new BsonDocument { {"url", catPicture.url} };
            catCollection.InsertOne(document);
        }

    }
}