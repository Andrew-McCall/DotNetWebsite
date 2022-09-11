using System;
using System.Collections.Generic;  
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq; 
using andrew_mccall.Database;
using andrew_mccall.Entites;

namespace andrew_mccall.DAO
{   
    public class ProjectDAO{

        private IMongoCollection<BsonDocument> projectsCollection;

        public ProjectDAO(){
            Mongo db = new Mongo();
            projectsCollection = db.GetCollection("Projects", "AndrewMcCall");
        }

        private Project ModelProjectFromBson(BsonDocument document){
            return new Project(document.GetValue("Title").ToString(),document.GetValue("Description").ToString(),document.GetValue("Link").ToString(),document.GetValue("Image").ToString(),document.GetValue("Demo").ToBoolean());
        }

        public List<Project> GetAll(){
            List<Project> projects = new List<Project>();
            foreach(BsonDocument bson in projectsCollection.AsQueryable()){
                projects.Add(ModelProjectFromBson(bson));
            }
            return projects;
        }

        public void Create(Project project){

            BsonDocument document = new BsonDocument { {"Title", project.Title}, {"Description", project.Description}, {"Link", project.Link}, {"Image", project.Image}, {"Demo", project.Demo} };
            projectsCollection.InsertOne(document);

        }

    }
}