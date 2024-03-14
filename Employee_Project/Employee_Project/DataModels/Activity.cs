using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Employee_Project.DataModels
{
    internal class Activity
    {
        [JsonInclude] //altrimenti non verra' aggiunto al json
        internal int Id { get;}
        [JsonInclude]
        internal DateOnly? Date { get; set; }
        [JsonInclude]
        internal string? Type { get; set; }
        [JsonInclude]
        internal int? Hours { get; set; }
        [JsonInclude]
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
