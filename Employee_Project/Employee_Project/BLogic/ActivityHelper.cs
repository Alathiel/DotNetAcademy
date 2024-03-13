using Employee_Project.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Project.BLogic
{
    internal class ActivityHelper
    {
        internal void ImportActivities(List<string> activities, List<Employee> employees)
        {
            List<Activity> importedActivities = [];
            try
            { 
                activities.ForEach(e =>
                    {
                        string[] tempArray = e.Split(';');
                        Activity activity = new Activity();

                        activity.Date = DateOnly.ParseExact(tempArray[0], "dd/mm/yyyy");
                        activity.Title = tempArray[1];
                        activity.Idk = Convert.ToInt32(tempArray[2]);
                        activity.WorkerId = tempArray[3];

                        Employee employee = employees.Find(e => e.Id == activity.WorkerId);
                        if(employee != null)
                        {
                            employee.Activities.Add(activity);
                        }
                    }
                );
            }catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
