namespace OOPEksamen
{
    class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, decimal transactionAmount) : base(user, transactionAmount)
        {
        }

        public override void Execute()
        {
            User.Balance += TransactionAmount;
        }

        public override string ToString()
        {
            return "--|Insert cash|--\n" + base.ToString();
        }
    }
}
