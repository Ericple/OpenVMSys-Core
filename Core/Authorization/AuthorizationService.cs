using MongoDB.Driver;
using MongoDB.Bson;
namespace OpenVMSys_Core.Core.Authorization
{
    public class AuthorizationService : ServiceBase
    {
        private int _rep;
        
        public AuthorizationService()
        {
            _client = new(OpenVMSysConfigurations.DatabaseUrl);
            _database = _client.GetDatabase(OpenVMSysConfigurations.SiteName);
            _collection = _database.GetCollection<BsonDocument>("Authorization");
        }

        public bool Validate(string token, string clientIdentifier)
        {
            if (_collection.Find(Builders<BsonDocument>.Filter.Eq("Token", token) &
                                Builders<BsonDocument>.Filter.Eq("ClientIdentifier", clientIdentifier)).CountDocuments() ==
                1)
            {
                PropertyCheck();
                _collection.UpdateOne(Builders<BsonDocument>.Filter.Eq("Token", token),
                    Builders<BsonDocument>.Update.Set("Status", true));
                return true;
            }

            return false;
        }

        public string GenerateToken(int codeCount)
        {
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + this._rep;
            this._rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> this._rep)));
            for (int i = 0; i < codeCount; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char)(0x30 + ((ushort)(num % 10)));
                }
                else
                {
                    ch = (char)(0x41 + ((ushort)(num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }
    }
}
