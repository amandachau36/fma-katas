using System;

namespace StructuralDesignPattern
{
    public class RedBorderShapeDecorator : ShapeDecorator
    {
        public RedBorderShapeDecorator(IComponent component) : base(component)
        {
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine("Apply red border");
        }
    }
}