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
    public static class AdoptionMapper
    {
        public static Adoption ToEntity(this AdoptionDto dto)
        {
            return new Adoption(dto.Cat.ToEntity(),dto.Adopter.ToEntity(),dto.Date);
        }
        public static AdoptionDto ToDto(this Adoption obj)
        {
            return new AdoptionDto(obj.AdoptionCat.ToDto(),obj.AdoptionAdopter.ToDto(),obj.AdoptionDate);
        }
    }
}
