using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public record CatDto(

        string? Name,
        string? Race,
        SexDto? sex,
        string? Description,
        DateOnly? Birth,
        DateOnly ArrivedToCattery,
        DateOnly? LeftCattery,
        string? CatImage,
        string? Cui
        );
}
