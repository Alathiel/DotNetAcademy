using LogHandler;
using System.Reflection;
namespace FileUtility
{
    public class Utility
    {
        static Utility u = new Utility();
        public static List<string> ImportTXTFile(string path)
        {
            string fileName;
            Console.Clear();
            try
            {

                Console.Write("Inserisci il nome del file da importare: ");
                fileName = Console.ReadLine();
                Console.WriteLine(path);
                //if (File.Exists(path + @"\" + fileName))
                    return File.ReadAllLines(path + @"\" + fileName).ToList();

                //else 
                {
                    Console.WriteLine($"Errore, file specificato non esiste al path {path + @"\" + fileName}");
                }
            }
            catch (Exception ex) {
                LogsHandler.ErrorLog(ex.Message, ex.GetType().Name, u.getClassName() , MethodBase.GetCurrentMethod().Name);
                //Console.WriteLine(ex);
            }
            Console.ReadLine();
            return [];
        }

        internal string getClassName()
        {
            return this.GetType().Name;
        }
    }
}
