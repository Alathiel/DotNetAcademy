using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Project.DataModels
{
    internal class Activity
    {
        internal int Id { get; set; }
        internal DateOnly? Date { get; set; }
        internal string? Type { get; set; } 
        internal int? Hours { get; set; }
        internal string? WorkerId { get; set; }
        
        internal Activity()
        {
            Id = 0;
            Date = new DateOnly();
            Type = string.Empty;
            Hours = 0;
            WorkerId = string.Empty;
        }

        internal Activity(int Id, DateOnly Date, string Type, int Hours, string WorkerId)
        {
            this.Id = Id;
            this.Date = Date;
            this.Type = Type;
            this.Hours = Hours;
            this.WorkerId = WorkerId;
        }

    }
}
