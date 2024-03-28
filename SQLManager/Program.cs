using SQLManager.BLogic;
using SQLManager.DataModels;
using System.Configuration;

public class Program
{
    static void Main(string[] args)
    {
        List<Customer> customers = [];
        Console.WriteLine(new string('*', 100));
        Console.WriteLine("Progetto integrazione Libreria Microsoft SQL");
        Console.WriteLine(new string('*',100));

        //Istanziazione classe
        DBUtility dbUtility = new(ConfigurationManager.AppSettings["SqlServer"]);
        if (dbUtility.IsDbStatusValid) 
        {
            Console.WriteLine("Connesso con successo");
            //Console.WriteLine("Totale Customers: " + dbUtility.GetTotalCustomers());
           // customers = dbUtility.getCustomers();
            //customers.ForEach(c => { Console.WriteLine($"CustomerID: {c.CustomerId} - FirstName: {c.FirstName} - LastName: {c.LastName}"); });
            //Console.WriteLine("\nSearch customer based on first name and last name: ");
           // dbUtility.getCustomerByCompleteName("Dylan","Miller");
            Console.WriteLine("\nRighe aggiornate: "+dbUtility.UpdateCustomersByID(1, "Valerio"));
            Console.WriteLine("\nRighe aggiornate: " + dbUtility.UpdateCustomersByID(1, "Valerio"));
            Console.WriteLine("\nRighe aggiornate: " + dbUtility.UpdateCustomersByID(1, "Valerio"));
            Console.WriteLine("\nRighe aggiornate: " + dbUtility.UpdateCustomersByID(1, "Valerio"));
            Console.WriteLine("\nRighe aggiornate: " + dbUtility.UpdateCustomersByID(1, "Valerio"));
            //Console.WriteLine("\nRighe eliminate: " + dbUtility.DeleteCustomerById(1));
            Console.WriteLine("\nRighe inserite: " + dbUtility.InsertCustomer());

        }
        else
            Console.WriteLine("Errore nella connessione");
    }
}