using RPE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPE.Helper
{
    public class CanHelper
    {
        private static List<Can> _cans = null;
        private CanHelper()
        {

        }
        public static List<Can> Cans
        {
            get
            {
                if (_cans == null)
                {
                    _cans = new List<Can>();

                    string[] values = new string[] {
                        "All",
                        "8325899",
                        "8485899",
                        "8958899",
                        "8365899",
                        "8258899",
                        "7825899",
                        "2569899",
                        "1125899",
                        "9685899"
                    };

                    for (int i = 0; i < values.Length; i++)
                    {
                        if (i == 0)
                        {
                            _cans.Add(new Can() { Id = -1, Name = values[i] });
                        }
                        else
                        {
                            _cans.Add(new Can() { Id = i + 1, Name = values[i] });
                        }
                    }

                }
                return _cans;
            }
        }
    }
}
