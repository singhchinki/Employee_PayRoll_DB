using System;
using System.Collections.Generic;
using System.Data;
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
        //UC4- Create Record in Database
        public void createRecord()
        {
            SqlConnection connect = new SqlConnection(connectionString);
            using (connect)
            {
                connect.Open();
                EmployeePayRollUsingAdoNet.EmployeeProfile profile = new EmployeePayRollUsingAdoNet.EmployeeProfile();
                Console.WriteLine("Name of Employee:");
                profile.Name = Console.ReadLine();
                Console.WriteLine("salary of Employee:");
                profile.salary = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Start Date of Employee:");
                profile.DateTime = DateTime.Now;
                Console.WriteLine("Gender of Employee:");
                profile.gender = Console.ReadLine();
                Console.WriteLine("Contact of Employee:");
                profile.phone = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Address of Employee:");
                profile.address = Console.ReadLine();
                Console.WriteLine("Department of Employee:");
                profile.dept = Console.ReadLine();
                Console.WriteLine("Basic Pay of Employee:");
                profile.basicPay = Convert.ToDecimal(Console.ReadLine());
                SqlCommand command = new SqlCommand("SpAddEmployeeDetails", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", profile.Name);
                command.Parameters.AddWithValue("@salary", profile.salary);
                command.Parameters.AddWithValue("@startDate", profile.DateTime);
                command.Parameters.AddWithValue("@Gender", profile.gender);
                command.Parameters.AddWithValue("@phone_number", profile.phone);
                command.Parameters.AddWithValue("@address", profile.address);
                command.Parameters.AddWithValue("@department", profile.dept);
                command.Parameters.AddWithValue("@basic_pay", profile.basicPay);
                command.ExecuteNonQuery();
                Console.WriteLine("Record created successfully.");
                connect.Close();
            }
        }


    }
}
