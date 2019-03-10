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
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + Name + "\n";
            foreach (var each in _rentals)
            {
                frequentRenterPoints += each.FrequentRenterPoints;

                result += "\t" + each.Movie.Title + "\t" + each.Charge + "\n";
            }

            result += "Amount owed is " + GetTotalAmount() + "\n";
            result += "You earned " + frequentRenterPoints + " frequent renter points";
            return result;
        }

        private double GetTotalAmount()
        {
            double totalAmount = 0;
            foreach (var each in _rentals) totalAmount += each.Charge;
            return totalAmount;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}