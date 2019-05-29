using RPE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPE.Helper
{
    public class PurchasePlanningHelper
    {
        private static List<PurchasePlanning> _plannings = null;
        private PurchasePlanningHelper()
        {

        }

        private static string GetRandomVendor()
        {
            string[] vendors = new string[]
            {
                "Staples",
                "Best Buy",
                "Apple",
                "Microsoft",
                "",
                ""
            };
            int index = RandomNumber(0, vendors.Length);
            return vendors[index];
        }

        private static string GetRandomDate()
        {
            int year = RandomNumber(2017, 2019);
            int month = RandomNumber(1, 12);
            int day = RandomNumber(1, 28);

            return new DateTime(year, month, day).ToString("MM/dd/yyyy");
        }

        private static string GetRandomClass()
        {
            string[] objectClass = new string[]
               {
                "266L",
                "multi",
                "",
                "",
                "",
                ""
               };
            int index = RandomNumber(0, objectClass.Length);
            return objectClass[index];

        }

        private static string GetRandomNotes()
        {
            string[] notes = new string[]
            {
                "In process",
                "Awaiting quotes",
                "Need task specifics",
                "",
                "",
                ""
            };
            int index = RandomNumber(0, notes.Length);
            return notes[index];
        }

        private static Division GetRandomDivision()
        {
            int index = RandomNumber(0, DivisionHelper.Divisions.Count);
            return DivisionHelper.Divisions[index];
        }

        private static string GetRandomDescription()
        {
            string[] descs = new string[]
            {
                "Office Supply",
                "MTD Service-November",
                "Window Laptop-HR",
                "Audio Bluetooth Receiver",
                "New iPhone",
                "New SSD Laptop",
                "MTD Service-Jan",
                "MTD Service-Feb",
                "MTD Service-March",
                "MTD Service-April",
                "MTD Service-June",
                "MTD Service-July",
                "MTD Service-Dec",
                "Relocation",
            };
            int index = RandomNumber(0, descs.Length);
            return descs[index];
        }

        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private static Can GetRandomCan()
        {
            int index = RandomNumber(1, CanHelper.Cans.Count);
            return CanHelper.Cans[index];
        }


        private static int GetRandomFiscalYear()
        {
            int index = RandomNumber(0, FiscalYearHelper.Years.Length);
            return FiscalYearHelper.Years[index];
        }

        public static List<PurchasePlanning> Plannings
        {
            get
            {
                if (_plannings == null)
                {
                     _plannings = new List<PurchasePlanning>();

                    for (int i = 0; i < 1000; i++)
                    {
                        PurchasePlanning planning = new PurchasePlanning();
                        planning.Id = i + 1;
                        planning.Can = GetRandomCan();
                        planning.Description = GetRandomDescription();
                        planning.Division = GetRandomDivision();
                        planning.FiscalYear = GetRandomFiscalYear();
                        planning.IsTag = i % 4 == 0;
                        planning.Notes = GetRandomNotes();
                        planning.ObjectClass = GetRandomClass();
                        planning.PlanedAmount = RandomNumber(100, 80000) * 1.0;
                        planning.Priority = RandomNumber(1, 5);
                        planning.PurchaseDate = GetRandomDate();
                        planning.Status = "Planning";
                        planning.Vendor = GetRandomVendor();

                        _plannings.Add(planning);
                    }
                }
                return _plannings;
            }
        }

    }


}
