
using OnlineShop.Models.Frameworks.Contracts;
using SinglePageOnlineShop.ApplicationServices.Convertors;
using SinglePageOnlineShop.ApplocationServices.Dtos;
using SinglePageOnlineShop.ApplocationServices.Frameworks.Contracts;
namespace SinglePageOnlineShop.ApplicationServices
{
    public class PersonService:IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository=personRepository;
        }

        public async Task GetPerson(GetPersonDto model)
        {
            await _personRepository.Select();
            
        }
        //Test
        public async Task<List<GetPersonDto>> GetAllPerson()
        {
            var persons = await _personRepository.Select(); 
            return persons.Select(p => new GetPersonDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName
            }).ToList(); // Map to GetPersonDto
        }

        public async Task PostPerson(PostPersonDto model)
        {
            if (string.IsNullOrWhiteSpace(model.FirstName) || string.IsNullOrWhiteSpace(model.LastName))
            {
                throw new ArgumentException("FirstName and LastName cannot be null or empty.");
            }
            await _personRepository.Insert(Convertor.DtoConvertor(model));
            
        }

        public async Task PutPerson(PutPersonDto model)
        {
            if (string.IsNullOrWhiteSpace(model.FirstName) || string.IsNullOrWhiteSpace(model.LastName))
            {
                throw new ArgumentException("FirstName and LastName  cannot be null or empty.");
            }
            await _personRepository.Update(Convertor.DtoConvertor(model));
        }

        public async Task DeletePerson(DeletePersonDto model)
        {
            await _personRepository.Delete(Convertor.DtoConvertor(model));
        }

    }
}
