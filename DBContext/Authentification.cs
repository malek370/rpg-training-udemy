using rpg_training.DTOs.UserDTO;
using System.Security.Cryptography;
using System.Text;

namespace rpg_training.DBContext
{
    public class Authentification : IAuthentification
    {
        private appDBcontext _appDB;

        public Authentification(appDBcontext appDBcontext) 
        {
            _appDB=appDBcontext;
        }
        public async Task<ServiceResponse<string>> Login(LoginUserDTO userlog)
        {
            User? user = await _appDB.users.FirstOrDefaultAsync(u =>
                u.Username!.Equals(userlog.Username));
            if (user == null || !VerifiePassword(userlog.Password,user.HashedPassword,user.SaltPassword))
            { return new ServiceResponse<string>() { Success=false,obj="-1",Message="wrong login informations"}; }
            else { return new ServiceResponse<string>() {Message="user found",obj=user.Id.ToString() }; }
        }

        public async Task<ServiceResponse<int>> Register(RegisterUserDTO user)
        {
            bool testexistance = await UserExist(user.Username);
            if (!testexistance)
            {
                hmacsha512(user.Password, out byte[] hashedPassword, out byte[] saltPassword);
                User res=new User {
                    Username = user.Username,
                    HashedPassword = hashedPassword,
                    SaltPassword = saltPassword
                };
                await _appDB.AddAsync(res);
                await _appDB.SaveChangesAsync();
                return new ServiceResponse<int> {  Message = "user registred successfully",obj = res.Id };

            }
            return new ServiceResponse<int> { Success = false,Message="user exists already", obj=-1};
        }

        public async Task<bool> UserExist(string username)
        {
            return await _appDB.users.AnyAsync(u=>u.Username == username);
        }

        private void hmacsha512(string password, out byte[] hashedPassword, out byte[] saltPassword)
        {
            // Generate a salt
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                saltPassword = hmac.Key;
                hashedPassword = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifiePassword(string password,byte[] hashedPassword,byte[] saltPassword)
        {
            // Generate a salt
            using (var hmac = new HMACSHA512(saltPassword))
            {
                
                var computedhashedPassword = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedhashedPassword.SequenceEqual(hashedPassword);
            }
            
        }

    }
}
