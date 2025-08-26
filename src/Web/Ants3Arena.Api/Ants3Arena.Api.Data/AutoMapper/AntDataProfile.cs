using Ants3Arena.Api.Data.Entities;
using Ants3Arena.Api.Models.Dtos;
using AutoMapper;

namespace Ants3Arena.Api.Data.AutoMapper
{
    public class AntDataProfile : Profile
    {
        public AntDataProfile()
        {
            CreateMap<AntDto, Ant>().ReverseMap();
        }
    }
}
