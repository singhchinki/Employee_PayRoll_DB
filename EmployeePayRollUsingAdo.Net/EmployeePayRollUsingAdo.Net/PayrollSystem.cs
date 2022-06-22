using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayRollUsingAdoNet
{
    internal class PayrollSystem
    {
        public static string dbpath = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Service_DB;Integrated Security=True";
        SqlConnection connect = new SqlConnection(dbpath);
        
      /*  public void DatabseConnection()
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
        }*/
        //UC2 to get all data from Database
        public void getDataFromDatabase()
        {
            EmployeeProfile profile = new EmployeeProfile();
            connect.Open();
            using (connect)
            {
                string query = "Select * from employee_Payroll";

                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("ID\t|\tName\t|\tSalary\t\t|\tDate\n------------------------------------------------------------------------------");
                    while (reader.Read())
                    {
                        profile.id = reader.GetInt32(0);
                        profile.Name = reader.GetString(1);
                        profile.salary = reader.GetDecimal(2);
                        profile.DateTime = reader.GetDateTime(3);
                        Console.WriteLine(profile.id + "\t|\t" + profile.Name + "\t|\t" + profile.salary + "\t|\t" + profile.DateTime);
                    }
                }
                else
                {
                    Console.WriteLine("Records not found in Database.");
                }
                reader.Close();

            }
            connect.Close();
        }


    }
}
