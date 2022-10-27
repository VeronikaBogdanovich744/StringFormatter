using StringFormatter;
using StrringFromatterTests.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrringFromatterTests
{

    [TestClass]
    public class BracketsTests
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "Unbalanced brackets")]
        public void NoClosedBracketException()
        {
            var user = new User("Вероника", "Богданович");
            string result;

            result = StringFormatter.StringFormatter.Shared.Format(
                "Привет, {FirstName} {LastName!", user);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Unbalanced brackets")]
        public void UnbalancedBracketsException()
        {
            var user = new User("Вероника", "Богданович");
            string result;

            result = StringFormatter.StringFormatter.Shared.Format(
                "Привет, {{FirstName} {LastName}}", user);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Unbalanced brackets")]
        public void NoOpenedBracketsException()
        {
            var user = new User("Вероника", "Богданович");
            string result;

            result = StringFormatter.StringFormatter.Shared.Format(
                "Привет, FirstName}}} LastName!}", user);
        }


        [TestMethod]
        [ExpectedException(typeof(Exception), "Unbalanced brackets")]
        public void WrongBracketsFormatException()
        {
            var user = new User("Вероника", "Богданович");
            string result;

            result = StringFormatter.StringFormatter.Shared.Format(
                  "{date {{date } date }}", user);

           // Assert.AreEqual("{date} = '14.08.2022 0:00:00'", result);
        }

    }
}
