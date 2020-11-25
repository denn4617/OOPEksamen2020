using System;
using System.Collections.Generic;

namespace OOPEksamen
{
    class Product
    {
        //private int IDCounter { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }

        public Product(int id, string name, decimal price, bool active, bool canBeBoughtOnCredit)
        {
            ID = id;
            Name = name;
            Price = price;
            Active = active;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;
        }

        public override string ToString()
        {
            return $"{ID} - {Name} - {Price}";
        }
    }
}