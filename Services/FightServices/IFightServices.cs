using rpg_training.DTOs.FightDTO;

namespace rpg_training.Services.FightServices
{
    public interface IFightServices
    {
        public Task<ServiceResponse<GetFightRequestDTO>> MakeRequest(MakeFightRequestDTO makerequest);
        public Task<ServiceResponse<List<GetFightRequestDTO>>> GetRequests();
    }
}
