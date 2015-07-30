using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Library
{
    public sealed class TimerEventArgs : EventArgs
    {
        int countTicks;

        public TimerEventArgs(int ticks)
        {
            this.countTicks = ticks;
        }

        public int CountTicks
        {
            get { return countTicks; }   
        }
    }
}
