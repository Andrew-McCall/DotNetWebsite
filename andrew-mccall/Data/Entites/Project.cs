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

        public Project(){}

        public Project(String Id, String Title, String Description, String Link, String Image, Boolean Demo)
        {
            this.Id= Id;
            this.Title = Title;
            this.Description = Description;
            this.Link = Link;
            this.Image = Image;
            this.Demo = Demo;
        }

    }
}
