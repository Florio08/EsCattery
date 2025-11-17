using System;
using Application.Dto;
using Domain.Model.Entities;
using Domain.Model.ValueObject;
using Infrastructure.Persistence.Dto;

namespace Infrastructure.Persistence.Mappers
{
    public static class AdoptionPercistenceMapper
    {
        public static Adoption ToEntity(this AdoptionPercistenceDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            return new Adoption(dto.Cat.ToEntity(), dto.Adopter.ToEntity(), dto.Date);
        }

        public static AdoptionPercistenceDto ToDto(this Adoption obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            return new AdoptionPercistenceDto(obj.AdoptionCat.ToDto(), obj.AdoptionAdopter.ToDto(), obj.AdoptionDate);
        }
    }
}
