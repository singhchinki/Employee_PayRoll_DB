using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollUsingAdo.Net
{
    internal class PayrollSystem
    {
        public static string dbpath = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Service_DB;Integrated Security=True";
        SqlConnection connect = new SqlConnection(dbpath);
        
        public void DatabseConnection()
        {
            try
            {
                connect.Open();
                using (connect)
                {
                    Console.WriteLine("Database connectivity successful.");
                }
                connect.Close();
            }
            catch
            {
                Console.WriteLine("Database connectivity failed");
            }
        }

    }
}
