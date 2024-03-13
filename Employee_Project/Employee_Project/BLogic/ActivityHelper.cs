﻿using Employee_Project.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                        activity.Id = counter;
                        activity.Date = DateOnly.ParseExact(tempArray[0], "dd/mm/yyyy");
                        activity.Type = tempArray[1];
                        activity.Hours = Convert.ToInt32(tempArray[2]);
                        activity.WorkerId = tempArray[3];

                        Employee employee = employees.Find(e => e.Id == activity.WorkerId);
                        if(employee != null)
                        {
                            employee.Activities.Add(activity);
                        }
                        importedActivities.Add(activity);
                        counter++;
                    }
                );
            }catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return importedActivities;
        }

        internal void ShowActivities(List<Activity> activities)
        {
            Console.WriteLine("Attivita' presenti nella lista");
            activities.ForEach(a =>
                {
                    Console.WriteLine($"\n\nData: {a.Date}\nType: {a.Type}\nHours: {a.Hours}\nWorker Id: {a.WorkerId}");
                }
            );
        }

        #endregion
    }
}
