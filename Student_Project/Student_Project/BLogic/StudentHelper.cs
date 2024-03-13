using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

internal class StudentHelper
{
    
    public static List<Student> students { get; set; } = [];// nuovo metodo di implementazione, vecchio -> new List<Student>();

    #region Metodi public
    internal void Insert()
    {
        ConsoleKeyInfo temp;
        try
        {
            do
            {
                Student studentNew = new Student();
                Console.Clear();
                Console.WriteLine("INSERIMENTO DATI STUDENTE");
                //insert name
                do
                {
                    Console.Write("Nome: ");
                    studentNew.FirstName = Console.ReadLine();
                    if (studentNew.FirstName.Length < 3 || studentNew.FirstName.Length > 30)
                        Console.WriteLine("Inserisci un nome compreso tra i 3 e i 30 caratteri.");
                } while (studentNew.FirstName.Length < 3 || studentNew.FirstName.Length > 30);

                

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

                

                //Insert phone

                Console.Write("\nNumero di telefono: ");
                studentNew.Phone = Console.ReadLine();

                

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

                

                //insert degree
                Console.Write("\nTitolo di studio: ");
                studentNew.Degree = (Enums.Degree)Enum.Parse(typeof(Enums.Degree),Console.ReadLine());

                students.Add(studentNew);
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

    /*internal void InsertValidation(Student studentNew)
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
                studentNew.Degree = (Enums.Degree)Enum.Parse(typeof(Enums.Degree), Console.ReadLine());

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
    }*/
    
    internal void Show()
    {
        try {
            Console.Clear();
            if (students.Count() > 0) {
                Console.WriteLine("Studenti Inseriti");
                students.ForEach(student =>
                {
                    Console.WriteLine($"\n\nId: {student.Id}\nNome: {student.FirstName}\nSecondo nome: {student.MiddleName}\nCognome: {student.LastName}" +
                    $"\nEmail: {student.Email}\nPhone: {student.Phone}\nAge: {student.Age}\nDegree: {student.Degree}");
                });
            }
            else
                Console.WriteLine("Non hai ancora inserito studenti.");
        }
        catch (Exception e) 
        { 
            Console.WriteLine(e); 
            Console.ReadLine(); 
        }
    }

    internal bool Delete(string FirstName, string LastName, string Age)
    {
        List<Student> tempStudents = checkSearchString(FirstName, LastName, Age);

        if (tempStudents.Count > 0)
        {
            tempStudents.ForEach(s=> 
                {
                    students.Remove(s);
                }
            );
            
            return true;
        }
        else
            return false;
    }

    internal void Search(string FirstName, string LastName, string Age = "0")
    {
        try
        {
            List<Student> tempStudents = checkSearchString(FirstName, LastName, Age);
            

            if (tempStudents.Count() == 0)
            {
                Console.WriteLine("Lo/Gli studente/i cercato non è/sono presente/i.");
            }
            else
            {
                Console.WriteLine("Dati degli studenti cercati");
                tempStudents.ForEach(student =>
                {
                    Console.WriteLine($"\n\nId: {student.Id}\nNome: {student.FirstName}\nSecondo nome: {student.MiddleName}\nCognome: {student.LastName}" +
                    $"\nEmail: {student.Email}\nPhone: {student.Phone}\nAge: {student.Age}\nDegree: {student.Degree}");
                });
            }

        }catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    /*internal void Search(List <string> datas)
    {
        try
        {
            List<Student> tempStudents = students.FindAll(s => s.FirstName.ToLower() == FirstName.ToLower() && s.LastName.ToLower() == LastName.ToLower());
            if (tempStudents.Count() == 0)
            {
                Console.WriteLine("Lo/Gli studente/i cercato non è/sono presente/i.");
            }
            else
            {
                Console.WriteLine("Dati degli studenti cercati");
                tempStudents.ForEach(student =>
                {
                    Console.WriteLine($"\n\nId: {student.Id}\nNome: {student.FirstName}\nSecondo nome: {student.MiddleName}\nCognome: {student.LastName}" +
                    $"\nEmail: {student.Email}\nPhone: {student.Phone}\nAge: {student.Age}\nDegree: {student.Degree}");
                });
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }*/
    
    #endregion


    #region Metodi public
    public static int CreateKey()
    {
        Random rnd = new Random();
        do
        {
            int tempId = rnd.Next();
            if (students.Find(s => s.Id == tempId) == null)
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

    /// <summary>
    /// Check input string for search
    /// </summary>
    /// <param name="FirstName"></param>
    /// <param name="LastName"></param>
    /// <param name="Age"></param>
    /// <returns></returns>
    private List<Student> checkSearchString(string FirstName, string LastName, string Age)
    {
        bool checkAge = true;

        if (string.IsNullOrEmpty(Age))
            checkAge = false;
        else
        {
            foreach (char a in Age)
            {
                if (char.IsLetter(a))
                {
                    Console.WriteLine("L'eta' inserita non e' valida, verra' eseguita la ricerca con gli altri valori inseriti.");
                    checkAge = false;
                    break;
                }
            }
        }

        if (string.IsNullOrEmpty(FirstName))
        {
            if (string.IsNullOrEmpty(LastName))
            {
                if (checkAge)
                    return students.FindAll(s => s.Age == Convert.ToInt16(Age));
                else
                    Console.WriteLine("\nNon sono stati inseriti dati validi per eseguire la ricerca.");
            }

            else
            {
                if (checkAge)
                    return students.FindAll(s => s.LastName.ToLower() == LastName.ToLower() && s.Age == Convert.ToInt16(Age));
                else
                    return students.FindAll(s => s.LastName.ToLower() == LastName.ToLower());
            }
        }
        else
        {
            if (string.IsNullOrEmpty(LastName))
            {
                if (checkAge)
                    return students.FindAll(s => s.FirstName.ToLower() == FirstName.ToLower() && s.Age == Convert.ToInt16(Age));
                else
                    return students.FindAll(s => s.FirstName.ToLower() == FirstName.ToLower());
            }

            else
            {
                if (checkAge)
                    return students.FindAll(s => s.FirstName.ToLower() == FirstName.ToLower() && s.LastName.ToLower() == LastName.ToLower() && s.Age == Convert.ToInt16(Age));
                else
                    return students.FindAll(s => s.FirstName.ToLower() == FirstName.ToLower() && s.LastName.ToLower() == LastName.ToLower());
            }
        }

        return [];
    }

    #endregion
}
