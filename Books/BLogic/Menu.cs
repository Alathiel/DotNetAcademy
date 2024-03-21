using Books.DataModels;
using FileUtility;
using System.Configuration;
namespace Books.BLogic
{
    internal class Menu
    {

        static BookHelper bookHelper = new BookHelper();

        static List<Author> authors = [];
        internal static void ShowMainMenu()
        {
            ConsoleKeyInfo menuChoice;
            do
            {
                Console.Clear();
                Console.WriteLine("MENU LIBRI\n\n");
                Console.WriteLine("A) Import datas");
                Console.WriteLine("B) Export to XML");
                Console.WriteLine("C) Statistiche");
                Console.WriteLine("F) Esci\n\n");

                menuChoice = Console.ReadKey();
                switch ((Enums.Menu)menuChoice.Key)
                {
                    case Enums.Menu.DatasImport:
                        authors = bookHelper.BookImport(Utility.ImportTXTFile(ConfigurationManager.AppSettings["Directory"], ConfigurationManager.AppSettings["BooksFile"]));
                        bookHelper.ShowAuthors(authors);
                        Console.Clear();
                        if (authors.Count > 0)
                            Console.WriteLine("Books import successful.");
                        else
                            Console.WriteLine("Unexpected error.");
                        Console.ReadLine();
                        break;

                    /*case Enums.Menu.ExportToXML:
                        Console.Clear();
                        //if(bookHelper.ExportXML(ConfigurationManager.AppSettings["Directory"], authors, ConfigurationManager.AppSettings["XMLBooksFile"]))
                            //Console.WriteLine("Books export successful.");
                        //else
                            Console.WriteLine("Unexpected error.");
                        Console.ReadLine();
                        break;
                    case Enums.Menu.Statistics:
                        Console.Clear();
                        Console.Write("Inserisci la password per accedere alle statistiche: ");
                        string tempPw = Console.ReadLine();
                        if (ConfigurationManager.AppSettings["StatisticsPwe"].Equals(EncryptionData.EncryptionData.SaltDecrypt(tempPw, ConfigurationManager.AppSettings["PweSalt"])))
                            //ShowStatisticsMenu();
                        else 
                        { 
                            Console.WriteLine("Password inserita errata.");
                            Console.ReadLine();
                        }
                        break;*/
                }

            } while (menuChoice.Key.ToString() != "F");
        }

        /*private static void ShowStatisticsMenu()
        {
            ConsoleKeyInfo menuChoice;
            do 
            {

                Console.Clear();
                Console.WriteLine("STATISTICHE\n\n");
                Console.WriteLine("A) Check ISBN doppi");
                Console.WriteLine("B) Raggruppamento per genere");
                Console.WriteLine("C) Autore, Libro e costo piu' alto");
                Console.WriteLine("D) Estrarre la media costo per genere");
                Console.WriteLine("E) Autori che hanno pubblicato qualcosa in un certo anno, o prima o dopo");
                Console.WriteLine("F) Esci\n\n");

                menuChoice = Console.ReadKey();

                switch ((Enums.Statistics)menuChoice.Key) 
                {
                    case Enums.Statistics.CheckISBN:
                        Console.Clear();
                        if (bookHelper.CheckISBN(books))
                            Console.WriteLine("Esistono due libri differenti con lo stesso ISBN.");
                        else
                            Console.WriteLine("Non esistono due libri differenti con lo stesso ISBN.");
                        Console.ReadLine();
                        break;
                    case Enums.Statistics.GrpByGenre:
                        bookHelper.GrpByGenre(books);
                        break;
                    case Enums.Statistics.WorstPrice:
                        bookHelper.WorstPrice(books);
                        break;
                    case Enums.Statistics.AvgCostGenre:
                        bookHelper.AvgCostGenre(books);
                        break;
                    case Enums.Statistics.SearchYear:
                        bookHelper.SearchYear(books);
                        break;
                }

            } while (menuChoice.Key.ToString() != "F");
        }*/
    }
}
