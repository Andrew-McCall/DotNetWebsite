using System;
using MongoDB.Bson;
using MongoDB.Driver;
using andrew_mccall.Database;


namespace andrew_mccall.Entites
{   
    public class Project{
        
        public ObjectId Id { get; set; }

        public String Title { get; set; }
        public String Description { get; set; }
        public String Link { get; set; }
        public String Image { get; set; }
        public bool Demo {get; set; }

        public Project(String Title, String Description, String Link, String Image,bool Demo)
        {
            this.Title = Title;
            this.Description = Description;
            this.Link = Link;
            this.Image = Image;
            this.Demo = Demo;
        }

    }
}
