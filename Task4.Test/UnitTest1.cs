using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task4.Library;
namespace Task4.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BinarySearchTest_ArraySearchValue_RetunedTwo()
        {
            int[] array = new int[] { 5, -8, 9, 10, 2 };
            System.Array.Sort(array);
            int result = Library.Array.BinarySearch(array, 5);
            Assert.AreEqual(result, 2);
        }
        [TestMethod]
        public void BinarySearchTest_ArraySearchValue_RetunedFour()
        {
            int[] array = new int[] { 5, -8, 9, 10, 2 };
            System.Array.Sort(array);
            int result = Library.Array.BinarySearch(array, 10);
            Assert.AreEqual(result, 4);
        }
    }
}