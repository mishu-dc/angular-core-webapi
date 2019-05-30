using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPE.Entities
{
    public class Can : IComparer<Can>
    {
        public int Id;
        public string Name;

        public int Compare(Can x, Can y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
