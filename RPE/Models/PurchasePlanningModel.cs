using RPE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPE.Models
{
    public class PurchasePlanningModel
    {
        public int TotalCount { get; set; }
        public double TotalAmount { get; set; }
        public List<PurchasePlanning> Plannings { get; set; }

    }
}
