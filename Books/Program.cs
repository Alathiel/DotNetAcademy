using Books.BLogic;
using System.Configuration;


internal class Program
{
    static void Main(string[] args)
    {
        KeyValuePair<string, string> temp = EncryptionData.EncryptionData.SaltEncrypt("admin");
        ConfigurationManager.AppSettings["StatisticsPwe"] = temp.Key;
        ConfigurationManager.AppSettings["PweSalt"] = temp.Value;
        string workingDirectory = Environment.CurrentDirectory;
        ConfigurationManager.AppSettings["Directory"] = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        Menu.ShowMainMenu();
    }
}