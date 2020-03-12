using System;
using System.Collections.Generic;

namespace StackKata
{
    public class MyStack
    {
        public List<object> Stack { get; private set; } = new List<object>();

        public void Push(object obj)
        {
            if (obj == null) throw new InvalidOperationException("Cannot pass in null object");
            
            Stack.Add(obj);
        }

        public object Pop()
        {
            if (Stack.Count <= 0) throw new InvalidOperationException("Cannot remove item from an empty stack");
            
            var lastItem = Stack[^1]; 
            
            Stack.Remove(lastItem);

            return lastItem;
        }

        public void Clear()
        {
            Stack.Clear();
        }
        
   
    }
}