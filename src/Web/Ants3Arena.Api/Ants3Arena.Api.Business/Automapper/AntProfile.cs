using Ants3Arena.Api.Models.Dtos;
using Ants3Arena.Api.Models.ViewModels;
using AutoMapper;

namespace Ants3Arena.Api.Business.Automapper
{
    public class AntProfile : Profile
    {
        public AntProfile()
        {
            CreateMap<BaseDto, BaseViewModel>().ReverseMap();
            CreateMap<AntDto, AntViewModel>().ReverseMap();
        }
    }
}
