using MongoDB.Driver;
using MongoDB.Bson;
namespace OpenVMSys_Core.Core.Pilot
{
    public class PilotService : ServiceBase
    {
        public PilotService()
        {
            _client = new(OpenVMSysConfigurations.DatabaseUrl);
            _database = _client.GetDatabase(OpenVMSysConfigurations.SiteName);
        }
    }
}
