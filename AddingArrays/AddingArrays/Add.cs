namespace AddingArrays
{
    public class Add
    {
        public static int[] Arr (int[] array1, int[] array2)  // copy
        {
            var newArray = new int[array1.Length + array2.Length];

            var i = 0;

            while (i < newArray.Length)
            {
                foreach (var num in array1)
                {
                    newArray[i] = num;
                    i++; 
                }

                foreach (var num in array2)
                {
                    newArray[i] = num;
                    i++; 
                }
                
            }

            return newArray;
        }
        
    }
}