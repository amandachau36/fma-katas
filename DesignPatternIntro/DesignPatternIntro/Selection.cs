using System;

namespace DesignPatternIntro
{
    public class Selection : ITool
    {
        public void MouseUp()
        {
            Console.WriteLine("Selection mouse up");
        }

        public void MouseDown()
        {
            Console.WriteLine("Selection mouse down");
        }
    }
}