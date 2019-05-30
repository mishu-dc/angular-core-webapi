using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPE.Helper
{
    public class FiscalYearHelper
    {
        private static int[] _years = null;

        public static int[] Years
        {
            get
            {
                if (_years == null)
                {
                    _years = new int[] { 2019, 2018, 2017 };
                }
                return _years;
            }
        }
    }
}
