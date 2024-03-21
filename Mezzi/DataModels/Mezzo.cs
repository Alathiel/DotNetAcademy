using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezzi.DataModels
{
    public abstract class Mezzo
    {
        public abstract int PeopleCapacity { get; set; }
        public abstract bool Electric { get; set; }
        public abstract bool Engine { get; set; }
        public abstract Enum Type { get; set; }
        public abstract Enum Color { get; set; }
        public abstract bool License { get; set; }
    }

    public interface IBike
    {
        public void ShowInfos();
        
        
    }
}
