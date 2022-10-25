using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using andrew_mccall.Database;


namespace andrew_mccall.Entites
{   
    public class Project{
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id {get; set;}

        [BsonRequired]
        public String Title { get; set; }
        [BsonRequired]
        public String Description { get; set; }
        [BsonRequired]
        public String Link { get; set; }
        [BsonRequired]
        public String Image { get; set; }
        [BsonRequired]
        public Boolean Demo {get; set; }
        [BsonRequired]
        public DateTime Time {get; set; }
    }
}
