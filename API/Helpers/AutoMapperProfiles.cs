using API.DTOs;
using API.Extensions;
using API.Models;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    // implementiert Mapper, um die Eigenschaften der beiden Usertypen (DTO zum anzeigen) auf das andere zu übertragen, um die Eigenschaften nicht einzeln zuweise zu müssen
    public AutoMapperProfiles()
    {
        CreateMap<AppUser, MemberDto>()
        .ForMember(d => d.Age, o => o.MapFrom(s => s.Geburtsdatum.CalculateAge()))
        .ForMember(d => d.FotoURL, o => o.MapFrom(s => s.Fotos.FirstOrDefault(x => x.IsMain)!.Url));
        CreateMap<Foto, FotoDto>();
    }
}