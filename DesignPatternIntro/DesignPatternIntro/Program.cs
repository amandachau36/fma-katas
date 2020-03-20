using System;

namespace DesignPatternIntro
{
    class Program
    {
        static void Main(string[] args)
        {
           var canva = new Canva();
           
           canva.SetCurrentTool(new Brush());
           
           canva.MouseDown();
           
           canva.MouseUp();     
           
           canva.SetCurrentTool(new Selection());
           
           canva.MouseDown();
           
           canva.MouseUp();
        }
    }
}


// 2.	Refactor Canvas clas
// -	Canvas can "SetCurrentTool" through the public method
// -	Canvas can excute "MouseDown", "MouseUp". These two methods need to have "DIFFERENT behavior" based on  what the currentTool is.
// Tool example: Brush, Selection…