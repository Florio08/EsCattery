using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record AddressDto(string Street, string City, string PoscalCode, string Country);
}
