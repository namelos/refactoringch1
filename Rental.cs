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
    }
}