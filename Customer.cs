using System.Collections.Generic;
using System.Linq;

namespace refactoring
{
    public class Customer
    {
        private List<Rental> _rentals = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public string Statement()
        {
            string result = $"Rental Record for {Name}\n";
            result += _rentals.Aggregate(string.Empty, (acc, r) => $"{acc}\t{r.Movie.Title}\t{r.Charge}\n");
            result += $"Amount owed is {GetTotalAmount}\n";
            result += $"You earned {FrequentRenterPoints} frequent renter points";
            return result;
        }

        private int FrequentRenterPoints => _rentals.Sum(rental => rental.FrequentRenterPoints);
        private double GetTotalAmount => _rentals.Sum(rental => rental.Charge);

        public string Name { get; }
    }
}