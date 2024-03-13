using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Project.DataModels
{
    internal class Activity
    {
        internal DateOnly? Date { get; set; }
        internal string? Type { get; set; } 
        internal int? Hours { get; set; }
        internal string? WorkerId { get; set; }

    }
}
