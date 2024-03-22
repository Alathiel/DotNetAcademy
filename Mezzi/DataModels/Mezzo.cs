using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mezzi.DataModels
{
    #region Abstract things
    public abstract class Mezzo
    {
        public abstract int PeopleCapacity { get; set; }
        public abstract bool Electric { get; set; }
        public abstract bool Engine { get; set; }
        public abstract Enum Type { get; set; }
        public abstract Enum Color { get; set; }
        public abstract bool License { get; set; }
        public abstract decimal Weight { get; set; }
    }

    #endregion

    #region Def Mezzi

    public class Bicycle : Mezzo, IBicycle
    {
        public override int PeopleCapacity { get; set; }
        public override bool Electric { get; set; }
        public override bool Engine { get; set; }
        public override Enum Type { get; set; }
        public override Enum Color { get; set; }
        public override bool License { get; set; }
        public override decimal Weight { get; set; }
        public Bicycle()
        {
            PeopleCapacity = 1;
            Electric = false;
            Engine = false;
            Type = Enums.Type.Bicycle;
            Color = Enums.Color.Red;
            License = false;
            Weight = 15;
        }

        public void ShowInfos()
        {
            Console.WriteLine($"People Capacity: {this.PeopleCapacity} - Electric: {this.Electric}");
            Console.WriteLine($"Engine: {this.Engine} - Type: {this.Type}");
            Console.WriteLine($"Color: {this.Color} - License: {this.License}");
        }
        public void ChangePeopleCapacity(int a)
        {
            PeopleCapacity = a;
        }
    }

    public class Car : Mezzo
    {
        public override int PeopleCapacity { get; set; }
        public override bool Electric { get; set; }
        public override bool Engine { get; set; }
        public override Enum Type { get; set; }
        public override Enum Color { get; set; }
        public override bool License { get; set; }
        public override decimal Weight { get; set; }
        public Car()
        {
            PeopleCapacity = 4;
            Electric = false;
            Engine = true;
            Type = Enums.Type.Car;
            Color = Enums.Color.Blue;
            License = false;
            Weight = 100;
        }
    }

    #endregion

    #region Interfaces 

    public interface IBicycle
    {
        public void ShowInfos();
        public void ChangePeopleCapacity(int a);
    }

    #endregion
}
