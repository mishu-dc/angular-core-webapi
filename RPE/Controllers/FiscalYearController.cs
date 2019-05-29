using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPE.Helper;

namespace RPE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiscalYearController : ControllerBase
    {
        [HttpGet]
        public int[] Get()
        {
            return FiscalYearHelper.Years;
        }
    }
}