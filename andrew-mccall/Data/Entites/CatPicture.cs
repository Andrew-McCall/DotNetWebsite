using System;
using MongoDB.Bson;
using MongoDB.Driver;
using andrew_mccall.Database;
using andrew_mccall.Entites;

namespace andrew_mccall.Entites
{   
    public class CatPicture {

        public ObjectId Id {get; set;}

        public string url { get; set; }

        public CatPicture(String url){
            this.url = url;
        }

        public override string ToString(){
            return "CatPicture[ url=" + this.url + "]";
        }

    }
}
