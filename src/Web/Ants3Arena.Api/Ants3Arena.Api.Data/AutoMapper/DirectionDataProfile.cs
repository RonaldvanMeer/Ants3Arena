using Ants3Arena.Api.Data.Entities;
using Ants3Arena.Api.Models.Dtos;
using AutoMapper;

namespace Ants3Arena.Api.Data.AutoMapper
{
    public class DirectionDataProfile : Profile
    {
        public DirectionDataProfile()
        {
            CreateMap<Direction, DirectionDto>().ReverseMap();
        }
    }
}
