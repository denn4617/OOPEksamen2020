using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace OOPEksamen
{
    class Stregsystem
    {
        private List<User> UserListObj { get; } = new List<User>();
        private List<Product> ProductListObj { get; } = new List<Product>();
        public IEnumerable<Product> ActiveProducts => ProductListObj.Where(product => product.Active);
        List<Transaction> Transactions = new List<Transaction>();
        

        private void CsvUserReader(string csvPath)
        {
            StreamReader userCSV = new StreamReader(csvPath);

            string line, firstLine = userCSV.ReadLine();
            List<string> userListString;

            while ((line = userCSV.ReadLine()) != null)
            {
                userListString = line.Split(",").ToList();
                int userID = Convert.ToInt32(userListString[0]);
                string userFirstname = userListString[1];
                string userLastname = userListString[2];
                string userUsername = userListString[3];
                decimal userBalance = Convert.ToDecimal(userListString[4]);
                string userEmail = userListString[5];
                User user = new User(userID, userFirstname, userLastname, userUsername, userEmail, userBalance);
                UserListObj.Add(user);
            }
            // TODO: Disse to lines skal slettes (bruges kun for test / udskriver alle produkt objekter)
            UserListObj.ForEach(i => Console.WriteLine(i));
            
        }

        private void CsvProductReader(string csvPath)
        {
            StreamReader productCSV = new StreamReader(csvPath);

           
            string line, firstLine = productCSV.ReadLine();
            List<string> productListString;


            while ((line = productCSV.ReadLine()) != null)
            {
                productListString = line.Split(";").ToList();
                int productID = Convert.ToInt32(productListString[0]);
                string productName = DiscardHTMLTags(productListString[1]);
                decimal productPrice = Convert.ToDecimal(productListString[2]);
                // TODO: Spørg Norspang om hvad denne bool gør
                bool productIsActive = (productListString[3] == "1");

                Product product = new Product(productID, productName, productPrice, productIsActive, false);
                ProductListObj.Add(product);
            }
            // TODO: Disse to lines skal slettes (bruges kun for test / udskriver alle produkt objekter)
            ProductListObj.ForEach(i => Console.WriteLine(i));
            Console.WriteLine(ProductListObj[5].Price);
        }
        
        // TODO: Ændre i Norspangs kode og optimer(hvis muligt) :)
        private string DiscardHTMLTags(string productName)
        {
            bool isHTMLtag = false;
            bool isHTMLEndTag = false;

            for (int i = 0; i < productName.Length; i++)
            {
                if (productName[i] == '<')
                    isHTMLtag = true;

                if (productName[i] == '>')
                    isHTMLEndTag = true;

                if (isHTMLtag || productName[i] == '"')
                {
                    productName = productName.Remove(i, 1);
                    i--;
                    if (isHTMLEndTag)
                    {
                        isHTMLtag = false;
                        isHTMLEndTag = false;
                    }
                }
            }

            return productName;
        }

        public Stregsystem()
        {
            CsvProductReader("../../../Data/products.csv");
            CsvUserReader("../../../Data/users.csv");
        }
    }
}