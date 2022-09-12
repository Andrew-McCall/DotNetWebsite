using System;
using System.Collections.Generic;  
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq; 
using andrew_mccall.Database;
using andrew_mccall.Entites;
using andrew_mccall.DAO;

namespace andrew_mccall.DAO
{   
    public class ProjectDAO : CRUD<Project>
    {

        private IMongoCollection<Project> projectsCollection;

        public ProjectDAO(){
            Mongo db = new Mongo();
            projectsCollection = db.GetDatabase("AndrewMcCall").GetCollection<Project>("Projects");
        }
        
        public Project ReadLatest(){
            return projectsCollection.AsQueryable().OrderByDescending(c => c.Id).First();
        }

        public Project Create(Project project){
            projectsCollection.InsertOne(project);
            return ReadLatest();
        }

        public List<Project> GetAll(){
            return projectsCollection.AsQueryable().ToList();
        }

        public Project GetOne(String Id){
            return projectsCollection.Find(x => x.Id == Id).FirstOrDefault();
        }

        public ReplaceOneResult Update(Project project){
            return projectsCollection.ReplaceOne(x => x.Id == project.Id, project);
        }

        public DeleteResult Delete(String Id){
            return projectsCollection.DeleteOne(x => x.Id == Id);
        }

    }
}