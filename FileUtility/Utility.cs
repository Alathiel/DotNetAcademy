namespace FileUtility
{
    public class Utility
    {
        public static List<string> ImportTXTFile(string path)
        {
            string fileName;
            Console.Clear();
            try
            {
                Console.Write("Inserisci il nome del file da importare: ");
                fileName = Console.ReadLine();
                if (File.Exists(path + @"\" + fileName))
                    return File.ReadAllLines(path + @"\" + fileName).ToList();

                else 
                {
                    Console.WriteLine($"Errore, file specificato non esiste al path {path + @"\" + fileName}");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            Console.ReadLine();
            return [];
        }
    }
}
