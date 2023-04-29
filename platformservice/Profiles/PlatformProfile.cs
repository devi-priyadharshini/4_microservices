using AutoMapper;

public class PlatformProfile : Profile{

    public PlatformProfile()
    {
        CreateMap<Platform, PlatformReadDto>();
        CreateMap<PlatformCreateDto, Platform>();
    }

} 