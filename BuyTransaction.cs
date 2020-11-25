using System;

namespace OOPEksamen
{
    class BuyTransaction : Transaction
    {
        public Product Product { get; }
        public int ProductAmount { get; }
        public BuyTransaction(User user, decimal amount) : base(user, amount)
        {

        }

        // Multibuy constructer
        public BuyTransaction(User user, decimal amount, int productAmount) : base(user, amount)
        {

        }
    }
}
