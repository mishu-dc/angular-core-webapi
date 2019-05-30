using RPE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPE.Helper
{
    public class DivisionHelper
    {
        private static List<Division> _divisions = null;
        private DivisionHelper()
        {

        }

        public static List<Division> Divisions
        {
            get
            {
                if (_divisions == null)
                {
                    var values = new string[] { "OCICB", "OCICD", "OCICE", "OCICF", "OCICG", "OCICH", "OCICI", "OCICJ" };

                    _divisions = new List<Division>();
                    for (int i = 0; i < values.Length; i++)
                    {
                        _divisions.Add(new Division() { Id = i + 1, Name = values[i] });
                    }
                }
                return _divisions;
            }
        }
    }
}
