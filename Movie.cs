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
    }
}