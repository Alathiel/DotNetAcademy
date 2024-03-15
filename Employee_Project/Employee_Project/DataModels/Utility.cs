using Employee_Project.BLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        internal static bool ExportEmployeesList(List<Employee> employees)
        {
            try
            {
                string tempEmployees = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true }); //tutti gli attributi degli oggetti che verranno stampati devono essere public altrimenti usare [JsonInclude]
                File.WriteAllText("F:\\Projects\\DotNetAcademy\\Employee_Project\\Employee_Project\\JsonEmployees.json", tempEmployees);
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
                string tempEmployees = File.ReadAllText("F:\\Projects\\DotNetAcademy\\Employee_Project\\Employee_Project\\JsonEmployees.json");
                return JsonSerializer.Deserialize<List<Employee>>(tempEmployees);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return [];
        }

        internal static void DatasValidator (Employee toValidate)
        {

            var context = new ValidationContext(toValidate, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(toValidate, context, validationResults, validateAllProperties: true);
        }

        internal static void DatasValidator(Activity toValidate)
        {

            var context = new ValidationContext(toValidate, serviceProvider: null, items: null);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(toValidate, context, validationResults, validateAllProperties: true);
        }

        internal static void SearchEmployee(List<Employee> employees)
        {
            Console.Clear();
            Console.Write("Inserisci il ruolo dell'employee: ");
            string? role = Console.ReadLine();
            Console.Write("Inserisci la citta': ");
            string? city = Console.ReadLine();


            List<Employee> filteredEmps = employees.FindAll(e => e.JobRole == role && e.City == city);
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
            var grpdEmps = employees.GroupBy(e => (e.FullName, e.Activities));
            foreach (var employee in grpdEmps)
            {
                Console.WriteLine(new string('*', 50));
                Console.WriteLine(employee.Key);
                Console.WriteLine(new string('*', 50));
                foreach (var e in employee) 
                { 
                    Console.WriteLine($"\nNome: {e.FullName}\n");
                    if (e.Activities.Count > 0) 
                    {
                        Console.WriteLine("Attivita' svolte: ");
                        foreach (var activity in e.Activities)
                        {
                            Console.WriteLine($"Tipo: {activity.Type}\nData: {activity.Date}\nOre lavorate: {activity.Hours}");
                        }
                    }
                    else 
                        Console.WriteLine("Non sono presenti attivita' svolte.\n\n");
                }
            }
        }

    }
    #endregion
}
