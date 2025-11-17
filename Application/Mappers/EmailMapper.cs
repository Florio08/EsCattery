using Application.Dto;
using Domain.Model.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class EmailMapper
    {
        public static Email ToEntity(this EmailDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));
            return new Email(dto.Email);
        }

        public static EmailDto ToDto(this Email entity)
        {
            return new EmailDto(entity.Value);
        }
    }
}