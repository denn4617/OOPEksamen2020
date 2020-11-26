using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace OOPEksamen
{
    // Skal muligvis være en static class
    class CSVHandler
    {
        private List<Product> ProductListObj { get; } = new List<Product>();
        
        private static List<string> CsvReader(string csvPath)
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

        public static List<User> CsvUser(string csvPath)
        { 
            List<string> userListString = CsvReader(csvPath);
            List<User> users = new List<User>();

            foreach (var line in userListString)
            {
                string[] userArr = line.Split(",").ToArray();
                int userID = Convert.ToInt32(userArr[0]);
                string userFirstname = userArr[1];
                string userLastname = userArr[2];
                string userUsername = userArr[3];
                decimal userBalance = Convert.ToDecimal(userArr[4]);
                string userEmail = userArr[5];
                User user = new User(userID, userFirstname, userLastname, userUsername, userEmail, userBalance);
                users.Add(user);
            }

            // TODO: Disse to lines skal slettes (bruges kun for test / udskriver alle produkt objekter)
            users.ForEach(i => Console.WriteLine(i));

            return users;
        }
        public static List<Product> CsvProduct(string csvPath)
        {
            List<string> productListString = CsvReader(csvPath);
            List<Product> products = new List<Product>();

            foreach (var line in productListString)
            {
                string[] productArr = line.Split(";").ToArray();
                
                int productID = Convert.ToInt32(productArr[0]);
                string productName = DiscardHTMLTags(productArr[1]);
                decimal productPrice = Convert.ToDecimal(productArr[2]);
                bool productIsActive = (productArr[3] == "1");
                //DateTime productEndDate = DateTime.Parse(productArr[4].Trim('"'));

                if (productArr[4].Length > 3)
                    products.Add(new SeasonalProduct(productName, productPrice, productIsActive, false, DateTime.Parse(productArr[4].Trim('"'))));
                else
                    products.Add(new Product(productName, productPrice, productIsActive, false));
                

            }

            // TODO: Disse to lines skal slettes (bruges kun for test / udskriver alle produkt objekter)
            products.ForEach(i => Console.WriteLine(i));

            return products;
        }
        
        private static string DiscardHTMLTags(string productName)
        {
            return Regex.Replace(productName, "<.*?>", string.Empty);
            //bool isHTMLtag = false;
            //bool isHTMLEndTag = false;

            //for (int i = 0; i < productName.Length; i++)
            //{
            //    if (productName[i] == '<')
            //        isHTMLtag = true;

            //    if (productName[i] == '>')
            //        isHTMLEndTag = true;

            //    if (isHTMLtag || productName[i] == '"')
            //    {
            //        productName = productName.Remove(i, 1);
            //        i--;
            //        if (isHTMLEndTag)
            //        {
            //            isHTMLtag = false;
            //            isHTMLEndTag = false;
            //        }
            //    }
            //}
            //return productName;
        }
    }
}