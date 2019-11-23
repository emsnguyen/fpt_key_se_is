using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DemoSynchronization
{
    class Program
    {
        static void Main(string[] args)
        {
            object shared = new object();
            Runner r1 = new Runner() {Name = "A",q=shared };
            Runner r2 = new Runner() {Name = "B", q= shared };
            Thread t1 = new Thread(new ThreadStart(r1.Run));
            t1.Start();
            Thread t2 = new Thread(new ThreadStart(r2.Run));
            t2.Start();
            Console.ReadKey();

        }
    }

    class Runner
    {
        public string Name { get; set; }
        public object q { get; set; }

        public void Run()
        {
            for(int i=0;i<5;i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(Name + " is running free");
            }

            lock(q)
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(Name + " is running in priority mode");
                }
            }


        }

    }
}
