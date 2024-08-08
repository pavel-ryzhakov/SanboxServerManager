using AutoMapper;
using MassTransit;
using SanboxServerManager.Application.DataTransferObjects;
using SanboxServerManager.Core.Interfaces;
using SanboxServerManager.SharedModels;

namespace SanboxServerManager.Application.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;
        public PlayerService(IPlayerRepository playerRepository, IMapper mapper, IPublishEndpoint publishEndpoint) 
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<IEnumerable<PlayerDto>> GetAllPlayersAsync()
        {
            var players = await _playerRepository.GetAllPlayersAsync();
            var playersDto = _mapper.Map<IEnumerable<PlayerDto>>(players).ToList();
            await _publishEndpoint.Publish<PlayersReceived>(new
            {
               message = "Вывод всех игроков."
            }); ;
            return playersDto;
            
        }        
        
        public async Task<IEnumerable<PlayerDto>> GetAllAdminsAsync()
        {
            var admins = await _playerRepository.GetAllAdminsAsync();
            var adminsDto = _mapper.Map<IEnumerable<PlayerDto>>(admins).ToList();
            await _publishEndpoint.Publish<PlayersReceived>(new
            {
                message = "Вывод всех админов."
            }); ;
            return adminsDto;
        }
    }
}
