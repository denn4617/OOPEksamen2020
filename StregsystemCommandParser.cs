using System.Collections.Generic;
using System.Linq;

namespace OOPEksamen
{
    class StregsystemCommandParser
    {
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
                            stregSystemCLI.DisplayGeneralError("Product number is not a number");
                        break;
                    case 3:
                        if (userCommandArr[1].All(char.IsDigit) && userCommandArr[2].All(char.IsDigit))
                            BuyMultipleItems(commandArr);
                        else
                            stregSystemCLI.DisplayGeneralError("Command was not recognized");
                        break;
                    default:
                        stregSystemCLI.DisplayGeneralError("Command was not recognized");
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
    }
}

