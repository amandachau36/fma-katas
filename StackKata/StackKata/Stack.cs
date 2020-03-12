using System;
using System.Collections;
using System.Collections.Generic;

namespace StackKata
{
    public class MyStack
    {
        public List<object> Stack { get; } = new List<object>();
        
        //private readonly List<object> _stack = new List<object>();  // private field makes sense but more difficult to test

        public void Push(object obj)
        {
            if (obj == null) throw new InvalidOperationException("Cannot pass in null object");
            
            Stack.Add(obj);
        }

        public object Pop()
        {
            if (Stack.Count <= 0) throw new InvalidOperationException("Cannot remove item from an empty stack");

            var lastIndex = Stack.Count - 1; 
            
            var lastItem = Stack[lastIndex]; 
            
            Stack.RemoveAt(lastIndex);

            return lastItem;
        }

        public void Clear()
        {
            Stack.Clear();
        }
        
   
    }
}