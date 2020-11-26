using System;


namespace OOPEksamen
{
    class SeasonalProduct : Product
    {
        public DateTime SeasonStartDate { get; set; }
        public DateTime SeasonEndDate { get; set; }

        public SeasonalProduct(string name, decimal price, bool active, bool canBeBoughtOnCredit,
               DateTime seasonEndDate) : base(name, price, active, canBeBoughtOnCredit)
        {
            SeasonEndDate = seasonEndDate;
            // FIX DET HER LORT - skal seasonStartDate være en parameter i constructeren?!!
            if (SeasonStartDate <= DateTime.Now && seasonEndDate >= DateTime.Now && active)
                Active = true;
            else
                Active = false;
        }
        public override string ToString()
        {
            return $"{ID}, {Name}, {Price}";
        }

    }
}
