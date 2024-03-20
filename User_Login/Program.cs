using System.Configuration;
using User_Login.BLogic.Menu;

internal class Program
{
    static void Main(string[] args)
    {
        string workingDirectory = Environment.CurrentDirectory;
        ConfigurationManager.AppSettings["ProjectPath"] = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        KeyValuePair<string, string> pw = EncryptionData.EncryptionData.SaltEncrypt("Claudio");
        Menu.ShowMainMenu();
    }
}
