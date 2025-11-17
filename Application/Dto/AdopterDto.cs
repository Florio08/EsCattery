using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record AdopterDto(string Name, string Surname, AddressDto Address,PhoneNumberDto CelNumber, FiscalCodeDto AdopterFiscalCode, EmailDto AdopterEmail);
}
