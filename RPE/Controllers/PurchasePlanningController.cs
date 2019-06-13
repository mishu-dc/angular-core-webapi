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
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;

namespace RPE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasePlanningController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public PurchasePlanningController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
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

            string rootFolder = _hostingEnvironment.WebRootPath;
            string fileName = "Purchase_Planning.xlsx";
            string path = Path.Combine(rootFolder, fileName);

            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }

            using (ExcelPackage package = new ExcelPackage(file))
            {

                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Planning");
                int totalRows = plannings.Count();

                string[] cols = new string[] { "Fiscal_Year",  "Division/Office", "Priority","Description","Vendor", "CAN","Object Class","Planned_Amount","Date","Status","Notes" };

                for(int i = 0;i < cols.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = cols[i];
                }

                for (int row = 2,i=0; row <= totalRows + 1; row++,i++)
                {
                    worksheet.Cells[row, 1].Value = plannings[i].FiscalYear;
                    worksheet.Cells[row, 2].Value = plannings[i].Division.Name;
                    worksheet.Cells[row, 3].Value = plannings[i].Priority;
                    worksheet.Cells[row, 4].Value = plannings[i].Description;
                    worksheet.Cells[row, 5].Value = plannings[i].Vendor;
                    worksheet.Cells[row, 6].Value = plannings[i].CanDescription;
                    worksheet.Cells[row, 7].Value = plannings[i].ObjectClass;
                    worksheet.Cells[row, 8].Value = plannings[i].PlanedAmount;
                    worksheet.Cells[row, 9].Value = plannings[i].PurchaseDate.ToString("MM-dd-yyyy");
                    worksheet.Cells[row, 10].Value = plannings[i].Status;
                    worksheet.Cells[row, 11].Value = plannings[i].Notes;
                }

                package.Save();

            }
            var bytes = System.IO.File.ReadAllBytes(path);

            const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            HttpContext.Response.Clear();
            HttpContext.Response.ContentType = contentType;
            HttpContext.Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");
            HttpContext.Response.Headers.Add("Content-Disposition", "attachment;filename=" + fileName);
            HttpContext.Response.Headers.Add("Content-Length", bytes.Length.ToString());

            var fileContentResult = new FileContentResult(bytes, contentType);
            
            return fileContentResult;           
        }
    }
}
