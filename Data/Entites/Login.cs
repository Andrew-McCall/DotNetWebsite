using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using andrew_mccall.Database;
using andrew_mccall.Data;
using System.Security.Cryptography;

namespace andrew_mccall.Entites
{   
    public class Login{
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id {get; set;}

        [BsonRequired]
        public String Username {get; set;}
        [BsonRequired]
        public String Password {get; set;}
        [BsonRequired]
        public AccessEnum Access {get; set;}

        [BsonIgnore]
        public Boolean isHashed {get; set;}

        public void hashPassword(){
            if (this.isHashed || string.IsNullOrEmpty(this.Password))
            return;

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(Password);
                byte[] hash = sha.ComputeHash(textData);
                this.Password = BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

        public LoginSession GenerateSession(){
            return new LoginSession(Id);
        }

    }
}
