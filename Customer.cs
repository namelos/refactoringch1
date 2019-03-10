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
                frequentRenterPoints += FrequentRenterPoints(each);

                result += "\t" + each.Movie.Title + "\t" + each.GetCharge() + "\n";
                totalAmount += each.GetCharge();
            }

            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }

        private int FrequentRenterPoints(Rental each)
        {
            if (each.Movie.PriceCode == MovieType.NewRelease && each.DaysRented > 1) return 2;
            return 1;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}