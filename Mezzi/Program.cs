using Mezzi.DataModels;

public class Program
{
    static void Main(string[] args)
    {
        Bike MountainBike = new Bike();
    

    }
}

public class Bike : Mezzo, IBike
{
    public override int PeopleCapacity { get  ; set  ; }
    public override bool Electric { get  ; set  ; }
    public override bool Engine { get; set  ; }
    public override Enum Type { get  ; set  ; }
    public override Enum Color { get  ; set  ; }
    public override bool License { get  ; set  ; }

    Bike()
    {
        PeopleCapacity = 1;
        Electric = false;
        Engine = false;
        Type = Enums.Type.Bicicletta;
        Color = Enums.Color.Red;
        License = false;
    }

    public void ShowInfos()
    {
        Console.WriteLine($"People Capacity: {this.PeopleCapacity} - Electric: {this.Electric}");
        Console.WriteLine($"Engine: {this.Engine} - Type: {this.Type}");
        Console.WriteLine($"Color: {this.Color} - License: {this.License}");
    }
}