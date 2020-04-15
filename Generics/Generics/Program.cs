using System;
using System.Collections.Generic;

namespace Generics
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
           var house1 = new House();
           house1.GardenArea = 1;
           house1.HouseArea = 100;
           
           var house2 = new House();
           house2.GardenArea = 1;
           house2.HouseArea = 99;

           Console.WriteLine(house1.IsEqual(house2));
           
        
           // Display.WriteToDisplay<int>("Hello", 1);

           // var display = new Display<int>();
           // display.WriteToDisplay("this is a ", 7);

           // var calc = new Calculator<int>();
           //
           // Console.WriteLine(calc.AreEqual(2, 2));
           //
           // var calc2 = new Calculator<bool>();
           //
           // calc2.AreEqual(true, false);

           //var calc = new Calculator<House>(); 
           //calc.Value = "hello";
           // calc.Value = new House();
           // Console.WriteLine(calc.Value);
           //var house = new House();
           //house.CalculatePrice("5");

           //var house = new House<SlidingWindow>();




           //var list = new List<int>();
           //list.Add("hello"); String not valid because list of Type int
           //Generics are good because it can handle multiple things
           //But it's strongly typed

        }
    }
}