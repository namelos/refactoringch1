namespace refactoring
{
    public class Rental
    {
        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public int DaysRented { get; set; }
        public Movie Movie { get; }
        public double Charge => Movie.GetCharge(DaysRented);
        public int FrequentRenterPoints => Movie.PriceCode == MovieType.NewRelease && DaysRented > 1 ? 2 : 1;
    }
}