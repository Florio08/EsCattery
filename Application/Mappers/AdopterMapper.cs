using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Domain.Model.Entities;
using Domain.Model.ValueObject;
namespace Application.Mappers
{
    public static class AdopterMapper
    {
        public static Adopter ToEntity(this AdopterDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            //new Address(dto.Address.City,dto.Address.City,dto.Address.PoscalCode,dto.Address.Country),new PhoneNumber(dto.CelNumber.Number),new FiscalCode()
            return new Adopter(dto.Name, dto.Surname,dto.Address.ToEntity(),dto.CelNumber.ToEntity(),dto.AdopterFiscalCode.ToEntity(),dto.AdopterEmail.ToEntity());
        }
        public static AdopterDto ToDto(this Adopter obj)
        {
            return new AdopterDto(obj.Name,obj.Surname,obj.HomeAddress.ToDto(),obj.CelNumber.ToDto(),obj.AdopterFiscalCode.ToDto(),obj.AdopterEmail.ToDto());
        }
    }
}
