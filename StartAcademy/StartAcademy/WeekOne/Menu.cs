using StartAcademy.WeekOne.BLogic;
using StartAcademy.WeekOne.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademy.WeekOne
{
    internal class Menu
    {
        internal static void Show()
        {
            StudentManager studentManager = new StudentManager();   
            /*Monday11 monday11 = new()
            {
                Test = "Claudio"
            };

            string genre = monday11.isMale(monday11.Test.ToLower(), "Orloff", 51) ? "Male" : "Female";
            Console.WriteLine($"Hello world, by: {monday11.Test}, that is {genre}");

            Console.WriteLine(new string('*',100)); // creami una stringa con 100 asterischi
            Console.Write("Inserisci il tuo nome: ");
            string? Name = Console.ReadLine(); // variabile che accetta anche null 
            Console.Clear();*/

            ConsoleKeyInfo menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine(new string('*', 100));
                Console.WriteLine("*****************  GESTIONE ACADEMYS MICROSOFT .NET  *****************");
                Console.WriteLine(new string('*', 100));
                Console.WriteLine("A) INSERIMENTO\n");
                Console.WriteLine("B) VISUALIZZAZIONE\n");
                Console.WriteLine("C) RICERCA\n");
                Console.WriteLine("D) ELIMINAZIONE\n");
                Console.WriteLine(new string('_', 30));
                Console.Write("\nScegli funzionalità: ");
                menuChoice = Console.ReadKey();
                switch (menuChoice.Key.ToString().ToUpper())
                {
                    case "A":
                        studentManager.InsertStudent(new Student());
                        break;
                }
            } while (menuChoice.Key.ToString() != "F");
        }
        
    }
}
