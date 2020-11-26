using System;
namespace OOPEksamen
{
    class StregsystemCLI
    {
        public StregsystemCLI()
        {
        }

        public static void PrintMainMenu()
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
        }

     }
 }

