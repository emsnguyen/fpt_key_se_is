using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Q1;

namespace ConsoleApplication1
{
    class Program : INotifiable
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            Calculator calculator = new Calculator();
            //SUBCRIBE FOR THE COMPUTATION ERROR HERE
            calculator.subcriber = p;

            calculator.Divide(10, 1); //this code works well
            calculator.Divide(10, 0); // this code makes calculator to raise an error
            Console.ReadKey();
        }

        public void notify(string message)
        {
            Console.WriteLine(message);
        }
    }
}
