using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q1
{
    public class Calculator
    {
        public INotifiable subcriber { get; set; }
        public void Divide(float a, float b)
        {
            if(b!=0)
            {
                Console.WriteLine(a / b);
            }
            else
            {
                //RAISE EVENT COMPUTATION ERROR TO SUBCRIBER
                //WITH MESSAGE 'Divide to 0 Error'
               if(subcriber != null)
                {
                    subcriber.notify("Divide to 0 Error");
                }

            }
        }
    }
}
