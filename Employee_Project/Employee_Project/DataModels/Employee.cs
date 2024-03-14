using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Employee_Project.DataModels
{   
    internal class Employee
    {
        [Key] [Required] [JsonInclude]
        internal string? Id { get;}
        [JsonInclude] [MaxLength(30)] //[RegularExpression("^[a-zA-Z.]{2,} [a-zA-Z]{2,}$")] regex to check full name
        internal string? FullName { get; set; }
        [JsonInclude]
        internal string? JobRole { get; set; }
        [JsonInclude]
        internal string? Office { get; set; }
        [JsonInclude]
        internal string? Age { get; set; }
        [JsonInclude]
        internal string? Address { get; set; }
        [JsonInclude]
        internal string? City { get; set; }
        [JsonInclude]
        internal string? Province { get; set; }
        [JsonInclude]
        internal string? CAP {  get; set; }
        [JsonInclude]
        internal int? Phone { get; set; }
        [JsonInclude]
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
