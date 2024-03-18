using Employee_Project.BLogic;
using System.Configuration;

internal class Program{
    static void Main(string[] args)
    {
        string workingDirectory = Environment.CurrentDirectory;
        ConfigurationManager.AppSettings["ProjectPath"] = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        Menu.ShowMainMenu();
    }
}