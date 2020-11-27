using System;
using System.Collections.Generic;

namespace OOPEksamen
{
    interface IStregsystem
    {
        List<Product> ActiveProducts();
        InsertCashTransaction AddCreditsToAccount(User user, decimal amount);
        BuyTransaction BuyProduct(User user, Product product);
        BuyTransaction BuyMultipleProduct(User user, Product product, int productAmount);
        Product GetProductByID(int id);
        List<Transaction> GetTransactions(User user, int count);
        IEnumerable<User> GetUsers(Func<User, bool> predicate);
        User GetUserByUsername(string username);
        
    }
}
