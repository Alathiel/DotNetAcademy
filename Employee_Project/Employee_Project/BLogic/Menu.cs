using Employee_Project.DataModels;

namespace Employee_Project.BLogic
{
    internal class Menu
    {
        static EmployeeHelper employeeHelper = new EmployeeHelper();
        static ActivityHelper activityHelper = new ActivityHelper();
        static List<Employee> employees = [];
        static List<Activity> activityList = [];
        static ConsoleKeyInfo menuChoice;

        #region Public methods
        internal static void ShowMainMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("GESTIONE EMPLOYEES\n\n");
                Console.WriteLine("A) Import da file txt degli employees e delle activities");
                Console.WriteLine("B) Mostra gli employees con activities eseguite");
                Console.WriteLine("C) Mostra le activities");
                Console.WriteLine("D) Export su file json degli employees e delle activities");
                Console.WriteLine("E) Import da file json degli employees e delle activities");
                Console.WriteLine("F) Statistics");
                Console.WriteLine("Z) Esci\n\n");

                menuChoice = Console.ReadKey();

                switch ((Enums.Menu)menuChoice.Key)
                {
                    case Enums.Menu.DatasImport:

                        employees = employeeHelper.ImportEmployees();
                        activityList = activityHelper.ImportActivities(employees);
                        if (employees.Count > 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Import avvenuto con successo.");
                            Console.ReadLine();
                        }

                        break;

                    case Enums.Menu.ShowEmployees:

                        Console.Clear();
                        employeeHelper.ShowEmployeeList(employees);
                        Console.ReadLine();
                        break;

                    case Enums.Menu.ShowActivities:

                        Console.Clear();
                        activityHelper.ShowActivities(activityList);
                        Console.ReadLine();
                        break;

                    case Enums.Menu.DatasExportToJson:
                        Console.Clear();
                        if (Utility.ExportListToJSON(employees))
                            Console.WriteLine("Dati esportati con successo.");
                        else
                            Console.WriteLine("Dati non esportati per via di un errore.");
                        Console.ReadLine();
                        break;

                    case Enums.Menu.DatasImportFromJson:
                        Console.Clear();
                        employees = Utility.ImportEmployeesList();
                        employeeHelper.ShowEmployeeList(employees);
                        Console.ReadLine();
                        break;

                    case Enums.Menu.Statistics:
                        SearchMenu();
                        break;
                }

            } while (menuChoice.Key.ToString() != "Z");
        }

        #endregion

        #region Private methods
        private static void SearchMenu()
        {
            try
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("MENU STATISTICHE\n\n");
                    Console.WriteLine("A) Ricerca impiegato per ruolo e citta'");
                    Console.WriteLine("B) Raggruppamento per citta',  con i dati nome, ruolo, eta', in ordine di nome");
                    Console.WriteLine("C) Raggruppamento per ruolo, ufficio, degli impiegati che hanno eta' maggiore di 45 anni");
                    Console.WriteLine("D) Raggruppamento per nome, attivita', in modo da sapere che attivita' sono state svolte");
                    Console.WriteLine("E) Ritorna al menu principale\n");

                    menuChoice = Console.ReadKey();

                    switch ((Enums.SearchMenu)menuChoice.Key)
                    {
                        case Enums.SearchMenu.SearchEmployee:
                            Utility.SearchEmployee(employees);
                            Console.ReadLine();
                            break;
                        case Enums.SearchMenu.GrpByCity:
                            Utility.GrpByCity(employees);
                            Console.ReadLine();
                            break;
                        case Enums.SearchMenu.GrpByRoleOffice:
                            Utility.GrpByRoleOffice(employees);
                            Console.ReadLine();
                            break;
                        case Enums.SearchMenu.GrpByNameActivity:
                            Utility.GrpByNameActivity(employees, activityList);
                            Console.ReadLine();
                            break;
                    }

                } while (menuChoice.Key.ToString() != "E");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        #endregion
    }
}
