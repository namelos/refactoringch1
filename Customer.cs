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
            return $@"Rental Record for {Name}
{AllRentalLines}
Amount owed is {TotalAmount}
You earned {FrequentRenterPoints} frequent renter points";
        }

        private string AllRentalLines => _rentals.Aggregate(string.Empty, (acc, r) => $"{acc}\t{r.Movie.Title}\t{r.Charge}\n");
        private int FrequentRenterPoints => _rentals.Sum(rental => rental.FrequentRenterPoints);
        private double TotalAmount => _rentals.Sum(rental => rental.Charge);

        public string Name { get; }
    }
}