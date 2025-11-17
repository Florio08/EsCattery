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
    public static class FiscalCodeMapper
    {
        public static FiscalCode ToEntity(this FiscalCodeDto dto)
        {
            return new FiscalCode(dto.CF);
        }
        public static FiscalCodeDto ToDto(this FiscalCode obj)
        {
            return new FiscalCodeDto(obj.CF);
        }
    }
}
