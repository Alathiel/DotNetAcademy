
using Employee_Project.BLogic;
using Employee_Project.DataModels;

internal class Program{
    static void Main(string[] args)
    {
        EmployeeHelper employeeHelper = new EmployeeHelper();
        ActivityHelper activityHelper = new ActivityHelper();
        List<Employee> employees = [];
        List<Activity> activityList = [];

        try {
            //Console.WriteLine("Inserisci il percorso del file");
            string temp_path = "F:\\Projects\\DotNetAcademy\\Employee_Project\\Employee_Project\\Employees.txt";
            Console.WriteLine(temp_path);
            //string? path = Console.ReadLine();
            if (File.Exists(temp_path))
            {
                List<string> tempEmployees = File.ReadAllLines("F:\\Projects\\DotNetAcademy\\Employee_Project\\Employee_Project\\Employees.txt").ToList();
                List<string> tempActivities = File.ReadAllLines("F:\\Projects\\DotNetAcademy\\Employee_Project\\Employee_Project\\EmployeesActivities.txt").ToList();

                employees = employeeHelper.ImportEmployees(tempEmployees);
                activityList = activityHelper.ImportActivities(tempActivities, employees);

                employeeHelper.ShowEmployeeList(employees);
                activityHelper.ShowActivities(activityList);
                

            }
            else
                Console.WriteLine($"Il percorso inserito non contiene un file.");

        }catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}