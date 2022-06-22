EmployeePayRollUsingAdoNet.PayrollSystem payrollSystem = new EmployeePayRollUsingAdoNet.PayrollSystem();

Console.WriteLine("SQL Operations:\n0.Exit\n1.Show Data\n2.Update Data\nEnter your choice:");
int choice = Convert.ToInt32(Console.ReadLine());
while (choice != 0)
{
    switch (choice)
    {
        case 1:
            payrollSystem.getDataFromDatabase();
            break;
        case 2:
            payrollSystem.updateRecords();
            break;
        default:
            Console.WriteLine("Enter Valid choice.");
            break;
    }
    Console.WriteLine("SQL Operations:\n0.Exit\n1.Show Data\n2.Update Data\nEnter your choice:");
    choice = Convert.ToInt32(Console.ReadLine());
}



