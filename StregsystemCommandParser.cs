using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPEksamen
{
    class StregsystemCommandParser
    {
        Stregsystem StregSystem { get; set; }
        IStregsystemUI stregsystemCLI { get; set; }
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
                            stregsystemCLI.DisplayGeneralError("Product number is not a number");
                        break;
                    case 3:
                        if (userCommandArr[1].All(char.IsDigit) && userCommandArr[2].All(char.IsDigit))
                            BuyMultipleItems(userCommandArr);
                        else
                            stregsystemCLI.DisplayGeneralError("Command was not recognized");
                        break;
                    default:
                        stregsystemCLI.DisplayGeneralError("Command was not recognized");
                        break;
                }
            }
            else
            {
                if (userCommand[0] == ':')
                {
                    ExecuteAdminCommand(userCommand);
                }
                else
                {
                    DisplayRelevantUserInfo(userCommand);
                }
            }
        }

        // TODO: Lav dise methods
        private void DisplayRelevantUserInfo(string username)
        {
            try
            {
                User user = this.StregSystem.GetUserByUsername(username);
                IEnumerable<Transaction> trans = StregSystem.GetTransactions(user, 10);
                
                if (trans.Any())
                    stregsystemCLI.DisplayUserInfo(user, trans);
                else
                    stregsystemCLI.DisplayUserInfo(user);

            }
            catch (UserDoesNotExistException)
            {

                stregsystemCLI.DisplayUserNotFound(username);
            }
        }

        private void ExecuteAdminCommand(string userCommand)
        {
            throw new NotImplementedException();
        }

        private void BuyMultipleItems(object commandArr)
        {
            throw new NotImplementedException();
        }

        private void BuyItem(string v1, int v2)
        {
            throw new NotImplementedException();
        }
    }
}

