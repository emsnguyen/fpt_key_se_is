using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoDelegateAndEvent
{

    public delegate void VoidMethod(string message);

    class Program
    {
        public void doA(string message)
        {
            Console.WriteLine("doA - " + message);
        }

        public void doB(string message)
        {
            Console.WriteLine("doB - " + message);
        }

        public static void invokeMethod(VoidMethod dosmth,string message)
        {
            dosmth.Invoke(message);
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            VoidMethod doA = p.doA;
            VoidMethod doB = p.doB;
            doA.Invoke("Hello Cuccu");
            doB.Invoke("Hello Cuccu");

            invokeMethod(p.doA,"Meo meo");
            invokeMethod(p.doB, "Meo meo");

            p.doA("Heheh");

            VoidMethod doC = doA + doB;
            doC.Invoke("Shit");
            Console.ReadKey();

        }
    }
}
