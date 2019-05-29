using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPE.Entities;
using RPE.Helper;
using RPE.Models;

namespace RPE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasePlanningController : ControllerBase
    {
        [HttpGet]
        public PurchasePlanningModel Get(int fiscalyear, int divisionId, int canId, int pageSize = 10, int pageNo = 1, string sortBy = "")
        {
            var plannings = PurchasePlanningHelper.Plannings
                .Where(p => p.FiscalYear == fiscalyear || fiscalyear == 0)
                .Where(p => p.Division.Id == divisionId || divisionId == 0)
                .Where(p => p.Can.Id == canId || canId == 0 || canId == -1)
                .OrderBy(p=>p.Id)
                .Skip((pageNo - 1) * pageSize)
                .Take(pageSize)                
                .ToList<PurchasePlanning>();

            var totalCount = PurchasePlanningHelper.Plannings
                .Where(p => p.FiscalYear == fiscalyear || fiscalyear == 0)
                .Where(p => p.Division.Id == divisionId || divisionId == 0)
                .Where(p => p.Can.Id == canId || canId == 0 || canId == -1)
                .Count();

            var totalAmount = PurchasePlanningHelper.Plannings
                .Where(p => p.FiscalYear == fiscalyear || fiscalyear == 0)
                .Where(p => p.Division.Id == divisionId || divisionId == 0)
                .Where(p => p.Can.Id == canId || canId == 0 || canId == -1)
                .Sum(p => p.PlanedAmount);

            return new PurchasePlanningModel() {
                TotalCount = totalCount,
                TotalAmount = totalAmount,
                Plannings = plannings
            };
        }
    }
}