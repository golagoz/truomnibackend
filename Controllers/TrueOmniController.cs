using ChallengesTrueOmni.MyData;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengesTrueOmni.Controllers
{


    [ApiController]
    [Route("api/[controller]")]    
    public class TrueOmniController : ControllerBase
    {
      
        [HttpGet("GetCards")]
      public IActionResult Get()
        {
            var data = new FakeData().GetAll();
            return Ok(data);    
        }



        [HttpGet("GetBy/{id}")]
        public IActionResult GetBy(long id)
        {
            var data = new FakeData().GetByOne(id);

            return Ok(data);
        }
    }
}
