using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace OpenVMSys_Core.Core.Authorization
{
    [ApiController]
    [Route("api/auth")]
    public class AuthorizationController : ControllerBase
    {
        private static readonly AuthorizationService _authorizationService = new();
        [HttpGet]
        public ActionResult<string> Validate(string token, string clientIdentifier)
        {
            if(_authorizationService.Validate(token, clientIdentifier))
            {
                return "验证成功，现在可以关闭该页面并返回客户端";
            }
            return BadRequest();
        }
        [HttpPost]
        public ActionResult<string> Create(string identifier, string clientIdentifier)
        {
            var token = _authorizationService.GenerateToken(18);
            var authObj = new BsonDocument
        {
            { "Token", token },
            { "Identifier", identifier },
            { "ClientIdentifier", clientIdentifier },
            { "Status", false }
        };
            _authorizationService.Create(authObj);
            return token;
        }
        [HttpDelete]
        public ActionResult<long> Delete(string identifier)
        {
            if (_authorizationService.Delete(identifier) > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

    }
}
