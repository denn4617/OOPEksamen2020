namespace OOPEksamen
{
    class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(int transactionID, User user, decimal amount) : base(transactionID, user, amount)
        {
        }
    }
}
