using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
internal class Student
{
    [Key] // chiave unica
    public int Id { get; }
    [Required(ErrorMessage = "Errore, Nome obbligatoriamente di almeno 3 caratteri e massimo di 30!")] // va inserito per forza
    [MaxLength(30), MinLength(3)]
    public string? FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    [Required]
    [MaxLength(30)]
    public string? LastName { get; set; }
    [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})$")]
    public string? Email { get; set; }
    public string? Phone { get; set; }
    [Required]
    [Range(18, 120)]
    public int Age { get; set; }
    [Required]
    public Enums.Degree Degree { get; set; }
    public List<Activity> Activities { get; set; } = [];

    internal Student()
    {
        Id = StudentHelper.CreateKey();
        FirstName = string.Empty;
        MiddleName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Phone = string.Empty;
        Age = 0;
        Degree = Enums.Degree.Nessuno;
        Activities = [];
    }

    internal Student(string FirstName, string MiddleName, string LastName, string Email, string Phone, int Age, string Degree)
    {
        Id = StudentHelper.CreateKey();
        this.FirstName = FirstName;
        this.MiddleName = MiddleName;
        this.LastName = LastName;
        this.Email = Email;
        this.Phone = Phone;
        this.Age = Age;
        this.Degree = Enums.Degree.Nessuno;
        Activities = [];
    }

}

