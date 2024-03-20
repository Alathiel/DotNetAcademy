using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.DataModels
{
    internal class Enums
    {
        internal enum Menu
        {
            DatasImport = 'A',
            ExportToXML = 'B',
            Statistics = 'C',
        }
        internal enum Statistics
        {
            CheckISBN = 'A',
            GrpByGenre = 'B',
            WorstPrice = 'C',
            AvgCostGenre = 'D',
            SearchYear = 'E',
        }
    }
}
