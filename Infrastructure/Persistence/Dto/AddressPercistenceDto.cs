using System;

namespace Infrastructure.Persistence.Dto
{
    public record AddressPercistenceDto(string Street, string City, string PoscalCode, string Country);
}