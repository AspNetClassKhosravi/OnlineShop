using OnlineShop.Models.DomainModels;
using SinglePageOnlineShop.ApplocationServices.Dtos;

namespace SinglePageOnlineShop.ApplocationServices.Frameworks.Contracts
{
    public interface IPersonService
    {
        Task PutPerson(PutPersonDto model);
        Task GetPerson(GetPersonDto model);
        Task PostPerson(PostPersonDto model);
        Task DeletePerson(DeletePersonDto model);
        Task<List<GetPersonDto>> GetAllPerson();
    }
}
