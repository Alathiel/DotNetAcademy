using Employee_Project.DataModels;
using System.Configuration;

namespace Employee_Project.BLogic
{
    internal class EmployeeHelper
    {
        #region Public Methods 
        internal List<Employee> ImportEmployees()
        {
            List<Employee> importedEmployees = [];
            try
            {
                //List<string> tempEmployees = File.ReadAllLines(ConfigurationManager.AppSettings["ProjectPath"]+""+ConfigurationManager.AppSettings["EmployeesPath"]).ToList(); //prende il path dal file app.config
                List<string> tempEmployees = FileUtility.Utility.ImportTXTFile(ConfigurationManager.AppSettings["ProjectPath"]);
                tempEmployees.ForEach(e => 
                {
                    string [] tempArray = e.Split(';');
                    Employee employee = new Employee(tempArray[0], tempArray[1], tempArray[2], tempArray[3], Convert.ToInt16(tempArray[4]), tempArray[5], tempArray[6], tempArray[7], tempArray[8], Convert.ToInt32(tempArray[9]));
  
                    if (employee.isValid())
                            importedEmployees.Add(employee);
                        else 
                        {
                            Console.WriteLine("Oggetto non aggiunto per via dei seguenti errori: ");
                            employee.errors.ForEach(e =>
                            {
                                Console.WriteLine(e);
                            });
                        }
                });
            }
            catch (Exception ex) { Console.WriteLine(ex); }

            return importedEmployees;
        }

        internal void ShowEmployeeList(List<Employee> employees)
        {
            if(employees.Count > 0) { 
                Console.WriteLine("I lavoratori presenti nella lista sono i seguenti");
                employees.ForEach(e =>
                    {
                        Console.WriteLine($"\n\nId: {e.Id}\nFull name: {e.FullName}\nJob role: {e.JobRole}\nOffice: {e.Office}\nAge: {e.Age}\nAddress: {e.Address}\nCity: {e.City}\nProvince: {e.Province}\nCAP: {e.CAP}\nPhone {e.Phone}");
                        if (e.Activities.Count > 0)
                        {
                            Console.WriteLine("\nAttivita' del lavoratore:");
                            e.Activities.ForEach(a =>
                            {
                                Console.WriteLine($"\nData: {a.Date}\nType: {a.Type}\nHours: {a.Hours}\nWorker Id: {a.WorkerId}");
                            });
                        }
                        else
                            Console.WriteLine("\nNon risultano attivita' per il lavoratore.");
                    }
                );
            }
            else
                Console.WriteLine("Nella lista non sono presenti employees.");
        }

        #endregion
    }
}
