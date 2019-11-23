using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FPTClock
{
    public class Clock
    {

        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public IAlarmable subcriber { get; set; }
        Thread t;
        public void Start()
        {
            t = new Thread(new ThreadStart(Run));
            t.Start();
        }

        private void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                DateTime current = DateTime.Now;
                if (
                    Hour <= current.Hour &&
                    Minute <= current.Minute &&
                    Second <= current.Second
                    )
                {
                    if (subcriber != null)
                    {
                        subcriber.Alarm();
                        isRunning = false;
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}
