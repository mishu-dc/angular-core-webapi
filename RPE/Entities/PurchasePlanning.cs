using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPE.Entities
{
    public class PurchasePlanning
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public int FiscalYear { get; set; }
        public Division Division { get; set; }
        public string Description { get; set; }
        public string Vendor { get; set; }
        public Can Can { get; set; }
        public string CanDescription { get; set; }
        public string ObjectClass { get; set; }
        public double PlanedAmount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public bool IsTag { get; set; }

    }
}
