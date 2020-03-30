using System.Collections.Generic;

namespace StructuralDesignPattern
{
    public class Group : IComponent // composite design pattern 
    {
        private readonly List<IComponent> _components = new List<IComponent>();

        public void Add(IComponent component)
        {
            _components.Add(component);
        }

        public void Render()
        {
            foreach (var component in _components)
            {
                component.Render();
            }
        }
    }
}


// Example 1: Dealing with hierarchical structure
// "We want to group shapes, and we want to group groups