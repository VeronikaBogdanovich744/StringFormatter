using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using StringFormatter;

namespace StrringFromatterTests.Classes
{
    class User
    {
        public string FirstName { get; }
        public string LastName { get; }

        private int _id;

        private string str1 = "str2";
        private string str2 = "str";

        private DateTime date;

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            _id = 1;
            date = new DateTime(2022,8,14);
        }

        public string GetGreeting()
        {
            return StringFormatter.StringFormatter.Shared.Format(
                "Привет, {FirstName} {LastName}!", this);
        }
    }
}
