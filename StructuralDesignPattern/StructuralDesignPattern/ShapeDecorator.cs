namespace StructuralDesignPattern
{
    public abstract class ShapeDecorator : IComponent
    {
        private readonly IComponent _component;

        protected ShapeDecorator(IComponent component)
        {
            _component = component;
        }
        public virtual void Render()
        {
            _component.Render();
        }
    }
}