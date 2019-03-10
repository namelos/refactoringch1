using System;

namespace refactoring
{
    public class Movie
    {
        private Price _priceCode { get; set; }

        public Movie(string title, MovieType priceCode)
        {
            Title = title;
            PriceCode = priceCode;
        }

        public MovieType PriceCode
        {
            get => _priceCode.PriceCode;
            set
            {
                switch (value)
                {
                    case MovieType.Regular:
                        _priceCode = new RegularPrice();
                        break;
                    case MovieType.NewRelease:
                        _priceCode = new NewReleasePrice();
                        break;
                    case MovieType.Childrens:
                        _priceCode = new ChildrensPrice();
                        break;
                }
            }
        }

        public string Title { get; }
        public double GetCharge(int daysRented) => _priceCode.GetCharge(daysRented);
        public int GetFrequentRenterPoints(int daysRented) => _priceCode.GetFrequentRenterPoints(daysRented);
    }
}