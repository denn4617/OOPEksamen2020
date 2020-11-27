using System;

namespace OOPEksamen
{
    class BuyTransaction : Transaction
    {
        public Product Product { get; }
        public int ProductAmount { get; }
        public BuyTransaction(User user, Product product) 
            : base(user, -product.Price)
        {
            Product = product;
            ProductAmount = 1;
        }

        // Multibuy constructer
        public BuyTransaction(User user, Product product, int productAmount) 
            : base(user, -product.Price * productAmount)
        {
            Product = product;
            ProductAmount = productAmount;
        }

        public override void Execute()
        {
            if (User.Balance >= -TransactionAmount || Product.CanBeBoughtOnCredit)
                User.Balance += TransactionAmount;
            else
                throw new InsufficientCreditsException(User, Product);
        }
        public override string ToString()
        {
            return "--|Purchase|--\n" + base.ToString();
        }
    }
}
