using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        public PurchasePlanningModel Get(int fiscalyear, int divisionId, int canId, int pageSize = 10, int pageNo = 1, string sortBy = "id", string sortDir = "asc")
        {
            List<PurchasePlanning> plannings = new List<PurchasePlanning>();

            var propertyInfo = this.GetPropertyInfo(sortBy);

            if (sortDir.ToLower().Equals("asc"))
            {
                plannings = PurchasePlanningHelper.Plannings
                    .Where(p => p.FiscalYear == fiscalyear || fiscalyear == 0)
                    .Where(p => p.Division.Id == divisionId || divisionId == 0)
                    .Where(p => p.Can.Id == canId || canId == 0 || canId == -1)
                    .OrderBy(p => propertyInfo.GetValue(p, null))
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .ToList<PurchasePlanning>();
            }
            else
            {
                plannings = PurchasePlanningHelper.Plannings
                    .Where(p => p.FiscalYear == fiscalyear || fiscalyear == 0)
                    .Where(p => p.Division.Id == divisionId || divisionId == 0)
                    .Where(p => p.Can.Id == canId || canId == 0 || canId == -1)
                    .OrderByDescending(p => propertyInfo.GetValue(p, null))
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .ToList<PurchasePlanning>();
            }

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

            return new PurchasePlanningModel()
            {
                TotalCount = totalCount,
                TotalAmount = totalAmount,
                Plannings = plannings
            };
        }

        private PropertyInfo GetPropertyInfo(string param)
        {
            string prop = "Id";
            switch (param.ToLower())
            {
                case "id":
                    prop = "Id";
                    break;
                case "priorityimgurl":
                    prop = "Priority";
                    break;
                case "fiscalyear":
                    prop = "FiscalYear";
                    break;
                case "description":
                    prop = "Description";
                    break;
                case "vendor":
                    prop = "Vendor";
                    break;
                case "candescription":
                    prop = "CanDescription";
                    break;
                case "objectclass":
                    prop = "ObjectClass";
                    break;
                case "planedamount":
                    prop = "PlanedAmount";
                    break;
                case "purchasedate":
                    prop = "PurchaseDate";
                    break;
                case "status":
                    prop = "Status";
                    break;
            }
            var propertyInfo = typeof(PurchasePlanning).GetProperty(prop);
            return propertyInfo;
        }

        [HttpGet("export")]
        public FileResult Export(int fiscalyear, int divisionId, int canId, string sortBy = "id", string sortDir = "asc")
        {
            List<PurchasePlanning> plannings = new List<PurchasePlanning>();

            var propertyInfo = this.GetPropertyInfo(sortBy);

            if (sortDir.ToLower().Equals("asc"))
            {
                plannings = PurchasePlanningHelper.Plannings
                    .Where(p => p.FiscalYear == fiscalyear || fiscalyear == 0)
                    .Where(p => p.Division.Id == divisionId || divisionId == 0)
                    .Where(p => p.Can.Id == canId || canId == 0 || canId == -1)
                    .OrderBy(p => propertyInfo.GetValue(p, null))                    
                    .ToList<PurchasePlanning>();
            }
            else
            {
                plannings = PurchasePlanningHelper.Plannings
                    .Where(p => p.FiscalYear == fiscalyear || fiscalyear == 0)
                    .Where(p => p.Division.Id == divisionId || divisionId == 0)
                    .Where(p => p.Can.Id == canId || canId == 0 || canId == -1)
                    .OrderByDescending(p => propertyInfo.GetValue(p, null))                  
                    .ToList<PurchasePlanning>();
            }

            var bytes = System.IO.File.ReadAllBytes(@"C:\Users\test\source\repos\RPE\RPE\RPE\Test.xlsx");

            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Response.ContentType = contentType;
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

            var fileContentResult = new FileContentResult(bytes, contentType)
            {
                FileDownloadName = "Test.xlsx"
            };

            return fileContentResult;
            //return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}