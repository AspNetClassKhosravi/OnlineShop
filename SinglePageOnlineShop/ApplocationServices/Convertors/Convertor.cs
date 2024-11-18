using OnlineShop.Models.DomainModels;
using SinglePageOnlineShop.ApplocationServices.Dtos;

namespace SinglePageOnlineShop.ApplicationServices.Convertors
{
    public class Convertor
    {
        
        public static Person DtoConvertor(PostPersonDto dto)
        {
            var model = new Person();

            model.Id = dto.Id;
            model.FirstName=dto.FirstName;
            model.LastName=dto.LastName;
            
            return model;
        }

        public static Person DtoConvertor(PutPersonDto dto)
        {
            var model = new Person();

            model.Id = dto.Id;
            model.FirstName = dto.FirstName;
            model.LastName = dto.LastName;

            return model;
        }

        public static Person DtoConvertor(DeletePersonDto dto)
        {
            var model = new Person();

            model.Id = dto.Id;

            return model;
        }


       

        


       
    }
}
