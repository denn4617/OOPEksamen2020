using System;
using System.Linq;
using System.Collections.Generic;

namespace OOPEksamen
{
    class Stregsystem : IStregsystem
    {
        CSVHandler csvHandler = new CSVHandler();
        private List<Product> products;
        private List<User> users;
        
        List<Transaction> TransactionHistory = new List<Transaction>();

        public IEnumerable<Product> ActiveProducts => products.Where(product => product.Active);

        private void ExecuteTransaction(Transaction trans)
        {
            trans.Execute();
            TransactionHistory.Add(trans);
        }

        public InsertCashTransaction AddCreditsToAccount(User user, int amount)
        {
            InsertCashTransaction insertCashTransaction = new InsertCashTransaction(user, amount);

            ExecuteTransaction(insertCashTransaction);
            
            return insertCashTransaction;
        }

        public BuyTransaction BuyProduct(User user, Product product)
        {
            BuyTransaction buyTransaction = new BuyTransaction(user, product);

            ExecuteTransaction(buyTransaction);

            return buyTransaction;
        }

        public BuyTransaction BuyMultipleProduct(User user, Product product, int productAmount)
        {
            BuyTransaction buyMultipleTransaction = new BuyTransaction(user, product, productAmount);

            ExecuteTransaction(buyMultipleTransaction);

            return buyMultipleTransaction;
        }

        public Product GetProductByID(int id)
        {
            Product product = products.FirstOrDefault(n => n.ProductID == id);

            if (product == null)
            {
                throw new InvalidProductIdException();
            }

            return product;
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            List<Transaction> allTransactions = TransactionHistory.Where(n => n.User == user).ToList();

            allTransactions.Sort();
            allTransactions.Reverse();

            List<Transaction> trans = new List<Transaction>();

            if (allTransactions.Count < count)
            {
                foreach (Transaction transaction in allTransactions)
                {
                    trans.Add(transaction);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    trans.Add(allTransactions[i]);
                }
            }

            return trans;
        }

        public IEnumerable<User> GetUsers(Func<User, bool> predicate)
        {
            List<User> user = new List<User>();
            foreach (var item in users)
            {
                if (predicate(item))
                {
                    user.Add(item);
                }
            }
            return user;
        }
        public User GetUserByUsername(string username)
        {
            User user = users.FirstOrDefault(o => o.Username == username);

            if (user != null)
                return user;
            else
                throw new UserDoesNotExistException(username);
        }
        public Stregsystem()
        {
            products = csvHandler.CsvProduct("../../../products.csv");
            users = csvHandler.CsvUser("../../../users.csv");
            foreach (var item in ActiveProducts)
            {
                Console.WriteLine(item);
            }
            //CSVHandler.CsvProduct("../../../Data/products.csv");
            //CSVHandler.CsvUser(@"D:\Eksamenopgave - OOP\OOPEksamen\Data\users.csv");
        }
    }
}