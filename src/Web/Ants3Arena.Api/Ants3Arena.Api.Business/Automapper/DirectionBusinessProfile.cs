using Ants3Arena.Api.Models.Dtos;
using Ants3Arena.Api.Models.ViewModels;
using AutoMapper;

namespace Ants3Arena.Api.Business.Automapper
{
    public class DirectionBusinessProfile : Profile
    {
        public DirectionBusinessProfile()
        {
            CreateMap<DirectionViewModel, DirectionDto>().ReverseMap();
        }
    }
}
