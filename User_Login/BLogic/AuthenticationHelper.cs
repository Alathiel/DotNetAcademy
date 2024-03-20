using FileUtility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using User_Login.DataModels;
using User_Login.DataModels.User;

namespace User_Login.BLogic
{
    internal class AuthenticationHelper
    {

        internal bool Login()
        {
            try { 
                Console.Clear();
                Console.Write("Inserisci il tuo nickname: ");
                string tempUsername = Console.ReadLine();
                Console.Write("Inserisci la tua password: ");
                string tempPw = Console.ReadLine();

                User tempUser = ImportXMLFile(ConfigurationManager.AppSettings["ProjectPath"], ConfigurationManager.AppSettings["Credentials"]);
                if (tempUser.Username.Equals(tempUsername))
                {
                    if (EncryptionData.EncryptionData.SaltDecrypt(tempPw, tempUser.Salt, tempUser.Password)) 
                        return true;
                }
            }
            catch (Exception e) { Console.WriteLine(e); }

            return false;
        }

        internal bool SignUp()
        {
            Console.Clear();
            Console.Write("Inserisci il tuo nome completo: ");
            string tempFullName = Console.ReadLine();
            Console.Write("Inserisci il tuo nickname: ");
            string tempUsername = Console.ReadLine();
            Console.Write("Inserisci la tua password: ");
            string tempPw = Console.ReadLine();
            KeyValuePair<string, string> temp = EncryptionData.EncryptionData.SaltEncrypt(tempPw);
            if (ExportXMLFile(ConfigurationManager.AppSettings["ProjectPath"], new User(tempFullName, tempUsername, temp.Key, temp.Value), ConfigurationManager.AppSettings["Credentials"]))
                return true;

            return false;
        }

        private static User ImportXMLFile(string path, string fileName = "emptyname.xml")
        {
            try
            {
                if (File.Exists(path + @"\" + fileName))
                {
                    StreamReader reader = new StreamReader(path + @"\" + fileName);
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
                    User u = (User)xmlSerializer.Deserialize(reader);
                    reader.Close();
                    return u;
                }
                else
                    Console.WriteLine($"File non esistente nel seguente percorso {path + @"\" + fileName}");

            }catch(Exception ex) { Console.WriteLine(ex); }
            return new User();
        }

        private static bool ExportXMLFile(string path, User obj, string fileName = "emptyname.xml")
        {
            try {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
                if (File.Exists(path + @"\" + fileName))
                {
                    StreamWriter writer = new StreamWriter(path + @"\" + fileName);
                    xmlSerializer.Serialize(writer, obj);
                    writer.Close();
                    return true;
                }
                else
                    Console.WriteLine($"File non esistente nel seguente percorso {path + @"\" + fileName}");
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            return false;
        }

    }
}
