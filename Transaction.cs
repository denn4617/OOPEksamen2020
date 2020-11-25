using System;

namespace OOPEksamen
{
    public abstract class Transaction
    {
        public int TransactionID { get; set; }
        public User User { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }


        // TODO: Spørg Norspang
        public Transaction(int transactionID, User user, decimal transactionAmount)
        {
            TransactionID = transactionID;
            User = user ?? throw new ArgumentNullException(nameof(user));
            TransactionDate = DateTime.Now;
            TransactionAmount = transactionAmount;
        }
        public virtual void Execute()
        {
            User.Balance += TransactionAmount;
        }

        public override string ToString()
        {
            return $"Transaction ID: {TransactionID}" +
                   $"User: {User}" +
                   $"Amount: {TransactionAmount}" +
                   $"Transaction date: {TransactionDate}";
        }

    }
}
