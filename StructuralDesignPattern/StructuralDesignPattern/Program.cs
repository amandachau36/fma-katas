using System;

namespace StructuralDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // var group1 = new Group();
            // group1.Add(new Shape());
            // group1.Add(new Shape());
            //
            // var group2 = new Group();
            // group2.Add(new Shape());
            // group2.Add(new Shape());
            //
            // // we cannot group groups -> how we dealt with this ???....
            // var group3 = new Group();
            // group3.Add(group1); 
            // group3.Add(group2);
            //
            // group3.Render();
            
            var shape = new Shape();
            var redBorderShape = new RedBorderShapeDecorator(shape);
            //redBorderShape.Render();
            var boldRedBorderShape = new BoldBorderShapeDecorator(redBorderShape);
            
            boldRedBorderShape.Render();
            
        }
    }
}