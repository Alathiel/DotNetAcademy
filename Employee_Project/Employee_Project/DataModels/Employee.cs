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
        internal string? Sede { get; set; }
        internal string? City { get; set; }
        internal string? provincia { get; set; }
        internal string? Cap {  get; set; }
        internal int? Matricola { get; set; }
        internal List<Activity> Activities { get; set; } = [];

    }
}
