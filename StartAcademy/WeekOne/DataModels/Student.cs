using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy.WeekOne.DataModels
{
    internal class Student
    {
        [Key] // chiave unica
        public int Id { get; set; }
        [Required] // va inserito per forza
        [MaxLength(30),MinLength(3)]
        public string? FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        [Required]
        [MaxLength(30)]
        public string? LastName { get; set; }
        [RegularExpression("%@%.com")]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        [Required]
        [Range(18, 120)]
        public int Age { get; set; }
        [Required]
        public string? Degree { get; set; }

        internal Student()
        {
            Id = 0;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Age = 0;
            Degree = string.Empty;
        }

        internal Student(string FirstName, string MiddleName, string LastName, string Email, string Phone, int Age, string Degree)
        {
            Id = 0;
            this.FirstName = FirstName;
            this.MiddleName = MiddleName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Age = Age;
            this.Degree = Degree;
        }

        internal bool Insert(Student student)
        {
            try
            {

            }catch(Exception e)
            {
                Console.WriteLine("Error on insert: "+e);
            }
            return false;
        }
    }
}
