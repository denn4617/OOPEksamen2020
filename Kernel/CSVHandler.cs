using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OOPEksamen
{
    // An option could be, to make this class static, since it's a helper class.
    // This would be beneficial, to avoid memory waste
    class CSVHandler
    {

        private List<string> CsvReader(string csvPath)
        {
            StreamReader csvFile = new StreamReader(csvPath);
            List<string> csvLines = new List<string>();
            string line;
            
            // Reads the first line in the CSV file
            csvFile.ReadLine();
            // Reads the rest of the lines in the CSV file
            while ((line = csvFile.ReadLine()) != null)
            {
                csvLines.Add(line);
            }
            csvFile.Close();

            return csvLines;
        }

        public List<User> CsvUser(string csvPath)
        { 
            List<string> userListString = CsvReader(csvPath);
            List<User> users = new List<User>();

            foreach (var line in userListString)
            {
                string[] userArr = line.Split(",");
                int userID = Convert.ToInt32(userArr[0]);
                string userFirstname = userArr[1];
                string userLastname = userArr[2];
                string userUsername = userArr[3];
                decimal userBalance = Convert.ToDecimal(userArr[4]);
                string userEmail = userArr[5];
                User user = new User(userID, userFirstname, userLastname, userUsername, userEmail, userBalance);
                users.Add(user);
            }

            return users;
        }
        public List<Product> CsvProduct(string csvPath)
        {
            List<string> productListString = CsvReader(csvPath);
            List<Product> products = new List<Product>();

            foreach (var line in productListString)
            {
                string[] productArr = line.Split(";");
                
                int productID = Convert.ToInt32(productArr[0]);
                string productName = DiscardHTMLTags(productArr[1]).Trim('"');
                decimal productPrice = Convert.ToDecimal(productArr[2]);
                bool productIsActive = (productArr[3] == "1");
                

                if (productArr[4].Length > 3)
                {
                    DateTime productEndDate = DateTime.Parse(productArr[4].Trim('"'));
                    products.Add(new SeasonalProduct(productID, productName, productPrice, productIsActive, false, productEndDate));
                }  
                else
                    products.Add(new Product(productID, productName, productPrice, productIsActive, false));
            }

            return products;
        }
        
        private string DiscardHTMLTags(string productName)
        {
            return Regex.Replace(productName, "<.*?>", string.Empty);
        }
    }
}