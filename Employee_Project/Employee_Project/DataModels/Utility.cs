using Employee_Project.BLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Employee_Project.DataModels
{
    internal class Utility
    {
        static EmployeeHelper employeeHelper = new EmployeeHelper();

        #region Public methods
        internal static bool ExportListToJSON(List<Employee> employees)
        {
            try
            {
                Console.Clear();
                Console.Write("Inserisci il nome che dovra' avere il file esportato: ");
                string fileName = Console.ReadLine();
                string tempEmployees = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true }); //tutti gli attributi degli oggetti che verranno stampati devono essere public altrimenti usare [JsonInclude]
                File.WriteAllText(ConfigurationManager.AppSettings["ProjectPath"] + @"\"+fileName+".json", tempEmployees);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
        
        internal static List<Employee> ImportEmployeesList() //not working
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions { IncludeFields = true };
                string? tempEmployees = File.ReadAllText("F:\\Projects\\DotNetAcademy\\Employee_Project\\Employee_Project\\JsonEmployees.json");
                return JsonSerializer.Deserialize<List<Employee>>(tempEmployees, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return [];
        }

        internal static void SearchEmployee(List<Employee> employees)
        {
            Console.Clear();
            Console.Write("Inserisci il ruolo dell'employee: ");
            string? role = Console.ReadLine();
            Console.Write("Inserisci la citta': ");
            string? city = Console.ReadLine();


            List<Employee> filteredEmps = employees.FindAll(e => e.JobRole.ToLower() == role.ToLower() && e.City.ToLower() == city.ToLower());
            employeeHelper.ShowEmployeeList(filteredEmps);
        }

        internal static void GrpByCity(List<Employee> employees)
        {
            Console.Clear();
            var grpdEmps = employees.GroupBy(e => e.City);
            foreach (var employee in grpdEmps) {
                Console.WriteLine(new string('*',50));
                Console.WriteLine(employee.Key.ToUpper());
                Console.WriteLine(new string('*', 50));
                foreach (var e in employee.OrderBy(emp => emp.FullName))
                    Console.WriteLine($"Name: {e.FullName}\nJob role: {e.JobRole}\nAge: {e.Age}\n\n");
            }
        }

        internal static void GrpByRoleOffice(List<Employee> employees)
        {
            Console.Clear();
            var grpdEmps = (employees.FindAll(e => e.Age > 45)).GroupBy(e => (e.JobRole, e.Office));
            foreach (var employee in grpdEmps)
            {
                Console.WriteLine(new string('*', 50));
                Console.WriteLine(employee.Key);
                Console.WriteLine(new string('*', 50));
                foreach (var e in employee)
                    Console.WriteLine($"Name: {e.FullName}\nJob role: {e.JobRole}\nAge: {e.Age}\n\n");
            }
        }

        internal static void GrpByNameActivity(List<Employee> employees, List<Activity> activities)
        {
            Console.Clear();
            //foreach (var employee in employees.GroupBy(e => (e.FullName, (e.Activities.DistinctBy(act => act.Type)))))
            //foreach (var a in activities.DistinctBy(act => act.Type)){ 
            //foreach (var employee in employees.GroupBy(e => (e.FullName, a)))
            foreach (var employee in employees.GroupBy(e => (e.FullName, e.Activities)))
            {
                /*Console.WriteLine("\n\n"+new string('*', 50));
                Console.WriteLine(employee.Key);
                Console.WriteLine(new string('*', 50));*/
                foreach (var e in employee) 
                {
                    Console.WriteLine("\n\n" + new string('*', 50));
                    Console.WriteLine($"Nome: {e.FullName}");
                    Console.WriteLine(new string('*', 50));
                    if (e.Activities.Count > 0) 
                    {
                        Console.WriteLine("\nTipi di attivita' svolte: ");
                        foreach (var activity in e.Activities.DistinctBy(act => act.Type))
                        {
                            Console.WriteLine(activity.Type);
                        }
                    }
                    else 
                        Console.WriteLine("\nNon sono presenti attivita' svolte.\n\n");
                }
            }
        }

    }
    #endregion
}
