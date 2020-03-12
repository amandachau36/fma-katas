using System;
using StackKata;
using Xunit;

namespace StackTests
{
    public class Stacktests
    {
        [Fact]
        public void It_Should_Not_BeAnEmptyOrNullStack_When_AnObjectIsPushed()
        {
            //arrange
            var stack = new MyStack();   
            
            //act
            stack.Push(1);
            
            //assert
            Assert.NotEmpty(stack.Stack);
            Assert.NotNull(stack.Stack);
        }
        
        [Fact] //TODO: is this correct for comparing objects
        public void It_Should_AddAnObjectToStackList_When_AnObjectIsPushed()
        {
            //arrange
            var stack = new MyStack();   
            
            //act
            stack.Push(1);
            
            //assert
            Assert.Equal(1, stack.Stack[0]);
        }

        [Fact]
        public void It_Should_Throw_InvalidOperationException_When_NullIsPassedIn()
        {
            //arrange
            var stack = new MyStack();   
            
            //act
            Action actual = () =>  stack.Push(null);
            
            //assert 
            var exception = Assert.Throws<InvalidOperationException>(actual);
            Assert.Equal("Cannot pass in null object", exception.Message);
        }
        
        [Fact] 
        public void It_Should_RemoveAnObject_WhenPopped()
        {
            //arrange
            var stack = new MyStack();
            stack.Push(1);
            stack.Push(2);
            
            //act
            stack.Pop();
            
            //assert
            Assert.Single(stack.Stack);
        }

        [Fact]
        public void It_Should_ReturnLastObject_WhenPopped()
        {
            //arrange
            var stack = new MyStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            //act
            var poppedItem = stack.Pop();
            
            //assert
            Assert.StrictEqual(3, poppedItem);
        }
        
        [Fact]
        public void It_Should_Throw_InvalidOperationException_When_PoppingAnEmptyStack()
        {
            //arrange
            var stack = new MyStack();   
            
            //act
            Action actual = () =>  stack.Pop();
            
            //assert 
            var exception = Assert.Throws<InvalidOperationException>(actual);
            Assert.Equal("Cannot remove item from an empty stack", exception.Message);
        }

        [Fact]
        public void It_Should_RemoveAllItemsFromTheStack_When_Cleared()
        {
            //arrange 
            var stack = new MyStack();
            
            //act
            stack.Clear();
            
            //assert
            Assert.Empty(stack.Stack);
        }
        
        [Fact]
        public void Test_Equal_StrictlyEqual()
        {
            decimal oneD = 1;
            int oneI = 1;
            //assert
            Assert.Equal(oneD, oneI);
            Assert.StrictEqual(oneD, oneI);    
        }
        
    }
}



//
// A Stack is a data structure for storing a list of elements in a LIFO (last in, first out) fashion. 
// Design a class called Stack with three methods. 
// void Push(object obj)
// object Pop()
// void Clear()
// The Push() method stores the given object on top of the stack. We use the “object” type here so we can store any objects
// inside the stack. Remember the “object” class is the base of all classes in the .NET Framework. So any types can be 
// automatically upcast to the object. Make sure to take into account the scenario that null is passed to this object. 
// We should not store null references in the stack. So if null is passed to this method, you should throw an 
// InvalidOperationException. Remember, when coding every method, you should think of all possibilities and make sure the
// method behaves properly in all these edge cases. That’s what distinguishes you from an “average” programmer. 
// The Pop() method removes the object on top of the stack and returns it. Make sure to take into account the scenario that
// we call the Pop() method on an empty stack. In this case, this method should throw an InvalidOperationException. 
// Remember, your classes should always be in a valid state and used properly. When they are misused, they should throw 
// exceptions. Again, thinking of all these edge cases, separates you from an average programmer. 
// The code written this way will be more robust and with less bugs. The Clear() method removes all objects from the stack.
// We should be able to use this stack class as follows:
// var stack = new Stack();
// stack.Push(1);
// stack.Push(2);
// stack.Push(3);
// Console.WriteLine(stack.Pop());
// Console.WriteLine(stack.Pop());
// Console.WriteLine(stack.Pop());
// The output of this program will be 
// 3
// 2
// 1
// Note: The downside of using the object class here is that if we store value types (eg int, char, bool, DateTime) in our 
// Stack, boxing and unboxing occurs, which comes with a small performance penalty. In my C# Advanced course, 
// I’ll teach you how to resolve this by using generics, but for now don’t worry about it. 
