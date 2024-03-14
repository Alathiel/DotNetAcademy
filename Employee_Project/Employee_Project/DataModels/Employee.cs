using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Employee_Project.DataModels
{   
    internal class Employee
    {
        [Key]
        internal string? Id { get; set; }
        internal string? FullName { get; set; }
        internal string? JobRole { get; set; }
        internal string? Office { get; set; }
        internal string? Age { get; set; }
        internal string? Address { get; set; }
        internal string? City { get; set; }
        internal string? Province { get; set; }
        internal string? CAP {  get; set; }
        internal int? Phone { get; set; }
        internal List<Activity> Activities { get; set; } = [];

        internal Employee()
        {
            Id = string.Empty;
            FullName = string.Empty;
            JobRole = string.Empty;
            Office = string.Empty;
            Age = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            Province = string.Empty;
            CAP = string.Empty;
            Phone = 0;
        }

        internal Employee(string Id, string FullName, string JobRole, string Office, string Age, string Address, string City, string Province, string CAP, int Phone) 
        {
            this.Id = Id;
            this.FullName = FullName;
            this.JobRole = JobRole;
            this.Office = Office;
            this.Age = Age;
            this.Address = Address;
            this.City = City;
            this.Province = Province;
            this.CAP = CAP;
            this.Phone = Phone;
        }  

    }
}
