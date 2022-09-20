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
    public class LoginSessionDAO : CRUD<LoginSession>
    {

        private IMongoCollection<LoginSession> loginSessionCollection;

        public LoginSessionDAO(){
            Mongo db = new Mongo();
            loginSessionCollection = db.GetDatabase("AndrewMcCall").GetCollection<LoginSession>("LoginSessions");
        }

        public LoginSession ReadLatest(){
            return loginSessionCollection.AsQueryable().OrderByDescending(c => c.Id).First();
        }

        public LoginSession Create(LoginSession loginSession){
            loginSessionCollection.InsertOne(loginSession);
            return ReadLatest();
        }

        public List<LoginSession> GetAll(){
            return loginSessionCollection.AsQueryable().ToList();
        }

        public LoginSession GetOne(String Id){
            return loginSessionCollection.Find(x => x.Id == Id).FirstOrDefault();
        }

        public ReplaceOneResult Update(LoginSession loginSession){
            return loginSessionCollection.ReplaceOne(x => x.Id == loginSession.Id, loginSession);
        }

        public DeleteResult Delete(String Id){
            return loginSessionCollection.DeleteOne(x => x.Id == Id);
        }
    }
}