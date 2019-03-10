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
            string result = "Rental Record for " + Name + "\n";
            foreach (var each in _rentals)
            {
                result += "\t" + each.Movie.Title + "\t" + each.Charge + "\n";
            }

            result += "Amount owed is " + GetTotalAmount() + "\n";
            result += "You earned " + FrequentRenterPoints() + " frequent renter points";
            return result;
        }

        private int FrequentRenterPoints()
        {
            int frequentRenterPoints = 0;
            foreach (var each in _rentals) frequentRenterPoints += each.FrequentRenterPoints;
            return frequentRenterPoints;
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