using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CSC4151_ProfileService.Controllers
{
    [ApiController]
    [Route("Ping")]
    public class PingController : ControllerBase
    {

        [HttpGet]
        public string Ping()
        {
            return "Profile Pong";
        }
    }
}
