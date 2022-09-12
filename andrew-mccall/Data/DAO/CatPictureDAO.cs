using System;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq; 
using andrew_mccall.Database;
using andrew_mccall.Entites;

namespace andrew_mccall.DAO
{   
    public class CatPictureDAO{

        private IMongoCollection<CatPicture> catCollection;

        public CatPictureDAO(){
            Mongo db = new Mongo();
            catCollection = db.GetDatabase("AndrewMcCall").GetCollection<CatPicture>("CatPictures");

        }

        public CatPicture getRandom(){
            return catCollection.AsQueryable().Sample(1).First();
        }

        public void Create(CatPicture catPicture){
            catCollection.InsertOne(catPicture);
        }

    }
}