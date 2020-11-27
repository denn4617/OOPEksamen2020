using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPEksamen
{
    class StregsystemController
    {
        Stregsystem StregSystem { get; set; }
        IStregsystemUI StregsystemUI { get; set; }
        
        public StregsystemController(Stregsystem stregsystem, IStregsystemUI stregsystemUI)
        {
            StregSystem = stregsystem;
            StregsystemUI = stregsystemUI;
        }
        public void ParseCommand(string userCommand)
        {
            string[] userCommandArr;

            if (userCommand.Contains(' ') && !(userCommand[0] == ':'))
            {
                userCommandArr = userCommand.Split(' ');
                switch (userCommandArr.Length)
                {
                    case 2:
                        if (userCommandArr[1].All(char.IsDigit))
                            BuyItem(userCommandArr[0], int.Parse(userCommandArr[1]));
                        else
                            StregsystemUI.DisplayGeneralError("Product number is not a number");
                        break;
                    case 3:
                        if (userCommandArr[1].All(char.IsDigit) && userCommandArr[2].All(char.IsDigit))
                            BuyMultipleItems(userCommandArr);
                        else
                            StregsystemUI.DisplayGeneralError("Not a valid command");
                        break;
                    default:
                        StregsystemUI.DisplayGeneralError("Not a valid command");
                        break;
                }
            }
            else
            {
                if (userCommand[0] == ':')
                    ExecuteAdminCommand(userCommand);
                else
                    DisplayRelevantUserInfo(userCommand);
            }
        }

        private void ExecuteAdminCommand(string userCommand)
        {
            string[] userCommandArr;
            if (userCommand.Contains(' '))
            {
                userCommandArr = userCommand.Split(' ');
                ExecuteModifyingCommands(userCommandArr);
            }
            else if (userCommand == ":q" || userCommand == ":quit")
            {
                StregsystemUI.Close();
            }
        }
        private void ExecuteModifyingCommands(string[] userCommandArr)
        {
            switch (userCommandArr[0])
            {
                case ":addcredits":
                    AddCreditsToUser(userCommandArr);
                    break;
                case ":crediton":
                    ActivateCredit(userCommandArr);
                    break;
                case ":creditoff":
                    DeactivateCredit(userCommandArr);
                    break;
                case ":activate":
                    ActivateProduct(userCommandArr);
                    break;
                case ":deactivate":
                    DeactivateProduct(userCommandArr);
                    break;
                default:
                    break;
            }
        }
        private void AddCreditsToUser(string[] commandArr)
        {
            if (commandArr.Length == 3)
            {
                if (commandArr[2].All(char.IsDigit))
                    try
                    {
                        StregSystem.AddCreditsToAccount((StregSystem.GetUserByUsername(commandArr[1])), decimal.Parse(commandArr[2]));
                    }
                    catch (UserDoesNotExistException)
                    {
                        StregsystemUI.DisplayUserNotFound(commandArr[1]);
                    }
            }
        }
        private void ActivateCredit(string[] commandArr)
        {
            if (commandArr[1].All(char.IsDigit))
            {
                try
                {
                    StregSystem.ActivateCredit(int.Parse(commandArr[1]));
                }
                catch (InvalidProductIdException)
                {
                    StregsystemUI.DisplayProductNotFound(int.Parse(commandArr[1]));
                }
            }
        }
        private void DeactivateCredit(string[] commandArr)
        {
            if (commandArr[1].All(char.IsDigit))
            {
                try
                {
                    StregSystem.DeactivateCredit(int.Parse(commandArr[1]));
                }
                catch (InvalidProductIdException)
                {
                    StregsystemUI.DisplayProductNotFound(int.Parse(commandArr[1]));
                }
            }
        }
        private void ActivateProduct(string[] commandArr)
        {
            if (commandArr[1].All(char.IsDigit))
            {
                try
                {
                    StregSystem.ActivateProduct(int.Parse(commandArr[1]));
                }
                catch (InvalidProductIdException)
                {
                    StregsystemUI.DisplayProductNotFound(int.Parse(commandArr[1]));
                }
            }
        }

        private void DeactivateProduct(string[] commandArr)
        {
            if (commandArr[1].All(char.IsDigit))
            {
                try
                {
                    StregSystem.DectivateProduct(int.Parse(commandArr[1]));
                }
                catch (InvalidProductIdException)
                {
                    StregsystemUI.DisplayProductNotFound(int.Parse(commandArr[1]));
                }
            }
        }

        private void DisplayRelevantUserInfo(string username)
        {
            try
            {
                User user = StregSystem.GetUserByUsername(username);
                List<Transaction> trans = StregSystem.GetTransactions(user, 10);

                if (!trans.Any())
                    StregsystemUI.DisplayUserInfo(user);
                else
                    StregsystemUI.DisplayUserInfo(user, trans);

            }
            catch (UserDoesNotExistException)
            {

                StregsystemUI.DisplayUserNotFound(username);
            }
        }

        private void BuyMultipleItems(string[] userCommandArr)
        {
            string username = userCommandArr[0];
            int amount = int.Parse(userCommandArr[1]);
            int productId = int.Parse(userCommandArr[2]);
            List<BuyTransaction> buyTransactions = new List<BuyTransaction>();

            if (amount > 0)
            {
                try
                {
                    User user = StregSystem.GetUserByUsername(username);
                    Product product = StregSystem.GetProductByID(productId);

                    if (product.Active)
                    {
                        for (int i = 0; i < amount; i++)
                        {
                            try
                            {
                                buyTransactions.Add(StregSystem.BuyProduct(user, product));
                            }
                            catch (InsufficientCreditsException)
                            {
                                StregsystemUI.DisplayInsufficientCash(user, product);
                            }
                        }
                        StregsystemUI.DisplayUserBuysProducts(buyTransactions);
                    }
                }
                catch (UserDoesNotExistException)
                {
                    StregsystemUI.DisplayUserNotFound(username);
                }
                catch (InvalidProductIdException)
                {
                    StregsystemUI.DisplayProductNotFound(productId);
                }
            }
            else
                StregsystemUI.DisplayGeneralError("You have to buy atleast one item :)");
        }

        private void BuyItem(string username, int id)
        {
            User user;
            Product product;

            try
            {
                product = StregSystem.GetProductByID(id);
                user = StregSystem.GetUserByUsername(username);

                if (product.Active)
                {
                    try
                    {
                        StregsystemUI.DisplayUserBuysProduct(StregSystem.BuyProduct(user, product));
                    }
                    catch (InsufficientCreditsException)
                    {
                        StregsystemUI.DisplayInsufficientCash(user, product);
                    }
                }
            }
            catch (UserDoesNotExistException)
            {
                StregsystemUI.DisplayUserNotFound(username);
            }
            catch (InvalidProductIdException)
            {
                StregsystemUI.DisplayProductNotFound(id);
            }
        }


    }

 }

