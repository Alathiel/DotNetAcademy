using System.Configuration;
using System.IO.Enumeration;
using System.Text.Json;
using System.Xml.Serialization;
namespace FileUtility
{
    public class Utility
    {
        static Utility u = new Utility();
        public static string[] ImportTXTFile(string path, string fileName = "")
        {
            Console.Clear();
            try
            {
                if(fileName.Length == 0 ) { 
                    Console.Write("Inserisci il nome del file da importare: ");
                    fileName = Console.ReadLine();
                }
                else { 
                    if (File.Exists(path + @"\" + fileName))
                    return File.ReadAllLines(path + @"\" + fileName);

                    else 
                    {
                        Console.WriteLine($"Errore, file specificato non esiste al path {path + @"\" + fileName}");
                    }
                }
            }
            catch (Exception ex) {
                
                Console.WriteLine(ex);
            }
            Console.ReadLine();
            return [];
        }

        public static List<string> ImportXMLFile(string path, string fileName = "")
        {
            
            return [];
        }

        public static bool ExportXMLFile(string path, List<string> list, string fileName = "basename.xml")
        {
            try { 

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
                StreamWriter writer = new StreamWriter(path + @"\" + fileName);
                xmlSerializer.Serialize(writer, list);
                writer.Close();
                return true;

            }catch (Exception ex) { Console.WriteLine(ex); }

            return false;
        }


        public static void ImportJSONFile()
        { 
        }

        /// <summary>
        /// Create a Json file from a list, remember the data annotation [JSONInclude]
        /// </summary>
        /// <param name="list"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        internal static bool ExportJSONFile(List<string> list, string path, string fileName = "basename.json")
        {
            try
            {
                Console.Clear();
                if(fileName.Equals("basename.json") || fileName==string.Empty)
                {
                    Console.Write("Inserisci il nome che dovra' avere il file esportato: ");
                    fileName = Console.ReadLine();
                }
                string tempEmployees = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true }); //tutti gli attributi degli oggetti che verranno stampati devono essere public altrimenti usare [JsonInclude]
                File.WriteAllText(path + @"\" + fileName, tempEmployees);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }

        internal string getClassName()
        {
            return this.GetType().Name;
        }
    }
}
