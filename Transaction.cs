using System;

namespace OOPEksamen
{
    public abstract class Transaction
    {
        private int IDCounter = 0;
        public int TransactionID { get; set; }
        public User User { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }


        // TODO: Spørg Norspang
        public Transaction(User user, decimal amount)
        {
            TransactionID = IDCounter;
            User = user ?? throw new ArgumentNullException(nameof(user));
            TransactionDate = DateTime.Now;
            TransactionAmount = amount;

            IDCounter++;
        }

        public override string ToString()
        {
            return $"Transaction ID: {TransactionID}" +
                   $"User: {User}" +
                   $"Amount: {TransactionAmount}" +
                   $"Transaction date: {TransactionDate}";
        }


        //public abstract void Execute()
        //{

        //}
    }
}
