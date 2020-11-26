using System;
using System.Collections.Generic;

namespace OOPEksamen
{
    interface IStregsystem
    { 
        IEnumerable<Product> ActiveProducts { get; }
        InsertCashTransaction AddCreditsToAccount(User user, int amount);
        BuyTransaction BuyProduct(User user, Product product);
        BuyTransaction BuyMultipleProduct(User user, Product product, int productAmount);
        Product GetProductByID(int id);
        IEnumerable<Transaction> GetTransactions(User user, int count);
        IEnumerable<User> GetUsers(Func<User, bool> predicate);
        User GetUserByUsername(string username);
        //HUSK DENNNE
        //event UserBalanceNotification UserBalanceWarning;
    }
}
