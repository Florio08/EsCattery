using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Infrastructure.Persistence.Dto
{
    public record CatPercistenceDto(

        string? Name,
        string? Race,
        Sex? sex,
        string? Description,
        DateOnly? Birth,
        DateOnly ArrivedToCattery,
        DateOnly? LeftCattery,
        string? CatImage,
        string? Cui
        );
}
