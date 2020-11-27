using System;
using System.Linq;
using System.Collections.Generic;

namespace OOPEksamen
{
    class Stregsystem : IStregsystem
    {
        private List<Product> products = CSVHandler.CsvProduct("products.csv");
        private List<User> users = CSVHandler.CsvUser("users.csv");
        
        private List<Transaction> TransactionHistory = new List<Transaction>();

        

        private void ExecuteTransaction(Transaction trans)
        {
            trans.Execute();
            TransactionHistory.Add(trans);
        }

        public InsertCashTransaction AddCreditsToAccount(User user, decimal amount)
        {
            InsertCashTransaction insertCashTransaction = new InsertCashTransaction(user, amount);

            ExecuteTransaction(insertCashTransaction);
            
            return insertCashTransaction;
        }
        public List<Product> ActiveProducts()
        {
            List<Product> ActiveProducts = products.Where(n => n.Active == true).ToList();

            return ActiveProducts;
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

        public List<Transaction> GetTransactions(User user, int count)
        {
            List<Transaction> allTransactions = TransactionHistory.Where(n => n.User == user).ToList();

            allTransactions.Sort();
            //allTransactions.Reverse();

            List<Transaction> trans = new List<Transaction>();

            if (allTransactions.Count > count)
            {
                for (int i = 0; i < count; i++)
                {
                    trans.Add(allTransactions[i]);
                }   
            }else
            {
                foreach (Transaction transaction in allTransactions)
                {
                    trans.Add(transaction);
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
            User user = users.FirstOrDefault(n => n.Username == username);

            if (user != null)
                return user;
            else
                throw new UserDoesNotExistException(username);
        }

        public void ActivateProduct(int productID)
        {
            int index = products.FindIndex(n => n.ProductID == productID);

            if (index == -1)
                throw new InvalidProductIdException();
            else if (products[index].Active == false)
                products[index].Active = true;
        }
        public void DectivateProduct(int productID)
        {
            int index = products.FindIndex(n => n.ProductID == productID);

            if (index == -1)
                throw new InvalidProductIdException();
            else if (products[index].Active == true)
                products[index].Active = false;
        }

        public void ActivateCredit(int productID)
        {
            int index = products.FindIndex(n => n.ProductID == productID);

            if (index == -1)
                throw new InvalidProductIdException();
            else if (products[index].CanBeBoughtOnCredit == false)
                products[index].CanBeBoughtOnCredit = true;
        }

        public void DeactivateCredit(int productID)
        {
            int index = products.FindIndex(o => o.ProductID == productID);

            if (index == -1)
                throw new InvalidProductIdException();
            else if (products[index].CanBeBoughtOnCredit == true)
                products[index].CanBeBoughtOnCredit = false;
        }
    }
}