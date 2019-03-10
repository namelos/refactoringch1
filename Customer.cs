using System.Collections.Generic;

namespace refactoring
{
    public class Customer
    {
        private readonly string _name;
        private List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            _name = name;
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + Name + "\n";
            foreach (var each in _rentals)
            {
                var thisAmount = ThisAmount(each);

                frequentRenterPoints++;

                if ((each.Movie.PriceCode == MovieType.NewRelease) && each.DaysRented > 1) frequentRenterPoints++;

                result += "\t" + each.Movie.Title + "\t" + thisAmount + "\n";
                totalAmount += thisAmount;
            }

            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }

        private double ThisAmount(Rental each)
        {
            double thisAmount = 0;

            switch (each.Movie.PriceCode)
            {
                case MovieType.Regular:
                    thisAmount += 2;
                    if (each.DaysRented > 2)
                        thisAmount += (each.DaysRented - 2) * 1.5;
                    break;
                case MovieType.NewRelease:
                    thisAmount += each.DaysRented * 3;
                    break;
                case MovieType.Childrens:
                    thisAmount += 1.5;
                    if (each.DaysRented > 3)
                        thisAmount += (each.DaysRented - 3) * 1.5;
                    break;
            }

            return thisAmount;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}