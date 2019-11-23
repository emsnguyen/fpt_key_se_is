using System;
namespace Q1
{
    public class Payment : ITax
    {
        private float _amount;
        public float Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (AmountChanged != null)
                {
                    AmountChanged.Invoke(_amount, value);
                }

                _amount = value;
            }
        }
        public float ComputeTax()
        {
            return Amount / 10;
        }
        public delegate void AmountHandler(float oldAmount, float newAmount);
        public event AmountHandler AmountChanged;
        public void notifyAmountChanged(float oldAmount, float newAmount)
        {
            Console.WriteLine($"Amount changed – old value: {oldAmount}, new value: {newAmount}");
        }
    }
}
