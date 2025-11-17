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
    public static class AddressPercistenceMapper
    {
        //in realtá a quanto pare dovrei rifare i controlli ma onesto stanno giá di sotto, al massimo se proprio vogliamo faccio un try-catch
        public static Address ToEntity(this AddressDto dto)//metodo di estensione di AddressDto
        {
            if(dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            //creo l'address
            return new Address(
                dto.Street,dto.City,dto.PoscalCode,dto.Country
                );
            
        }
        public static AddressDto ToDto(this Address entity)//metodo di estensione di Address
        {
            return new AddressDto(entity.Street, entity.City, entity.PostalCode, entity.Country); ;
        }
    }
}
