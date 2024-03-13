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
            string? tempFirstName = string.Empty, tempLastName = string.Empty, tempAge;
            StudentHelper manager = new();
            ConsoleKeyInfo menuChoice;

            try
            {
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

                    switch ((Enums.Menu)menuChoice.Key)
                    {
                        case Enums.Menu.Inserimento:
                            manager.Insert();
                            break;

                        case Enums.Menu.Visualizzazione:
                            manager.Show();
                            Console.ReadLine();
                            break;

                        case Enums.Menu.Ricerca://to-do ricerca per id, per nome e cognome, per età
                            Console.Clear();
                            //test inserimento di una sola stringa e dividendola nei singoli dati
                            //Console.WriteLine("Inserisci i dati dello/degli studenti cercati dividendoli con una virgola (il carattere ',')");
                            //string st = Console.ReadLine();
                            //List<string> tempString = st.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
                            Console.WriteLine("Inserisci i dati dello/degli studenti cercati, per i dati non interessati premere semplicemente invio.");
                            Console.Write("Nome: ");
                            tempFirstName = Console.ReadLine();
                            Console.Write("Cognome: ");
                            tempLastName = Console.ReadLine();
                            Console.Write("Eta': ");
                            tempAge = Console.ReadLine();

                            manager.Search(tempFirstName, tempLastName, tempAge);
                            Console.ReadLine();
                            break;

                        case Enums.Menu.Eliminazione:
                            Console.Clear();
                            Console.WriteLine("Inserisci i dati dello/degli da eliminare");
                            Console.Write("Nome: ");
                            tempFirstName = Console.ReadLine();
                            Console.Write("Cognome: ");
                            tempLastName = Console.ReadLine();
                            Console.Write("Eta': ");
                            tempAge = Console.ReadLine();

                            if (manager.Delete(tempFirstName, tempLastName, tempAge))
                                Console.WriteLine("Eliminazione completata con successo.");
                            else Console.WriteLine("Eliminazione fallita.");

                            break;
                        default:
                            Console.WriteLine("Errore");
                            break;
                    }
                } while (menuChoice.Key.ToString() != "F");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
