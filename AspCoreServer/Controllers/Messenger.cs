using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspCoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Messenger : ControllerBase
    {
       

        // GET api/<Messenger>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Hochu v vdv" + id.ToString();
        }

        // POST api/<Messenger>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

      
    }
}
