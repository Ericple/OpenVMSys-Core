using Microsoft.AspNetCore.Mvc;

namespace OpenVMSys_Core.Core.Account
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private static readonly AccountService _accountService = new();
        [HttpGet]//验证identifier与密码
        public ActionResult Auth(string identifier, string password)
        {
            if (_accountService.Auth(identifier, password))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost]//Register
        public ActionResult Create(
            string identifier,
            string email,
            string nickNane,
            string password,
            string hub)
        {
            try
            {
                _accountService.Register(identifier, email, nickNane, password, hub);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
