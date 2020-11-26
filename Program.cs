using System;

namespace OOPEksamen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StregsystemCLI.PrintMainMenu();
            //User user1 = new User("qq", 01, "dunnis", "kuluc", "dunni12@hotmail5aau.dk", 8.45321m);
            ////Product product1 = new Product("", 10, true, true);
            //DateTime idag = new DateTime(2020, 11, 21);
            //DateTime imorgen = new DateTime(2020, 11, 22);
            //SeasonalProduct sProduct1 = new SeasonalProduct(1, "monster", 12m, true, false, idag, imorgen);
            //Console.WriteLine(user1.Email);

            //Stregsystem.CsvProductReader();
            _ = new Stregsystem();




        }

    }
}