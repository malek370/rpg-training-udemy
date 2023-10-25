using rpg_training.DTOs.UserDTO;

namespace rpg_training.DBContext
{
    public interface IAuthentification
    {
        public Task<bool> UserExist(string username);
        public Task<ServiceResponse<int>> Register(RegisterUserDTO user);
        public Task<ServiceResponse<string>> Login(LoginUserDTO loginUser);
    }
}
