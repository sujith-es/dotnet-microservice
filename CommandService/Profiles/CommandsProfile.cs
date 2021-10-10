namespace CommandService.Profiles
{
    using AutoMapper;
    using CommandService.Dtos;
    using CommandService.Models;

    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source -> Target
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<Command, CommandReadDto>();
            CreateMap<PlatformPublishedDto, Platform>()
            .ForMember(dst => dst.ExternalId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
