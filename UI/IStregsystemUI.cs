using System.Collections.Generic;
namespace OOPEksamen
{
    interface IStregsystemUI
    {
        void Start();
        void DisplayUserInfo(User user, List<Transaction> transactions);
        void DisplayUserNotFound(string username); 
        void DisplayProductNotFound(int productID); 
        void DisplayTooManyArgumentsError(string command); 
        void DisplayAdminCommandNotFoundMessage(string adminCommand); 
        void DisplayUserBuysProduct(BuyTransaction transaction, int count);
        void DisplayUserBuysProducts(List<BuyTransaction> transaction);
        void DisplayInsufficientCash(User user, Product product);
        void DisplayGeneralError(string errorString);
        void Close();
        
    }
}
