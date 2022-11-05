using MongoDB.Bson;
using MongoDB.Driver;

namespace OpenVMSys_Core.Core.Aircraft
{
    public class AircraftService : ServiceBase
    {
        public AircraftService()
        {
            _client = new(OpenVMSysConfigurations.DatabaseUrl);
            _database = _client.GetDatabase(OpenVMSysConfigurations.SiteName);
            _collection = _database.GetCollection<BsonDocument>("Aircraft");
        }
    }
}
