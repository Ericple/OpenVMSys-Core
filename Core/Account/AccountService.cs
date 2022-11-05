using MongoDB.Bson;
using MongoDB.Driver;
using OpenVMSys_Core.Core.Pilot;

namespace OpenVMSys_Core.Core.Account
{
    public class AccountService : ServiceBase
    {
        private static readonly PilotService pilotService = new();
        public AccountService()
        {
            _client = new(OpenVMSysConfigurations.DatabaseUrl);
            _database = _client.GetDatabase(OpenVMSysConfigurations.SiteName);
            _collection = _database.GetCollection<BsonDocument>("Account");
        }
        
        public bool Auth(string identifier,string password)
        {
            if(_collection.Find(Builders<BsonDocument>.Filter.Eq("Identifier",identifier) &
                Builders<BsonDocument>.Filter.Eq("Password", password)).CountDocuments() == 1)
            {
                return true;
            }
            return false;
        }

        public void Register(
            string identifier,
            string email,
            string nickName,
            string password,
            string hub)
        {
            if (_collection != null)
            {
                _collection.InsertOne(new BsonDocument
                {
                    {"Identifier",identifier},
                    {"Password",password}
                });
                pilotService.Create(new BsonDocument
                {
                    {"Identifier",identifier},
                    {"Email",email},
                    {"NickName",nickName},
                    {"AirportICAO",hub},
                    {"Company","GOV"},
                    {"Level",1 },
                    {"Status",0 }
                });
            }
        }
    }
}
