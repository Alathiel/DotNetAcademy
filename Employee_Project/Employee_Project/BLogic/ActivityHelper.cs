using Employee_Project.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Employee_Project.BLogic
{
    internal class ActivityHelper
    {
        #region Public Methods
        internal List<Activity> ImportActivities(List<string> activities, List<Employee> employees)
        {
            List<Activity> importedActivities = [];
            try
            {
                int counter = 0;
                activities.ForEach(e =>
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
