using Ants3Arena.Api.Models.Dtos;
using Ants3Arena.Api.Models.ViewModels;
using AutoMapper;

namespace Ants3Arena.Api.Business.Automapper
{
    public class AntColorBusinessProfile : Profile
    {
        public AntColorBusinessProfile()
        {
            CreateMap<AntColorViewModel, AntColorDto>().ReverseMap();
        }
    }
}
