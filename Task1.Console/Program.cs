using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Library;
using Task3.Library;

namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string str;
            int count;
            TimerManager manager = new TimerManager();
            Person p = new Person("Jon", manager);
            Person a = new Person("Joe", manager);
            Person b = new Person("Jeffrey", manager);

            System.Console.WriteLine("Enter the count of seconds:");
            do
            {
                str = System.Console.ReadLine();

            } while (!Int32.TryParse(str,out count));

            manager.SimulateTimer(count*1000);
             */
            CustomQueue<int> queue = new CustomQueue<int>();
            queue.EnQueue(1);
            queue.EnQueue(5);
            queue.EnQueue(10);
            WriteQueue(queue);
            queue.DeQueue();
            WriteQueue(queue);
            
            System.Console.ReadKey();

        }

        private static void WriteQueue<T>(CustomQueue<T> queue)
        {
            foreach (var q in queue)
            {
                System.Console.WriteLine(q.ToString());
            }
        }
    }
}
