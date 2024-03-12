using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Project
{
    internal class Menu
    {
        internal static void Show()
        {
            

            ConsoleKeyInfo menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine(new string('*', 100));
                Console.WriteLine("*****************  GESTIONE STUDENTI ACADEMY  *****************");
                Console.WriteLine(new string('*', 100));
                Console.WriteLine("A) INSERIMENTO\n");
                Console.WriteLine("B) VISUALIZZAZIONE\n");
                Console.WriteLine("C) RICERCA\n");
                Console.WriteLine("D) ELIMINAZIONE\n");
                Console.WriteLine("E) INSERIMENTO CON VALIDATOR\n");
                Console.WriteLine(new string('_', 30));
                Console.Write("\nScegli funzionalità: ");
                menuChoice = Console.ReadKey();
                switch (menuChoice.Key.ToString().ToUpper())
                {
                    case "A":
                    Student.Insert(new Student());
                    break;

                    case "B":
                    break;

                    case "E":
                        Student.InsertValidation(new Student());
                        break;
                }
            } while (menuChoice.Key.ToString() != "F");
        }
        
    }
}
