using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Project.DataModels
{
    internal class Enums
    {
        internal enum Menu
        {
            DatasImport = 'A',
            ShowEmployees = 'B',
            ShowActivities = 'C',
            DatasExportToJson = 'D',
            DatasImportFromJson = 'E',
            Statistics = 'F',
        }

        internal enum SearchMenu
        {
            SearchEmployee = 'A',
            GrpByCity = 'B',
            GrpByRoleOffice = 'C',
            GrpByNameActivity = 'D',
        }
    }
}
