namespace Algorithm
{
    public struct Measurement  // value type used to encapsulate small groups of related variables
    {
        public Measurement(int x, int y)   // constructor
        {
            X = x;
            Y = y;
        }

        public int X;  // a public field - would a public property be more appropriate 
        public int Y; 
    }
}
