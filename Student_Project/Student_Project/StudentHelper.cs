using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

internal class StudentHelper
{
    
    static List<Student> students { get; set; } = [];// nuovo metodo di implementazione, vecchio -> new List<Student>();

    #region Metodi public
    internal void Insert()
    {
        int counterId = 0;
        ConsoleKeyInfo temp;
        try
        {
            do
            {
                Student studentNew = new Student();
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

                if (!ContinueInsert())
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


                if (!ContinueInsert())
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

                if (!ContinueInsert())
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

                if (!ContinueInsert())
                    break;

                //Insert phone

                Console.Write("\nNumero di telefono: ");
                studentNew.Phone = Console.ReadLine();

                if (!ContinueInsert())
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

                if (!ContinueInsert())
                    break;

                //insert degree
                Console.Write("\nTitolo di studio: ");
                studentNew.Degree = Console.ReadLine();

                students.Add(studentNew);
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

    internal void InsertValidation(Student studentNew)
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


                if (!ContinueInsert())
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

                if (!ContinueInsert())
                    break;

                //Insert last name

                Console.Write("\nCognome: ");
                studentNew.LastName = Console.ReadLine();

                if (!ContinueInsert())
                    break;


                //insert email
                Console.Write("\nEmail: ");
                studentNew.Email = Console.ReadLine();

                if (!ContinueInsert())
                    break;

                //Insert phone

                Console.Write("\nNumero di telefono: ");
                studentNew.Phone = Console.ReadLine();

                if (!ContinueInsert())
                    break;

                //Insert age
                Console.Write("\nEtà: ");
                studentNew.Age = Convert.ToInt16(Console.ReadLine());

                if (!ContinueInsert())
                    break;

                //insert degree
                Console.Write("\nTitolo di studio: ");
                studentNew.Degree = Console.ReadLine();

                if (ValidatorDatas(studentNew))
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
    
    internal void Show()
    {
        students.ForEach(student =>
        {
            Console.Clear();
            Console.WriteLine("Studenti Inseriti\n\n");
            Console.WriteLine($"Nome: {student.FirstName}\nSecondo nome: {student.MiddleName}\nCognome: {student.LastName}" +
            $"\nEmail: {student.Email}\nPhone: {student.Phone}\nAge: {student.Age}\nDegree: {student.Degree}");
        }
        );
    }

    internal bool Delete(Student student)
    {
        return students.Remove(student);
    }

    internal bool Delete(string FirstName, string LastName)
    {
        Student student = students.Find(s => s.FirstName.ToLower() == FirstName.ToLower() && s.LastName.ToLower() == LastName.ToLower());
        if (student != null)
        {
            students.Remove(student);
            return true;
        }
        else
            return false;
    }

    internal bool Search(string FirstName, string LastName)
    {
        Student student = students.Find(s => s.FirstName.ToLower() == FirstName.ToLower() && s.LastName.ToLower() == LastName.ToLower());
        if (student == null)
        {
            Console.WriteLine("Lo studente cercato non è presente.");
            return false;
        }
        else
        {
            Console.WriteLine("\nDati dello/degli studenti trovati\n\n");
            Console.WriteLine($"Nome: {student.FirstName}\nSecondo nome: {student.MiddleName}\nCognome: {student.LastName}" +
            $"\nEmail: {student.Email}\nPhone: {student.Phone}\nAge: {student.Age}\nDegree: {student.Degree}");
        }
        return true;
    }

    public static int CreateKey()
    {
        Random rnd = new Random();
        do
        {
            int tempId = rnd.Next();
            if (students.Find(s => s.Id == tempId) != null)
                return tempId;
        } while (true);
    }

    #endregion

    #region Metodi private
    private static bool ContinueInsert()
    {
        ConsoleKeyInfo temp;
        do
        {
            Console.WriteLine("Vuoi continuare l'inserimento dei dati? Y/N");
            temp = Console.ReadKey();
            if (temp.Key.ToString().ToLower() != "y" && temp.Key.ToString().ToLower() != "n")
                Console.WriteLine("\nErrore, inserisci uno dei due valori richiesti.");
            else if (temp.Key.ToString().ToLower() == "n")
                return false;
        } while (temp.Key.ToString().ToLower() != "y" && temp.Key.ToString().ToLower() != "n");

        return true;
    }


    private static bool ValidatorDatas(Student student)
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
