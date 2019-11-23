using FPTClock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstClient
{
    class Program : IAlarmable
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Clock c1 = new Clock();
            c1.subcriber = p;
            c1.Hour = 0;
            c1.Minute = 1;
            c1.Second = 1;
            c1.Start();
            SecondGuy s = new SecondGuy();
            Clock c2 = new Clock();
            c2.subcriber = s;
            c2.Hour = 0;
            c2.Minute = 1;
            c2.Second = 1;
            c2.Start();


            Console.ReadKey();
        }

        public void Alarm()
        {
            Console.WriteLine("Bip bip bip");
        }
    }

    class SecondGuy : IAlarmable
    {
        public void Alarm()
        {
            Console.WriteLine("SecondGuy");
        }
    }
}
