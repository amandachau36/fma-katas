using System.Collections.Generic;
using AddingArrays;
using NUnit.Framework;

namespace AddArrays.UnitTests
{
    public class AddTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add_TwoArraysWithLength10_ReturnsAnArrayWithLength20()
        {

            var array1 = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            var newArray = Add.Arr(array1, array1);
            
            
            Assert.AreEqual(20, newArray.Length);

        }
        
        [Test]
        public void Add_TwoIdenticalUniqueArrays_ReturnsAnArrayWithDuplicates()
        {

            // var array1 = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            //
            // var newArray = Add.Arr(array1, array1);


            var newArray = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};


            var result = new HashSet<int>(newArray).Count;
            
            
            Assert.AreEqual(10, result);

        }
        
    }
}