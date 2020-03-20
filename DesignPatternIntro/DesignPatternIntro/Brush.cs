using System;

namespace DesignPatternIntro
{
    public class Brush :ITool
    {
        public void MouseUp()
        {
            Console.WriteLine("Brush mouse up");
        }

        public void MouseDown()
        {
            Console.WriteLine("Brush mouse down");
        }
    }
}