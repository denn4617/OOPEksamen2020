using System;
using System.Collections.Generic;
namespace OOPEksamen
{
    class StregsystemCLI : IStregsystemUI
    {
        private bool SystemRunning = true;
        Stregsystem stregSystem;

        private IEnumerable<Product> ActiveProducts = new List<Product>();

        public StregsystemCLI(bool systemRunning, Stregsystem stregSystem)
        {
            SystemRunning = systemRunning;
            this.stregSystem = stregSystem;
        }

        public void Start()
        {
            StregsystemCommandParser stregsystemCommandParser = new StregsystemCommandParser();
            string userCommand;
            do
            {
                ActiveProducts = stregSystem.ActiveProducts;
                Console.Clear();
                PrintMainMenu();
                Console.WriteLine("\nQuickbuy: ");
                userCommand = Console.ReadLine();
                stregsystemCommandParser.ParseCommand(userCommand);
            } while (SystemRunning);
        }

        private void PrintMainMenu()
        {
            string title =
                    #region ASCIIArtTitle
                    @" 
   _____ __                                  __               
  / ___// /_________  ____ ________  _______/ /____  ____ ___ 
  \__ \/ __/ ___/ _ \/ __ `/ ___/ / / / ___/ __/ _ \/ __ `__ \
 ___/ / /_/ /  /  __/ /_/ (__  ) /_/ (__  ) /_/  __/ / / / / /
/____/\__/_/   \___/\__, /____/\__, /____/\__/\___/_/ /_/ /_/ 
                   /____/     /____/                          
                    ";
                #endregion
            Console.WriteLine(title);

            PrintProducts();
        }

        private void PrintProducts()
        {
            foreach (var item in ActiveProducts)
            {
                Console.WriteLine(item);
            }
        }
        public void DisplayUserInfo(User user)
        {
            Console.Clear();
            Console.WriteLine(user);

            if(UserBalanceNotification(user))
                Console.WriteLine($"Your balance is running low: {user.Balance} kr");
           
            ReturnToMenu();
        }

        public void DisplayUserInfo(User user, IEnumerable<Transaction> transactions)
        {
            Console.Clear();
            Console.WriteLine(user);
            if(UserBalanceNotification(user))
                Console.WriteLine($"Your balance is running low: {user.Balance} kr");

            foreach (Transaction transaction in transactions)
            {
                Console.WriteLine(transaction);
            }

            ReturnToMenu();
        }

        public void DisplayUserNotFound(string username)
        {
            Console.Clear();
            Console.WriteLine($"User: {username} could not be found!");
            ReturnToMenu();
        }
        public void DisplayProductNotFound(int productID)
        {
            Console.Clear();
            Console.WriteLine($"Product: {productID} could not be found!");
            ReturnToMenu();
        }
        public void DisplayTooManyArgumentsError(string userCommand)
        {
            Console.Clear();
            Console.WriteLine($"{userCommand} has to many arguments");
            ReturnToMenu();
        }
        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.Clear();
            Console.WriteLine($"Command: {adminCommand} is not an admin command");
            ReturnToMenu();
        }
        public void DisplayInsufficientCash(User user, Product product)
        {
            Console.Clear();
            Console.WriteLine($"{user.Username} balance is too low: {user.Balance}kr\n Product price: {product.Price}kr");
            ReturnToMenu();
        }
        public void DisplayGeneralError(string errorString)
        {
            Console.Clear();
            Console.WriteLine(errorString);
            ReturnToMenu();
        }
        
        // TODO: Forstår denne method fra søren
        public void DisplayUserBuysProduct(BuyTransaction buyTransaction, int amount)
        {
            Console.Clear();
            if(amount > 1)
                Console.WriteLine($"{buyTransaction.User.Username} bought: {buyTransaction.ProductAmount} x {buyTransaction.Product.Name} - {buyTransaction.TransactionAmount} kr");
            else
                Console.WriteLine($"{buyTransaction.User.Username} bought: {buyTransaction.Product.Name} - {buyTransaction.TransactionAmount} kr");
            ReturnToMenu();
        }
        // TODO: Forstår denne method fra søren
        public void DisplayUserBuysProducts(List<BuyTransaction> buyTransactions)
        {
            Console.Clear();
            foreach (var item in buyTransactions)
            {
                Console.WriteLine(item);
            }
            ReturnToMenu();
        }
        
        private bool UserBalanceNotification(User user)
        {
            if (user.Balance < 50m)
                return true;
            else
                return false;
        }
        private void ReturnToMenu()
        {
            Console.WriteLine("Press a key to return to the menu!");
            Console.ReadKey();
        }

        public void Close()
        {
            SystemRunning = false;
        }

    }
 }

