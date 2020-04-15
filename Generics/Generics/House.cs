using System;
using System.Collections.Generic;

namespace Generics
{
    public class House: IProperty<House>
    {
        public int GardenArea { get; set; }
        public int HouseArea { get; set; }
        
        public bool IsEqual(House property)
        {
            return (GardenArea == property.GardenArea) && (HouseArea == property.HouseArea);
        }
    }
}


// private List<T> _windows;
//
// private List<D> _doors;
//
// public House()
// {
// _windows = new List<T>(); //list of types of windows
// }
//
// public void Display()
// {
// foreach (var housePart in _windows)
// {
//     Console.WriteLine(housePart);
// }
// }