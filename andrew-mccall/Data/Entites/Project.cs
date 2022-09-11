using System;
using MongoDB.Bson;
using MongoDB.Driver;
using andrew_mccall.Database;


namespace andrew_mccall.Entites
{   
    public class Project{
        
        public ObjectId _id { get; set; }

        public String Id {get; set;}

        public String Title { get; set; }
        public String Description { get; set; }
        public String Link { get; set; }
        public String Image { get; set; }
        public Boolean Demo {get; set; }

        public Project(){}

        public Project(ObjectId _id, String Title, String Description, String Link, String Image, Boolean Demo)
        {
            this._id = _id;
            this.Id= _id.ToString();
            this.Title = Title;
            this.Description = Description;
            this.Link = Link;
            this.Image = Image;
            this.Demo = Demo;
        }

        public Project(String Id, String Title, String Description, String Link, String Image, Boolean Demo)
        {
            this.Id = Id;
            this.Title = Title;
            this.Description = Description;
            this.Link = Link;
            this.Image = Image;
            this.Demo = Demo;
        }

    }
}
