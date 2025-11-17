using Application.Dto;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Dto;
namespace Infrastructure.Persistence.Mappers
{
    public static class SexMapper
    {
        public static Sex ToEntity(this SexPercistenceDto dto)
        {
            if (dto.Sex == 0)
            {
                return Sex.Male;
            }
            return Sex.Female;
        }
        public static SexPercistenceDto ToDto(this Sex value)
        {
            if (value == Sex.Male)
            {
                return new SexPercistenceDto(0);
            }
            return new SexPercistenceDto(1);
        }
    }
}
