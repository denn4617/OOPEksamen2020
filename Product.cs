using System;
using System.Collections.Generic;

namespace OOPEksamen
{
    class Product
    {
        
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }

        public Product(int productID, string name, decimal price, bool active, bool canBeBoughtOnCredit)
        {
            ProductID = productID;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Active = active;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public override string ToString()
        {
            return $"{ProductID}: {Name} - {Price}";
        }
    }
}