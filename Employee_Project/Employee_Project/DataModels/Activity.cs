using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Employee_Project.DataModels
{
    public class Activity
    {
        [JsonInclude] //altrimenti non verra' aggiunto al json
        public int Id { get;}
        [JsonInclude]
        public DateOnly? Date { get; set; }
        [JsonInclude]
        public string? Type { get; set; }
        [JsonInclude]
        public int? Hours { get; set; }
        [JsonInclude]
        public string? WorkerId { get; set; }

        public List<ValidationResult> errors { get; set; } = [];

        [JsonConstructor]
        public Activity()
        {
            Id = 0;
            Date = new DateOnly();
            Type = string.Empty;
            Hours = 0;
            WorkerId = string.Empty;
        }
        
        public Activity(int Id, DateOnly Date, string Type, int Hours, string WorkerId)
        {
            this.Id = Id;
            this.Date = Date;
            this.Type = Type;
            this.Hours = Hours;
            this.WorkerId = WorkerId;
        }

        public bool isValid()
        {
            return Validator.TryValidateObject(this, new ValidationContext(this), errors, true);
        }

    }
}
