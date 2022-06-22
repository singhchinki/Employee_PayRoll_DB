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
        public string gender { get; set; }
        public double phone { get; set; }
        public string address { get; set; }
        public string dept { get; set; }
        public decimal basicPay { get; set; }
        public int deductions { get; set; }
        public int taxablePay { get; set; }
        public int incomeTax { get; set; }
        public int netPay { get; set; }
    }
}
