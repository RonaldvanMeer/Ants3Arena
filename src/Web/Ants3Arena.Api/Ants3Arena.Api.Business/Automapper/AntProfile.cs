using Ants3Arena.Api.Models.Dtos;
using Ants3Arena.Api.Models.ViewModels;
using AutoMapper;

namespace Ants3Arena.Api.Business.Automapper
{
    public class AntProfile : Profile
    {
        public AntProfile()
        {
            CreateMap<AntDto, AntViewModel>().ReverseMap();

            CreateMap<CreateAntViewModel, AntDto>()
                .ForMember(d => d.Color, o => o.MapFrom(s => new AntColorDto { Id = s.ColorId }))
                .ForMember(d => d.Direction, o => o.MapFrom(s => new DirectionDto { Id = s.DirectionId }));
        }
    }
}
