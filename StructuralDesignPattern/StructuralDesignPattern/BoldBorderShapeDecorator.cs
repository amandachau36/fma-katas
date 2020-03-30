using System;

namespace StructuralDesignPattern
{
    public class BoldBorderShapeDecorator : ShapeDecorator
    {
        public BoldBorderShapeDecorator(IComponent component) : base(component)
        {
        }

        public override void Render()
        {
            base.Render();
            Console.WriteLine("Apply bold border");
        }
    }
}