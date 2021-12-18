using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystem
{
class IntCompare : IComparer<int>
    {
        public int Compare(int o1, int o2)
        {
            if (o1 > o2)
            {
                return 1;
            }
            else if (o1 < o2)
            {
                return -1;
            }

            return 0;
        }
    }
}
