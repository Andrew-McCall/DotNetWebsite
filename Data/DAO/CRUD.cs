using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace andrew_mccall.DAO
{
    public interface CRUD <T>
    {
        T Create(T t);
        List<T> GetAll();
        T GetOne(String Id);
        ReplaceOneResult Update(T t);
        DeleteResult Delete(String Id);

    }
}