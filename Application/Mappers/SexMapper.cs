using Application.Dto;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class SexMapper
    {
        public static Sex ToEntity(this SexDto dto )
        {
            if (dto.Sex.ToLower() == "male")
            {
                return Sex.Male;
            }
            return Sex.Female;
        }
        public static SexDto ToDto(this Sex value){
            if (value == Sex.Male)
            {
                return new SexDto("male");
            }
            return new SexDto("female");
        }
    }
}
