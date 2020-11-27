using System;

namespace OOPEksamen
{
    class Program
    {
        static void Main(string[] args)
        {
            Stregsystem stregSystem = new Stregsystem();
            StregsystemCLI stregSystemCLI = new StregsystemCLI(true, stregSystem);

            stregSystemCLI.Start();




        }

    }
}