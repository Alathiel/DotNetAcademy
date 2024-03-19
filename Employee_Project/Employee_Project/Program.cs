using Employee_Project.BLogic;
using System.Configuration;
using EncryptionData;

internal class Program{
    static void Main(string[] args)
    {
        string workingDirectory = Environment.CurrentDirectory;
        ConfigurationManager.AppSettings["ProjectPath"] = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        KeyValuePair<string, string> pw = EncryptionData.EncryptionData.SaltEncrypt("Claudio");
        Console.WriteLine($"PasswordHash: {pw.Key} - Salt: {pw.Value}");
        Console.ReadLine();
        Menu.ShowMainMenu();
    }
}