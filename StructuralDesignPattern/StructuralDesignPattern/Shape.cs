using System;

namespace StructuralDesignPattern
{
    public class Shape : IComponent
    {
        public void Render()
        {
            Console.WriteLine("render shape");
        }
    }
}