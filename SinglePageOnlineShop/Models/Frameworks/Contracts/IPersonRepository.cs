using System.Security.Principal;
using OnlineShop.Models.DomainModels;

namespace OnlineShop.Models.Frameworks.Contracts
{
    public interface IPersonRepository
    {
        Task<List<Person>> Select();
        Task Insert(Person person); 
        Task Update(Person person);
        Task Delete(Person person);
        Task<Person?> FindById(Guid id);
        
    }
}
