using AutoMapper;
using SanboxServerManager.Application.DataTransferObjects;
using SanboxServerManager.Core.Entities;

namespace SanboxServerManager.WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Player, PlayerDto>()
                .ForMember(dest => dest.Clan, opt => opt.MapFrom(src => src.Clan.ClanName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.PlayerRole.RoleName));
        }
    }
}
