using Microsoft.AspNetCore.Mvc;
using OpenVMSys_Core.Core.Security;

namespace OpenVMSys_Core.Core.Pilot
{
    [ApiController]
    [Route("api/pilot")]
    public class PilotController : ControllerBase
    {
        private static readonly PilotService PilotService = new();
        private static readonly SecurityKeyService securityKeyService = new();
        [HttpGet]//获取用户信息
        public ActionResult<object> Get() => PilotService.Get();
        [HttpGet("{identifier}")]//获取指定identifier的用户信息
        public ActionResult<object> Get(string identifier) 
            => PilotService.Get(identifier);
        [HttpPatch]//更换公司
        public ActionResult<long> Transfer(
            string identifier, 
            string target, 
            string securityKey)
        {
            if (!securityKeyService.Auth(securityKey,OpenVMSysConfigurations.SecurityPermission.High))
            {
                return BadRequest();
            }
            return PilotService.Transfer(identifier, target);
        }
    }
}
