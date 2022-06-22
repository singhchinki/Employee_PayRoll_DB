EmployeePayRollUsingAdoNet.PayrollSystem payrollSystem = new EmployeePayRollUsingAdoNet.PayrollSystem();

Console.WriteLine("SQL Operations:\n0.Exit\n1.Show Data\n2.Update Data\n3.Create Record\n4.Delete Record\nEnter your choice:");
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
        case 3:
            payrollSystem.createRecord();
            break;
        case 4:
            payrollSystem.DeleteRecord();
            break;
        default:
            Console.WriteLine("Enter Valid choice.");
            break;
    }
    Console.WriteLine("SQL Operations:\n0.Exit\n1.Show Data\n2.Update Data\n3.Create Record\n4.Delete Record\nEnter your choice:");
    choice = Convert.ToInt32(Console.ReadLine());
}



