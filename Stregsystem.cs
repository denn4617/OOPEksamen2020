using System.Linq;
using System.Collections.Generic;

namespace OOPEksamen
{
    class Stregsystem : IStregsystem
    {
        private List<Product> products = CSVHandler.CsvProduct("../../../products.csv");
        private List<User> users = CSVHandler.CsvUser("../../../users.csv");
        //public IEnumerable<Product> ActiveProducts => ProductListObj.Where(product => product.Active);
        List<Transaction> Transactions = new List<Transaction>();
        

        public Stregsystem()
        {
            CSVHandler.CsvProduct("../../../Data/products.csv");
            //CSVHandler.CsvUser(@"D:\Eksamenopgave - OOP\OOPEksamen\Data\users.csv");
        }
    }
}