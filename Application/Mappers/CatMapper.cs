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
    public static class CatMapper
    {
        public static Cat ToEntity (this CatDto dto)
        {
            return new Cat(dto.Name,dto.Race,dto.sex.ToEntity(),dto.Description,dto.Birth,dto.ArrivedToCattery,dto.LeftCattery,dto.CatImage);
        }
        public static CatDto ToDto(this Cat obj)
        {
            return new CatDto(obj.Name, obj.Race,obj.CatSex.ToDto(),obj.Description,obj.Birth,obj.ArrivedToCattery,obj.LeftCattery,obj.CatImage,obj.Cui);
        }

    }
}
