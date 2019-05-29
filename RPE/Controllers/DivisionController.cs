using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPE.Entities;
using RPE.Helper;

namespace RPE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        [HttpGet]
        public List<Division> Get()
        {
            return DivisionHelper.Divisions;
        }
    }
}