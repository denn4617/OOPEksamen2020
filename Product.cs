using System;
using System.Collections.Generic;

namespace OOPEksamen
{
    class Product
    {
        private static int IDCounter = 1;
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public bool CanBeBoughtOnCredit { get; set; }

        public Product(string name, decimal price, bool active, bool canBeBoughtOnCredit)
        {
            ID = IDCounter;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Active = active;
            CanBeBoughtOnCredit = canBeBoughtOnCredit;

            IDCounter++;
        }

        public override string ToString()
        {
            return $"{ID}, {Name}, {Price}";
        }
    }
}