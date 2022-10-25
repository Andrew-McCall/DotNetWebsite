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
    public class LoginDAO : CRUD<Login>
    {

        private IMongoCollection<Login> loginCollection;

        public LoginDAO(){
            Mongo db = new Mongo();
            loginCollection = db.GetDatabase("AndrewMcCall").GetCollection<Login>("Logins");
        }
        
        public Boolean CheckCredentials(Login login){
            login.hashPassword();
            
            return (!object.ReferenceEquals(loginCollection.Find(l => (l.Password == login.Password && l.Username == login.Username)).FirstOrDefault(), null));

        }

        public Login ReadLatest(){
            return loginCollection.AsQueryable().OrderByDescending(c => c.Id).First();
        }

        public Login Create(Login login){
            loginCollection.InsertOne(login);
            return ReadLatest();
        }

        public List<Login> GetAll(){
            return loginCollection.AsQueryable().ToList();
        }

        public Login GetOne(String Id){
            return loginCollection.Find(x => x.Id == Id).FirstOrDefault();
        }

        public ReplaceOneResult Update(Login login){
            return loginCollection.ReplaceOne(x => x.Id == login.Id, login);
        }

        public DeleteResult Delete(String Id){
            return loginCollection.DeleteOne(x => x.Id == Id);
        }
    }
}