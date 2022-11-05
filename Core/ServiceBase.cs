using MongoDB.Driver;
using MongoDB.Bson;
namespace OpenVMSys_Core.Core
{
    public class ServiceBase
    {
        protected static MongoClient? _client;
        protected static IMongoDatabase? _database;
        protected static IMongoCollection<BsonDocument>? _collection;

        /**
         * Get all objects
         * JSON string
         */
        public object Get()
        {
            return _collection.Find(new BsonDocument()).ToList().ToJson();
        }

        /**
     * Get object with certain identifier
     */
        public object Get(string identifier)
        {
            return _collection.Find(Builders<BsonDocument>.Filter.Eq("Identifier", identifier)).ToList().ToJson();
        }

        /**
         * Create an new instance
         * void
         */
        public void Create(BsonDocument obj)
        {
            PropertyCheck();
            _collection.InsertOne(obj);
        }

        /**
         * Delete instance with certain identifier
         * long
         */
        public long Delete(string identifier)
        {
            PropertyCheck();
            return _collection.DeleteOne(Builders<BsonDocument>.Filter.Eq("Identifier", identifier)).DeletedCount;
        }

        public long Transfer(string identifier, string target)
        {
            PropertyCheck();
            return _collection.UpdateOne(
                Builders<BsonDocument>.Filter.Eq("Identifier", identifier),
                Builders<BsonDocument>.Update.Set("Belonging", target)).ModifiedCount;
        }

        protected void PropertyCheck()
        {
            if (_collection == null || _database == null || _database == null)
            {
                throw new InvalidOperationException(
                    "Property used before inited"
                );
            }
        }
    }
}