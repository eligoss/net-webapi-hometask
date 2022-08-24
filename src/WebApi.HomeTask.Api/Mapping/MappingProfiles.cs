using AutoMapper;
using WebApi.HomeTask.Api.Requests;
using WebApi.HomeTask.Api.ViewModels;
using WebApi.HomeTask.Bll.Dto;

namespace WebApi.HomeTask.Api.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ReservationRequest, ReservationRequestDto>()
            .ForMember(dest => dest.NumberOfPeople, opt => opt.MapFrom(src => src.NumPeople));

        CreateMap<ReservationResponseDto, ReservationViewModel>().ReverseMap();
    }
}