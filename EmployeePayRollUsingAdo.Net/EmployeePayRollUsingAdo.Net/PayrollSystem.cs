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
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Payroll_Service_DB;";
        //UC2 to get all data from Database
        public void getDataFromDatabase()
        {
            SqlConnection connect = new SqlConnection(connectionString);
            EmployeeProfile profile = new EmployeeProfile();
            using (connect)
            {
                connect.Open();
                string query = "Select * from employee_payroll";
                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("ID\t|\tName\t|\tSalary\t\t|\tDate\t\t\t|\tGender\t|\tPhone No\n-----------------------------------------------------------------------------------------------------------------------");
                    while (reader.Read())
                    {
                        profile.id = reader.GetInt32(0);
                        profile.Name = reader.GetString(1);
                        profile.salary = reader.GetDecimal(2);
                        profile.DateTime = reader.GetDateTime(3);
                        profile.gender = reader.GetString(4);
                        profile.phone = reader.GetInt64(5);
                        Console.WriteLine(profile.id + "\t|\t" + profile.Name + "\t|\t" + profile.salary + "\t|\t" + profile.DateTime + "\t|\t" + profile.gender + "\t|\t" + profile.phone);
                    }
                }
                else
                {
                    Console.WriteLine("Records not found in Database.");
                }
                reader.Close();
                connect.Close();
            }
        }
        //UC3 Update Basic Pay
        public void updateRecords()
        {
            SqlConnection connect = new SqlConnection(connectionString);
            try
            {
                using (connect)
                {
                    Console.WriteLine("Enter name of employee to update basic pay:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter basic pay to uodate:");
                    decimal salary = Convert.ToDecimal(Console.ReadLine());
                    connect.Open();
                    string query = "update employee_payroll set salary =" + salary + "where name='" + name + "'";
                    SqlCommand command = new SqlCommand(query, connect);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Records updated successfully.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("---------------------------\nError:Records are not updated.\n------------------------------");
            }
        }



    }
}
