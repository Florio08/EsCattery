using Application.Dto;
using Domain.Model.Entities;
using Domain.Model.ValueObject;
using Infrastructure.Persistence.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Mappers
{
    public static class CatPercistenceMapper
    {
        public static Cat ToEntity(this CatPercistenceDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.Name)) throw new ArgumentException("Name is required", nameof(dto.Name));
            if (string.IsNullOrWhiteSpace(dto.Race)) throw new ArgumentException("Race is required", nameof(dto.Race));
            if (dto.sex == null) throw new ArgumentException("Sex is required", nameof(dto.sex));

            return new Cat(
                dto.Name,
                dto.Race,
                dto.sex.Value,
                dto.Description ?? string.Empty,
                dto.Birth,
                dto.ArrivedToCattery,
                dto.LeftCattery,
                dto.CatImage,
                dto.Cui
            );
        }

        public static CatPercistenceDto ToDto(this Cat obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return new CatPercistenceDto(
                obj.Name,
                obj.Race,
                obj.CatSex,
                obj.Description,
                obj.Birth,
                obj.ArrivedToCattery,
                obj.LeftCattery,
                obj.CatImage,
                obj.Cui
            );
        }
    }
}