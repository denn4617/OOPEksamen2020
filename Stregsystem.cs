using System;
using System.Linq;
using System.Collections.Generic;

namespace OOPEksamen
{
    class Stregsystem : IStregsystem
    {
        CSVHandler csvHandler = new CSVHandler();
        private List<Product> products;
        private List<User> users;
        public IEnumerable<Product> ActiveProducts => products.Where(product => product.Active);
        List<Transaction> Transactions = new List<Transaction>();

        
        
        public Stregsystem()
        {
            products = csvHandler.CsvProduct("../../../products.csv");
            users = csvHandler.CsvUser("../../../users.csv");
            foreach (var item in ActiveProducts)
            {
                Console.WriteLine(item);
            }
            //CSVHandler.CsvProduct("../../../Data/products.csv");
            //CSVHandler.CsvUser(@"D:\Eksamenopgave - OOP\OOPEksamen\Data\users.csv");
        }
    }
}