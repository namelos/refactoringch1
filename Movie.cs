using System;

namespace refactoring
{
    public class Movie
    {
        private readonly string _title;

        private MovieType _priceCode { get; set; }

        public Movie(string title, MovieType priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public MovieType PriceCode
        {
            get { return this._priceCode; }
            set { _priceCode = value; }
        }
        
        public string Title
        {
            get { return _title; }
        }
        
        public double GetCharge(int daysRented)
        {
            double thisAmount = 0;

            switch (PriceCode)
            {
                case MovieType.Regular:
                    thisAmount += 2;
                    if (daysRented > 2)
                        thisAmount += (daysRented - 2) * 1.5;
                    break;
                case MovieType.NewRelease:
                    thisAmount += daysRented * 3;
                    break;
                case MovieType.Childrens:
                    thisAmount += 1.5;
                    if (daysRented > 3)
                        thisAmount += (daysRented - 3) * 1.5;
                    break;
            }

            return thisAmount;
        }
    }
}