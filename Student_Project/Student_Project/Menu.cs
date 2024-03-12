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
            string? tempNome = string.Empty, tempCognome = string.Empty;
            StudentHelper manager = new();
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
                Console.WriteLine(new string('_', 30));
                Console.Write("\nScegli funzionalità: ");
                menuChoice = Console.ReadKey();

                switch ((Enums.enumsMenu)menuChoice.Key)
                {
                    case Enums.enumsMenu.Inserimento:
                        manager.Insert();
                        break;

                    case Enums.enumsMenu.Visualizzazione:
                        manager.Show();
                        Console.ReadLine();
                        break;
                    case Enums.enumsMenu.Ricerca://to-do ricerca per id, per nome e cognome, per età
                        Console.Clear();
                        Console.WriteLine("Inserisci i dati dello/degli studenti cercati");
                        Console.Write("Nome: ");
                        tempNome = Console.ReadLine();
                        Console.Write("Cognome: ");
                        tempCognome = Console.ReadLine();
                        manager.Search(tempNome, tempCognome);
                        Console.ReadLine();
                        break;
                    case Enums.enumsMenu.Eliminazione:
                        Console.Clear();
                        Console.WriteLine("Inserisci i dati dello/degli studenti cercati");
                        Console.Write("Nome: ");
                        tempNome = Console.ReadLine();
                        Console.Write("Cognome: ");
                        tempCognome = Console.ReadLine();
                        manager.Delete(tempNome, tempCognome);
                        break;
                }
            } while (menuChoice.Key.ToString() != "F");
        }
        
    }
}
