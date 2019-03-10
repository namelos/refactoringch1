namespace refactoring
{
    abstract class Price
    {
        public abstract MovieType PriceCode { get; }
        public abstract double GetCharge(int daysRented);
        public int GetFrequentRenterPoints(int daysRented) => 1;
    }
    class ChildrensPrice : Price
    {
        public override MovieType PriceCode => MovieType.Childrens;

        public override double GetCharge(int daysRented)
        {
            double thisAmount = 0;
            thisAmount += 1.5;
            if (daysRented > 3)
                thisAmount += (daysRented - 3) * 1.5;
            return thisAmount;
        }
    }

    class NewReleasePrice : Price
    {
        public override MovieType PriceCode => MovieType.NewRelease;

        public override double GetCharge(int daysRented)
        {
            double thisAmount = 0;
            thisAmount += daysRented * 3;
            return thisAmount;
        }
        
        public new int GetFrequentRenterPoints(int daysRented) => daysRented > 1 ? 2 : 1;
    }

    class RegularPrice : Price
    {
        public override MovieType PriceCode => MovieType.Regular;

        public override double GetCharge(int daysRented)
        {
            double thisAmount = 0;
            thisAmount += 2;
            if (daysRented > 2)
                thisAmount += (daysRented - 2) * 1.5;
            return thisAmount;
        }
    }
}