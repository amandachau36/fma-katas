using System;

namespace RecreatingQueue
{
    public class QueueList
    {
        private QueueItem _head; // field, property not required because we don't want the QueueItems to be publicly accessible 
        private QueueItem _tail;

        public QueueList()
        {
            _head = null;
            _tail = null;
        }

        public void Enqueue(string itemName)
        {
           var newItem =  new QueueItem(itemName);
           if (_head == null)
           {
               _head = newItem;
               _tail = newItem;
               return;
           }

           var current = _tail;
           current.NextItem = newItem;
           _tail = newItem;
        }
        
        
        //peek 
        public string Peek()
        {
            return _head.ItemName;
        }
        
        //dequeue 

        public string Dequeue()
        {
            if (_head == null)
            {
             
                throw new Exception("This queue is empty");  // no need to return
             
            }
            
            var current = _head;
            _head = current.NextItem;

            return current.ItemName;

        }
        
        
        
        //count
        public int Count()
        {
       
            var current = _head;
            if (_head == null)
                return 0;
            
            var count = 0;
            while (current.NextItem != null)
            {
                count++; 
                current = current.NextItem;
            }
          
            // need to add lastItem which has NextItem == null
            return count+1;
        }
        
        
        

        public void PrintQueue()
        {
            var current = _head;
            while (current.NextItem != null)
            {
                Console.WriteLine(current.ItemName);
                current = current.NextItem;
            }
            Console.WriteLine(current.ItemName);
         
        }
        
        // nested class are always private
        private class QueueItem // doesn't need to be public // so  we could make this in internal ( accessible within assembly) or make it even less accessible as private  
        { 
            public string ItemName { get; } // but also do int - generics
            public QueueItem NextItem { get; set; }

            public QueueItem(string itemName)
            {
                ItemName = itemName;
                NextItem = null;
            }
            
        } 
        
    }
    
}