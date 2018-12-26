using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest
{
    public class Racer : IComparable<Racer>, IFormattable
    {
        public Racer(int id, string firstName, string lastName, string country, int wins)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Wins = wins;
        }

        public Racer(int id, string firstName, string lastName, string country)
          : this(id, firstName, lastName, country, wins: 0)
        { }

        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public int Wins { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";


        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null) format = "N";
            switch (format.ToUpper())
            {
                case null:
                case "N": // name
                    return ToString();
                case "F": // first name
                    return FirstName;
                case "L": // last name
                    return LastName;
                case "W": // Wins
                    return $"{ToString()}, Wins: {Wins}";
                case "C": // Country
                    return $"{ToString()}, Country: {Country}";
                case "A": // All
                    return $"{ToString()}, Country: {Country} Wins: {Wins}";
                default:
                    throw new FormatException(String.Format(formatProvider,
                          "Format {0} is not supported", format));
            }
        }

        public string ToString(string format) => ToString(format, null);

        public int CompareTo(Racer other)
        {
            int compare = LastName?.CompareTo(other?.LastName) ?? -1;
            if (compare == 0)
            {
                return FirstName?.CompareTo(other?.FirstName) ?? -1;
            }
            return compare;
        }
    }

    public enum CompareType
    {
        FirstName,
        LastName,
        Country,
        Wins
    }

    public class RacerComparer : IComparer<Racer>
    {
        private CompareType _compareType;
        public RacerComparer(CompareType compareType)
        {
            _compareType = compareType;
        }

        public int Compare(Racer x, Racer y)
        {
            if (x == null && y == null) return 0;// =
            if (x == null) return -1;// <
            if (y == null) return 1;// >

            int result;
            switch (_compareType)
            {
                case CompareType.FirstName:
                    return string.Compare(x.FirstName, y.FirstName);
                case CompareType.LastName:
                    return string.Compare(x.LastName, y.LastName);
                case CompareType.Country:
                    result = string.Compare(x.Country, y.Country);
                    if (result == 0)
                    {
                        return string.Compare(x.LastName, y.LastName);
                    }
                    else
                    {
                        return result;
                    }
                case CompareType.Wins:
                    return x.Wins.CompareTo(y.Wins);
                default:
                    throw new ArgumentException("Invalid Compare Type");
            }
        }
    }
    public class FindCountry
    {
        public FindCountry(string country)
        {
            _country = country;
        }
        private string _country;

        public bool FindCountryPredicate(Racer racer) => racer?.Country == _country;
    }
}
