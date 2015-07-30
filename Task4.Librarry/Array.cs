using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Library
{
    public class Array
    {
        public static int BinarySearch<T>(T[] array, T value)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            int index = array.GetLowerBound(0);
            return BinarySearch<T>(array, index, array.Length, value, (IComparer<T>)null);
        }

        public static int BinarySearch<T>(T[] array, int index, int lenght, T value)
        {
            return BinarySearch<T>(array, index, lenght, value, (IComparer<T>)null);
        }

        public static int BinarySearch<T>(T[] array, T value, IComparer<T> comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            int index = array.GetLowerBound(0);
            return BinarySearch<T>(array, index, array.Length, value, comparer);
        }

        public static int BinarySearch<T>(T[] array, T value, Comparison<T> comprison)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            int index = array.GetLowerBound(0);
            return BinarySearch(array, index, array.Length, value, comprison);
        }

        public static int BinarySearch<T>(T[] array, int index, int lenght, T value, Comparison<T> comparison)
        {
            if (comparison == null)
            {
                throw new ArgumentNullException("comparison");
            }
            IComparer<T> comparer = Comparer<T>.Create(comparison);
            return BinarySearch(array, index, lenght, value, comparer);
        }

        public static int BinarySearch<T>(T[] array, int index, int lenght, T value, IComparer<T> comparer)
        {
            if(array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (index < 0 || lenght < 0)
            {
                throw new ArgumentOutOfRangeException(index < 0 ? "index" : "lenght");
            }
            if (array.Length - index < lenght)
            {
                throw new ArgumentOutOfRangeException("lenght");
            }

            try
            {
                if (comparer == null)
                {
                    comparer = Comparer<T>.Default;
                }
                return BinarySearchHelper(array, index, lenght, value, comparer);
            }
            catch (Exception)
            {
               throw new InvalidOperationException("IComparer failed"); 
            }
        }

        private static int BinarySearchHelper<T>(T[] array, int index, int lenght, T value, IComparer<T> comparer)
        {
            int low = index;
            int high = array.Length - 1;

            while (low <= high)
            {
                int average = low + ((high - low) >> 1);
                int order = comparer.Compare(array[average], value);
                if (order == 0)
                {
                    return average;
                }
                if (order < 0)
                {
                    low = average + 1;
                }
                else
                {
                    high = average - 1;
                }
            }

            return -1;
        }
    }
}
