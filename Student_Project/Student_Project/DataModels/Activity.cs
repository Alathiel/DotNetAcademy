﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Project.DataModels
{
    internal class Activity
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int StudentId { get; set; }
    }
}
