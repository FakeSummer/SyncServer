using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SyncServer.Controllers
{

    [Route("api/verify")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISessionManager _manager;

        public LoginController(ISessionManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public ActionResult<Guid> Post([FromBody] Credentials userLoginRequest)
        {
            var isSuccess = Credentials.UserLog(userLoginRequest.Username, userLoginRequest.Password);

            if (isSuccess == true)
            {
                Guid token = Guid.NewGuid();
                _manager.SaveSession(token);
                return token;
            }
            return new UnauthorizedResult();
        }
    }
}