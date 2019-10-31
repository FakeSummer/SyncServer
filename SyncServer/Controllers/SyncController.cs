using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SyncServer.Controllers
{
    [Route("api/sync")]
    [ApiController]
    public class SyncController : ControllerBase
    {
        private readonly IServerCompare _compare;

        public SyncController(IServerCompare compare)
        {
            _compare = compare;
        }

        [HttpPost("filecompare")]
        public ActionResult Post([FromBody] SyncFileInfo[] clientFiles)
        {
            return Ok();
        }

       /* [HttpPost("upload")]
        public ActionResult Post()
        {

        }

        [HttpPost("download")]
        public ActionResult Post()
        {

        }*/
    }
}