using SeleniumTestTemplate.Models;

namespace SeleniumTestTemplate.TestData
{
    class TestUsers
    {
        public static User GetUserDetails(string user)
        {
            var details = new User();
            switch (user)
            {
                case "user1":
                    {
                        details.Username = "gewone.gebruiker@efocus.nl";
                        details.Password = "Test1234!";
                        details.FirstName = "John";
                        details.LastName = "Travolta";
                        details.PhoneNumber = "0612345678";
                        break;
                    }
                case "admin":
                    {
                        details.Username = "admin.gebruiker@efocus.nl";
                        details.Password = "Test1234!";
                        details.FirstName = "Simone";
                        details.LastName = "van Beek";
                        details.PhoneNumber = "0687654321";

                        break;
                    }
                default:
                    {
                        details = null;
                        break;
                    }
            }
            return details;
        }
    }
}
