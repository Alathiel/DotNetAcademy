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

    }
    #endregion
}
