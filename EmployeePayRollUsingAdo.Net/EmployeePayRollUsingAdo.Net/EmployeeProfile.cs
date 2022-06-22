using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollUsingAdoNet
{
    internal class EmployeeProfile
    {
        public int id { get; set; }
       public string Name { get; set; }
       public decimal salary { get; set; }
       public DateTime DateTime { get; set; }
    }
}
