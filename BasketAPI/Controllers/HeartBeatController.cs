using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BasketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeartBeatController : ControllerBase
    {
        // GET api/heartbeat
        [HttpGet]
        public ActionResult Ping()
        {
            return Ok(1);
        }
    }
}
