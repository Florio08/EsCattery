
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Dto;

namespace Infrastructure.Persistence.Dto
{
    public record AdopterPercistenceDto(string Name, string Surname, AddressPercistenceDto Address, string CelNumber, string AdopterFiscalCode, string AdopterEmail);
}
