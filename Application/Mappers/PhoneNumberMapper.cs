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
    public static class PhoneNumberMapper
    {
        public static PhoneNumber ToEntity(this PhoneNumberDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            return new PhoneNumber(dto.Number);
        }
        public static PhoneNumberDto ToDto(this PhoneNumber obj)
        {
            return new PhoneNumberDto(obj.Number);
        }
    }
}
