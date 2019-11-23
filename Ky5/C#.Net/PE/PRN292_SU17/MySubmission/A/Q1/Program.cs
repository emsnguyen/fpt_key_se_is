using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            Payment payment = new Payment() { Amount = 1000 };
            payment.AmountChanged += payment.notifyAmountChanged; // your handling function
            payment.Amount = 990;
            Console.WriteLine("Tax:" + payment.ComputeTax());
            Console.ReadKey();
        }

    }
}
