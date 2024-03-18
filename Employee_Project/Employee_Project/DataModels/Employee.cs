using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Employee_Project.DataModels
{
    public class Employee
    {
        [Key] [Required] [JsonInclude]
        public string? Id { get;}
        [JsonInclude] [MaxLength(30)] //[RegularExpression("^[a-zA-Z.]{2,} [a-zA-Z]{2,}$")] regex to check full name
        public string? FullName { get; set; }
        [JsonInclude]
        public string? JobRole { get; set; }
        [JsonInclude]
        public string? Office { get; set; }
        [JsonInclude]
        [Range(18, 120)]
        public int? Age { get; set; }
        [JsonInclude]
        public string? Address { get; set; }
        [JsonInclude]
        public string? City { get; set; }
        [JsonInclude]
        public string? Province { get; set; }
        [JsonInclude]
        public string? CAP {  get; set; }
        [JsonInclude]
        public int? Phone { get; set; }
        [JsonInclude]
        public List<Activity> Activities { get; set; } = [];

        public List<ValidationResult> errors { get; set; } = [];
        [JsonConstructor]
        public Employee()
        {
            Id = string.Empty;
            FullName = string.Empty;
            JobRole = string.Empty;
            Office = string.Empty;
            Age = 0;
            Address = string.Empty;
            City = string.Empty;
            Province = string.Empty;
            CAP = string.Empty;
            Phone = 0;
        }
        
        public Employee(string Id, string FullName, string JobRole, string Office, int Age, string Address, string City, string Province, string CAP, int Phone) 
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

        internal bool isValid()
        {
            return Validator.TryValidateObject(this, new ValidationContext(this), errors, true);
        }

    }
}
