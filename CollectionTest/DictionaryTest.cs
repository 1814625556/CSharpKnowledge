using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CollectionTest
{
    public class EmployeeIdException : Exception
    {
        public EmployeeIdException(string message) : base(message) { }
    }

    public struct EmployeeId : IEquatable<EmployeeId>
    {
        private readonly char _prefix;
        private readonly int _number;

        public EmployeeId(string id)
        {
            if (id == null) throw new ArgumentNullException(nameof(id));

            _prefix = (id.ToUpper())[0];
            int numLength = id.Length - 1;
            try
            {
                _number = int.Parse(id.Substring(1, numLength > 6 ? 6 : numLength));
            }
            catch (FormatException)
            {
                throw new EmployeeIdException("Invalid EmployeeId format");
            }
        }

        public override string ToString() => _prefix.ToString() + $"{_number,6:000000}";

        public override int GetHashCode() => (_number ^ _number << 16) * 0x15051505;

        public bool Equals(EmployeeId other) => (_prefix == other._prefix && _number == other._number);

        public override bool Equals(object obj) => Equals((EmployeeId)obj);

        public static bool operator ==(EmployeeId left, EmployeeId right) => left.Equals(right);

        public static bool operator !=(EmployeeId left, EmployeeId right) => !(left == right);
    }


    public class Employee
    {
        private string _name;
        private decimal _salary;
        private readonly EmployeeId _id;

        public Employee(EmployeeId id, string name, decimal salary)
        {
            _id = id;
            _name = name;
            _salary = salary;
        }

        public override string ToString() => $"{_id.ToString()}: {_name,-20} {_salary:C}";

    }


    public class DictionaryTest
    {
        public static void Method()
        {
            var idTony = new EmployeeId("C3755");
            var tony = new Employee(idTony, "Tony Stewart", 379025.00m);

            var idCarl = new EmployeeId("F3547");
            var carl = new Employee(idCarl, "Carl Edwards", 403466.00m);

            var idKevin = new EmployeeId("C3386");
            var kevin = new Employee(idKevin, "Kevin Harwick", 415261.00m);

            var idMatt = new EmployeeId("F3323");
            var matt = new Employee(idMatt, "Matt Kenseth", 1589390.00m);

            var idBrad = new EmployeeId("D3234");
            var brad = new Employee(idBrad, "Brad Keselowski", 322295.00m);

            var employees = new Dictionary<EmployeeId, Employee>(31)
            {
                [idTony] = tony,
                [idCarl] = carl,
                [idKevin] = kevin,
                [idMatt] = matt,
                [idBrad] = brad
            };

            //employees.Add(idTony,tony);//不能添加相同的键
            Employee em;
            bool flag = employees.TryGetValue(idTony,out em);

            foreach (var employee in employees.Values)
            {
                WriteLine(employee);
            }

            while (true)
            {
                Write("Enter employee id (X to exit)> ");
                var userInput = ReadLine();
                userInput = userInput.ToUpper();
                if (userInput == "X") break;

                EmployeeId id;
                try
                {
                    id = new EmployeeId(userInput);


                    Employee employee;
                    if (!employees.TryGetValue(id, out employee))
                    {
                        WriteLine("Employee with id {0} does not exist", id);
                    }
                    else
                    {
                        WriteLine(employee);
                    }
                }
                catch (EmployeeIdException ex)
                {
                    WriteLine(ex.Message);
                }
            }
        }
    }
}
