using Employee_Project.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Project.BLogic
{
    internal class EmployeeHelper
    {
        internal List<Employee> ImportEmployees(List<string> employeeFile)
        {
            List<Employee> importedEmployees = [];
            employeeFile.ForEach(e => 
                { 
                    string [] tempArray = e.Split(';');
                    Employee employee = new Employee();

                    employee.Id = tempArray[0];
                    employee.FullName = tempArray[1];
                    employee.JobRole = tempArray[2];
                    employee.Office = tempArray[3];
                    employee.Age = tempArray[4];
                    employee.Sede = tempArray[5];
                    employee.City = tempArray[6];
                    employee.provincia = tempArray[7];
                    employee.Cap = tempArray[8];
                    employee.Matricola = Convert.ToInt32(tempArray[9]);

                    importedEmployees.Add(employee);
                }
            );

            return importedEmployees;
        }

        internal void ShowEmployeeList(List<Employee> employees)
        {
            Console.WriteLine("I lavoratori presenti nella lista sono i seguenti");
            employees.ForEach(e =>
                {
                    Console.WriteLine($"\n\nId: {e.Id}\nFull name: {e.FullName}\nJob role: {e.JobRole}\nOffice: {e.Office}\nAge: {e.Age}\nLocation: {e.Sede}\nCity: {e.City}\nProvincia: {e.provincia}\nCAP: {e.Cap}\nMatricola {e.Matricola}");
                    if (e.Activities.Count >0)
                    {
                        Console.WriteLine("\nAttivita' del lavoratore:");
                        e.Activities.ForEach(a =>
                        {
                            Console.WriteLine($"\nData: {a.Date}\nTitle: {a.Title}\nIDK: {a.Idk}\nWorker Id: {a.WorkerId}");
                        });
                    }
                }
            );
        }


    }
}
