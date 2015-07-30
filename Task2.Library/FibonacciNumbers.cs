using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Library
{
    public class FibonacciNumbers
    {
        public static IEnumerable<int> GetNubers(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("n");
            }
            int f0 = 0, f1 = 1, count = 0;
            while (count < n)
            {
                count++;
                int temp = f0 + f1;
                f0 = f1;
                f1 = temp;
                yield return f1;
            }
            yield break;
        }
    }
}
