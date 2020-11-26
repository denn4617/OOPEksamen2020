using System;

namespace OOPEksamen
{
    abstract class Transaction
    {
        private static int IDCounter =  1;
        public int TransactionID { get; set; }
        public User User { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }


        // TODO: Spørg Norspang
        public Transaction(User user, decimal transactionAmount)
        {
            TransactionID = IDCounter;
            User = user ?? throw new ArgumentNullException(nameof(user));
            TransactionDate = DateTime.Now;
            TransactionAmount = transactionAmount;

            IDCounter++;
        }

        public abstract void Execute();

        public override string ToString()
        {
            return $"Transaction ID: {TransactionID}\n" +
                   $"User: {User}\n" +
                   $"Amount: {TransactionAmount}\n" +
                   $"Transaction date: {TransactionDate}\n";
        }
    }
}
