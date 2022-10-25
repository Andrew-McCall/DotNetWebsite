using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using andrew_mccall.Database;
using andrew_mccall.Data;
using System.Security.Cryptography;

namespace andrew_mccall.Entites
{   
    public class LoginSession{
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id {get; set;}

        [BsonRequired]
        public String LoginId {get; set;}
        [BsonRequired]
        public String Token {get; set;}

        public LoginSession(String LoginId){
            this.LoginId = LoginId;
            GenerateThisToken();
        }

        public static String GenerateToken(String loginId){

            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(loginId + DateTime.UtcNow.ToString());
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

        public void GenerateThisToken(){

            this.Token = GenerateToken(LoginId);

        }
    }
}
