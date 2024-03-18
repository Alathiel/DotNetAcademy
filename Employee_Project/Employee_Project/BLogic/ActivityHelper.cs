using Employee_Project.DataModels;
using System.Configuration;

namespace Employee_Project.BLogic
{
    internal class ActivityHelper
    {
        #region Public Methods
        internal List<Activity> ImportActivities(List<Employee> employees)
        {
            List<Activity> importedActivities = [];
            try
            {
                List<string> tempActivities = File.ReadAllLines(ConfigurationManager.AppSettings["ProjectPath"] + "" + ConfigurationManager.AppSettings["ActivitiesPath"]).ToList();//prendo il path dal app.config
                int counter = 0;
                tempActivities.ForEach(e =>
                {
                    string[] tempArray = e.Split(';');
                    Activity activity = new Activity();
                    DateOnly date;

                    activity = new Activity(
                        counter, 
                        DateOnly.TryParseExact(tempArray[0], "dd/mm/yyyy", out date) ? date : DateOnly.FromDateTime(DateTime.Now),
                        tempArray[1],
                        Convert.ToInt32(tempArray[2]), tempArray[3]);


                    if (employees.Count() > 0 && activity.isValid()) { 
                        Employee employee = employees.Find(e => e.Id == activity.WorkerId);
                        if(employee != null)
                        {
                            employee.Activities.Add(activity);
                        }
                    }
                    else
                    {
                        if (activity.errors.Count > 0) { 
                            Console.WriteLine("Oggetto non aggiunto per via dei seguenti errori: ");
                            activity.errors.ForEach(e =>
                            {
                                Console.WriteLine(e);
                            });
                        }
                        else
                            Console.WriteLine("Non sono presenti employees nella lista.");
                    }

                    importedActivities.Add(activity);
                    counter++;
                });

            }catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return importedActivities;
        }

        internal void ShowActivities(List<Activity> activities)
        {
            Console.WriteLine("Attivita' presenti nella lista");
            if (activities.Count() > 0)
            { 
                activities.ForEach(a =>
                    {
                        Console.WriteLine($"\n\nData: {a.Date}\nType: {a.Type}\nHours: {a.Hours}\nWorker Id: {a.WorkerId}");
                    }
                );
            }
            else
                Console.WriteLine("Non risultano attivita'.");
        }

        #endregion
    }
}
