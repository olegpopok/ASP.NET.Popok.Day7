using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task1.Library
{
    public class TimerManager
    {
        public event EventHandler<TimerEventArgs> Timer;

        protected virtual void OnTimer(TimerEventArgs e)
        {
            Thread.Sleep(e.CountTicks);

            EventHandler<TimerEventArgs> temp = Timer;

            if (temp != null)
            {
                temp(this, e);
            }
        }

        public void SimulateTimer(int ticks)
        {
            OnTimer(new TimerEventArgs(ticks));
        }
    }
}
