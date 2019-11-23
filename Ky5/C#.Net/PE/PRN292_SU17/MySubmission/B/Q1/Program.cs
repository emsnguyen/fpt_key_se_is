using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q1
{
    public interface IFood
    {
        float ComputeCalory();
    }
    public class Food : IFood
    {
        private float _amount;
        public delegate void AmountHandler(float oldValue, float newValue);
        public event AmountHandler AmountChanged;
        public float Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                AmountChanged?.Invoke(_amount, value);
                _amount = value;
            }
        }

        public float ComputeCalory()
        {
            return Amount * 5 / 100;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Food f = new Food() { Amount = 1000 };
            f.AmountChanged += notifyAmountChanged; // your handling function
            f.Amount = 990;
            Console.WriteLine("Calory:" + f.ComputeCalory());
            Console.ReadKey();

        }
        public static void notifyAmountChanged(float oldVal, float newVal)
        {
            Console.WriteLine($"Amount changed - old value: {oldVal}, new value: {newVal}");
        }
    }
}
