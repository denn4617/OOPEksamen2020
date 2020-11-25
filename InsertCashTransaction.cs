namespace OOPEksamen
{
    class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(int transactionID, User user, decimal transactionAmount) : base(transactionID, user, transactionAmount)
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
