using System;

namespace StackOverflowPost
{
    class Program
    {
        static void Main(string[] args)
        {
            var post = new Post( "C# question", "Blah blah blah" );
            
            //post.CurrentVotes = 5;  is not accessible. This creates safety
            
            
            post.UpVote();
            post.UpVote();
            post.UpVote();
            post.UpVote();
            
            post.DownVote();
            post.DownVote();

            Console.WriteLine(post.CurrentVotes);
          
            
        }
    }
}