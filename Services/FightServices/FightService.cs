using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using rpg_training.DBContext;
using rpg_training.DTOs.FightDTO;
using System.Security.Claims;

namespace rpg_training.Services.FightServices
{
    public class FightService : IFightServices
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly appDBcontext _dBcontext;

        public FightService(IHttpContextAccessor httpContext,appDBcontext appDBcontext) 
        {
            _dBcontext = appDBcontext;
            _httpContext = httpContext;
        }
        private int getUserId() => int.Parse(_httpContext.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        public async Task<ServiceResponse<GetFightRequestDTO>> MakeRequest(MakeFightRequestDTO makerequest)
        {
            var request=new ServiceResponse<GetFightRequestDTO>();
            try
            {

                //verify if reciever exist
                var reciever = await _dBcontext.users.FirstOrDefaultAsync(u => u.Id == makerequest.ReceiverId);
                if(reciever == null) { throw new Exception("opponent does not exist"); }
                //get character
                var character=await _dBcontext.characters
                    .Include(c=>c.User)
                    .FirstOrDefaultAsync(c=>c.id==makerequest.charachterId && c.User.Id==getUserId());
                if (character == null) { throw new Exception("character does not exist"); }
                request.obj = new GetFightRequestDTO();
                request.obj.SenderName = character.User.Username!;
                request.obj.RecieverName = reciever.Username;
                request.obj.characterName = character.Name;
                await _dBcontext.fightRequests.AddAsync(new FightRequest
                {
                    charachterId=character.id,
                    SenderId=character.User.Id,
                    ReceiverId=reciever.Id

                });
                await _dBcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                request.obj = null;
                request.Success = false;
                request.Message = ex.Message;

            }
            return request;
            
        }

        public async Task<ServiceResponse<List<GetFightRequestDTO>>> GetRequests()
        {
            var response=new ServiceResponse<List<GetFightRequestDTO>>();
            try
            {
                var requests=await _dBcontext.fightRequests.Where(r=>r.ReceiverId==getUserId()).ToListAsync();
                List<GetFightRequestDTO> res=new List<GetFightRequestDTO>();
                foreach (var request in requests)
                {

                    var RecieverName = await _dBcontext.users.FirstOrDefaultAsync(u => u.Id == request.ReceiverId);
                    var SenderName =await  _dBcontext.users.FirstOrDefaultAsync(u => u.Id == request.SenderId);
                    var characterName = await _dBcontext.characters.FirstOrDefaultAsync(u => u.id == request.charachterId);
                    res.Add(new GetFightRequestDTO
                    {
                        Id=request.Id,
                        SenderName=SenderName.Username,
                        RecieverName=RecieverName.Username,
                        characterName=characterName.Name
                        
                    });
                }
                response.obj = res;

            }
            catch (Exception ex)
            {
                response.obj = null;
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
