namespace refactoring
{
    public class Rental
    {
        private int _daysRented;
        private readonly Movie _movie;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            DaysRented = daysRented;
        }

        public int DaysRented
        {
            get { return _daysRented; }
            set { _daysRented = value; }
        }
        
        public Movie Movie
        {
            get { return _movie; }
        }

        public double Charge
        {
            get
            {
                double thisAmount = 0;

                switch (Movie.PriceCode)
                {
                    case MovieType.Regular:
                        thisAmount += 2;
                        if (DaysRented > 2)
                            thisAmount += (DaysRented - 2) * 1.5;
                        break;
                    case MovieType.NewRelease:
                        thisAmount += DaysRented * 3;
                        break;
                    case MovieType.Childrens:
                        thisAmount += 1.5;
                        if (this.DaysRented > 3)
                            thisAmount += (DaysRented - 3) * 1.5;
                        break;
                }

                return thisAmount;
            }
        }

        public int FrequentRenterPoints => Movie.PriceCode == MovieType.NewRelease && DaysRented > 1 ? 2 : 1;
    }
}