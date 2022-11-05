using Microsoft.AspNetCore.Mvc;
using OpenVMSys_Core.Core.Security;
using MongoDB.Bson;

namespace OpenVMSys_Core.Core.Aircraft
{
    [ApiController]
    [Route("api/aircraft")]
    public class AircraftController : ControllerBase
    {
        private static readonly AircraftService aircraftService = new();
        private static readonly SecurityKeyService securityKeyService = new();
        [HttpGet]//获取数据库中所有飞机
        public ActionResult<object> Get() => aircraftService.Get();
        [HttpGet("{identifier}")]//获取数据库中指定identifier的飞机
        public ActionResult<object> Get(string identifier) => aircraftService.Get(identifier);
        [HttpPost]//新建一个飞机
        public ActionResult Create(
            string identifier,
            string location,
            string company,
            string icao,
            string name,
            string securityKey)
        {
            if (!securityKeyService.Auth(securityKey, OpenVMSysConfigurations.SecurityPermission.Mid))
            {
                return BadRequest();
            }
            aircraftService.Create(new BsonDocument
            {
                {"Identifier", identifier},
                {"Company",company},
                {"Location",location},
                {"Hub",location},
                {"ICAO",icao},
                {"Name",name},
                {"FlightTime",0},
                {"Active",false},
                {"Status",1},
            });
            return Ok();
        }
        [HttpPatch]//转让一架飞机
        public ActionResult Transfer(string identifier, string target, string securityKey)
        {
            if (!securityKeyService.Auth(securityKey, OpenVMSysConfigurations.SecurityPermission.High))
            {
                return BadRequest();
            }
            aircraftService.Transfer(identifier, target);
            return Ok();
        }
        [HttpDelete]//删除一架飞机
        public ActionResult Delete(string identifier,string securityKey)
        {
            if(!securityKeyService.Auth(securityKey, OpenVMSysConfigurations.SecurityPermission.High))
            {
                return BadRequest();
            }
            aircraftService.Delete(identifier);
            return Ok();
        }
    }
}
