using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
internal class Student
{
    [Key] // chiave unica
    public int Id { get; set; }
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

    #region Metodi public
    internal static void Insert(Student studentNew)
    {
        int counterId = 0;
        ConsoleKeyInfo temp;
        try
        {
            do
            {
                Console.Clear();
                Console.WriteLine("INSERIMENTO DATI STUDENTE");
                studentNew.Id = counterId;
                //insert name
                do
                {
                    Console.Write("Nome: ");
                    studentNew.FirstName = Console.ReadLine();
                    if (studentNew.FirstName.Length < 3 || studentNew.FirstName.Length > 30)
                        Console.WriteLine("Inserisci un nome compreso tra i 3 e i 30 caratteri.");
                } while (studentNew.FirstName.Length < 3 || studentNew.FirstName.Length > 30);

                if (!studentNew.ContinueInsert())
                    break;

                //insert middle name
                do
                {
                    Console.WriteLine("\nVuoi inserire un secondo nome? Y/N");
                    temp = Console.ReadKey();
                    if (temp.Key.ToString().ToLower() != "y" && temp.Key.ToString().ToLower() != "n")
                        Console.WriteLine("\nErrore, inserisci uno dei due valori richiesti.");

                    if (temp.Key.ToString().ToLower() == "y")
                    {
                        Console.Write("\nInserisci un secondo nome: ");
                        studentNew.MiddleName = Console.ReadLine();
                    }
                } while (temp.Key.ToString().ToLower() != "y" && temp.Key.ToString().ToLower() != "n");


                if (!studentNew.ContinueInsert())
                    break;

                //Insert last name
                do
                {
                    Console.Write("\nCognome: ");
                    studentNew.LastName = Console.ReadLine();
                    if (studentNew.LastName.Length > 30)
                    {
                        Console.WriteLine("Inserisci un cognome che non superi i 30 caratteri.");
                    }
                } while (studentNew.FirstName.Length > 30);

                if (!studentNew.ContinueInsert())
                    break;


                //insert email
                Match match;
                Regex emailRegex = new("^([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})$");
                do
                {
                    Console.Write("\nEmail: ");
                    studentNew.Email = Console.ReadLine();
                    match = emailRegex.Match(studentNew.Email);
                    if (!match.Success)
                    {
                        Console.WriteLine("Inserisci un'email valida.");
                    }
                } while (!match.Success);

                if (!studentNew.ContinueInsert())
                    break;

                //Insert phone

                Console.Write("\nNumero di telefono: ");
                studentNew.Phone = Console.ReadLine();

                if (!studentNew.ContinueInsert())
                    break;

                //Insert age
                do
                {
                    Console.Write("\nEtà: ");
                    studentNew.Age = Convert.ToInt16(Console.ReadLine());
                    if (studentNew.Age < 18 || studentNew.Age > 120)
                    {
                        Console.WriteLine("Inserisci un'età valida che sia compresa tra i 18 e i 120.");
                    }
                } while (studentNew.Age < 18 || studentNew.Age > 120);

                if (!studentNew.ContinueInsert())
                    break;

                //insert degree
                Console.Write("\nTitolo di studio: ");
                studentNew.Degree = Console.ReadLine();

                //continue insert
                do
                {
                    Console.WriteLine("Vuoi eseguire un altro inserimento? Premi Y/N ");
                    temp = Console.ReadKey();
                    if (temp.Key.ToString().ToLower() != "y" && temp.Key.ToString().ToLower() != "n")
                        Console.WriteLine("\n\nInserisci uno dei due valori permessi.");
                } while (temp.Key.ToString().ToLower() != "y" && temp.Key.ToString().ToLower() != "n");

                if (temp.Key.ToString().ToLower() != "y")
                    counterId++;

            } while (temp.Key.ToString().ToLower() == "y");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error on insert: " + e);
            Console.ReadKey();
        }
    }

    internal static void InsertValidation(Student studentNew)
    {
        ConsoleKeyInfo temp;
        try
        {
            do
            {
                Console.Clear();
                Console.WriteLine("INSERIMENTO DATI STUDENTE");

                //insert name
                Console.Write("Nome: ");
                studentNew.FirstName = Console.ReadLine();
                   

                if (!studentNew.ContinueInsert())
                    break;

                //insert middle name
                do
                {
                    Console.WriteLine("\nVuoi inserire un secondo nome? Y/N");
                    temp = Console.ReadKey();
                    if (temp.Key.ToString().ToLower() != "y" && temp.Key.ToString().ToLower() != "n")
                        Console.WriteLine("\nErrore, inserisci uno dei due valori richiesti.");

                    if (temp.Key.ToString().ToLower() == "y")
                    {
                        Console.Write("\nInserisci un secondo nome: ");
                        studentNew.MiddleName = Console.ReadLine();
                    }
                } while (temp.Key.ToString().ToLower() != "y" && temp.Key.ToString().ToLower() != "n");

                if (!studentNew.ContinueInsert())
                    break;

                //Insert last name
                
                Console.Write("\nCognome: ");
                studentNew.LastName = Console.ReadLine();

                if (!studentNew.ContinueInsert())
                    break;


                //insert email
                Console.Write("\nEmail: ");
                studentNew.Email = Console.ReadLine();

                if (!studentNew.ContinueInsert())
                    break;

                //Insert phone

                Console.Write("\nNumero di telefono: ");
                studentNew.Phone = Console.ReadLine();

                if (!studentNew.ContinueInsert())
                    break;

                //Insert age
                Console.Write("\nEtà: ");
                studentNew.Age = Convert.ToInt16(Console.ReadLine());

                if (!studentNew.ContinueInsert())
                    break;

                //insert degree
                Console.Write("\nTitolo di studio: ");
                studentNew.Degree = Console.ReadLine();

                if (studentNew.ValidatorDatas(studentNew))
                    Console.WriteLine("Dati inseriti con successo.");
                else Console.WriteLine("Dati non inseriti per via di un errore.");
                //continue insert
                do
                {
                    Console.WriteLine("Vuoi eseguire un altro inserimento? Premi Y/N ");
                    temp = Console.ReadKey();
                    if (temp.Key.ToString().ToLower() != "y" && temp.Key.ToString().ToLower() != "n")
                        Console.WriteLine("\n\nInserisci uno dei due valori permessi.");
                } while (temp.Key.ToString().ToLower() != "y" && temp.Key.ToString().ToLower() != "n");

            } while (temp.Key.ToString().ToLower() == "y");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error on insert: " + e);
            Console.ReadKey();
        }
    }

    #endregion

    #region Metodi private
    private bool ContinueInsert()
    {
        ConsoleKeyInfo temp;
        do
        {
            Console.WriteLine("Vuoi continuare l'inserimento dei dati? Y/N");
            temp = Console.ReadKey();
            if (temp.Key.ToString().ToLower() != "y" && temp.Key.ToString().ToLower() != "n")
                Console.WriteLine("\nErrore, inserisci uno dei due valori richiesti.");
            else if(temp.Key.ToString().ToLower() == "n")
                return false;
        } while (temp.Key.ToString().ToLower() != "y" && temp.Key.ToString().ToLower() != "n");

        return true;
    }


    private bool ValidatorDatas(Student student)
    {
        var context = new ValidationContext(student, serviceProvider: null, items: null);
        var results = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(student, context, results, validateAllProperties: true);

        if (isValid) { return true; }
        else
        {
            Console.WriteLine("Dati studente non validi");
            foreach (var validationResult in results)
            {
                Console.WriteLine(validationResult.ErrorMessage);
            }
            return false;
        }
    }

    #endregion
}

