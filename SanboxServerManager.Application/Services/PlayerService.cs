using AutoMapper;
using SanboxServerManager.Application.DataTransferObjects;
using SanboxServerManager.Core.Interfaces;

namespace SanboxServerManager.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        public PlayerService(IPlayerRepository playerRepository, IMapper mapper) 
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerDto>> GetAllPlayersAsync()
        {
            var players = await _playerRepository.GetAllPlayersAsync();
            var playersDto = _mapper.Map<IEnumerable<PlayerDto>>(players).ToList();
            return playersDto;
        }        
        
        public async Task<IEnumerable<PlayerDto>> GetAllAdminsAsync()
        {
            var admins = await _playerRepository.GetAllAdminsAsync();
            var adminsDto = _mapper.Map<IEnumerable<PlayerDto>>(admins).ToList();
            return adminsDto;
        }
    }
}
