using OnlineShop.Models.Frameworks.Contracts;

namespace OnlineShop.Models.DomainModels
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
