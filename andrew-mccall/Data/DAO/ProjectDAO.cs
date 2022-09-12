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

        private IMongoCollection<Project> projectsCollection;

        public ProjectDAO(){
            Mongo db = new Mongo();
            projectsCollection = db.GetDatabase("AndrewMcCall").GetCollection<Project>("Projects");
        }

        public List<Project> GetAll(){
            return projectsCollection.AsQueryable().ToList();
        }

        public Project Create(Project project){

            projectsCollection.InsertOne(project);
            return project;
        }

    }
}