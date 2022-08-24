using AutoMapper;
using WebApi.HomeTask.Api.Requests;
using WebApi.HomeTask.Api.ViewModels;
using WebApi.HomeTask.Bll.Dto;

namespace WebApi.HomeTask.Api.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ReservationRequest, ReservationDto>()
                .ReverseMap();

        CreateMap<ReservationDto, ReservationViewModel>().ReverseMap();
    }
}