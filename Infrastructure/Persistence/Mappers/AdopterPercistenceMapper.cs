using Application.Dto;
using Domain.Model.Entities;
using Domain.Model.ValueObject;
using Infrastructure.Persistence.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Dto;
namespace Infrastructure.Persistence.Mappers
{
    public static class AdopterPercistenceMapper
    {
        public static Adopter ToEntity(this AdopterPercistenceDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            Address address = new Address(dto.Address.Street, dto.Address.City, dto.Address.PoscalCode, dto.Address.Country);   
            //new Address(dto.Address.City,dto.Address.City,dto.Address.PoscalCode,dto.Address.Country),new PhoneNumber(dto.CelNumber.Number),new FiscalCode()
            return new Adopter(dto.Name, dto.Surname,address,new PhoneNumber(dto.CelNumber),new FiscalCode(dto.AdopterFiscalCode),new Email(dto.AdopterEmail));
        }
        public static AdopterPercistenceDto ToDto(this Adopter obj)
        {
            AddressPercistenceDto addressDto = new AddressPercistenceDto(obj.HomeAddress.Street,obj.HomeAddress.City,obj.HomeAddress.PostalCode,obj.HomeAddress.Country);
            return new AdopterPercistenceDto(obj.Name,obj.Surname,addressDto,obj.CelNumber.Number,obj.AdopterFiscalCode.CF,obj.AdopterEmail.Value);
        }
    }
}
