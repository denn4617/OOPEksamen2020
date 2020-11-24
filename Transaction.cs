using System;

namespace OOPEksamen
{
    class Transaction
    {
        public Transaction(int iD, User user, DateTime date, decimal amount)
        {
            ID = iD;
            this.user = user;
            Date = date;
            Amount = amount;
        }

        public int ID { get; set; }
        public User user { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }


        public void Execute()
        {

        }
    }
}
