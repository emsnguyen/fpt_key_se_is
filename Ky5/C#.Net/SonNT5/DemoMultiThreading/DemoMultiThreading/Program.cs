using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DemoMultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread t1 = new Thread(new ThreadStart(Program.Count));
            //Thread t2 = new Thread(new ThreadStart(Program.Count));
            //t1.Start();
            //t2.Start();
            //for (int i=0;i<10;i++)
            //{
            //    Thread.Sleep(100);
            //    Console.WriteLine("Main:" + i);
            //}
            CounterThreadHandler handlerforThread1
                = new CounterThreadHandler() { Count = 5,Name="A" };
            CounterThreadHandler handlerforThread2
                = new CounterThreadHandler() { Count = 10, Name = "B" };

            Thread t1 = new Thread(new ThreadStart(handlerforThread1.Run));
            Thread t2 = new Thread(new ThreadStart(handlerforThread2.Run));
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
            Console.WriteLine("Finished");

            Console.ReadKey();
        }

        static void Count()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine("Thread:" + i);
            }
        } 
    }

    class CounterThreadHandler
    {
        public int Count { get; set; }
        public string Name { get; set; }
        public void Run()
        {
            for (int i = 0; i < Count; i++)
            {
                Thread.Sleep(100);
                Console.WriteLine(Name +":" + i);
            }
        }
        

    }

}
