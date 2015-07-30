using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public class Person
    {
        string Name { get; set; }

        public Person(string name, TimerManager timer)
        {
            Name = name;
            timer.Timer += TimerMsg;
        }

        public void TimerMsg(Object sender, TimerEventArgs eventArgs)
        {
            Console.WriteLine("Person {0} received a message!", Name);
        }

        public void UnRegister(TimerManager timer)
        {
            timer.Timer -= TimerMsg;
        }
    }
}
