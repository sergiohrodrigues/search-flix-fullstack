using Filmes.Dto.UserStandard;
using Filmes.Models;
using Filmes.Services.UserStardard;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStandardController : ControllerBase
    {
        private readonly IUserStardardInterface _userStandardInterface;
        public UserStandardController(IUserStardardInterface userStandardInterface)
        {
            _userStandardInterface = userStandardInterface;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<ResponseModel<UserStandardModel>>> CreateUser(UserStandardCriacaoDto userStandardCriacaoDto)
        {
            var user = await _userStandardInterface.CreateUser(userStandardCriacaoDto);
            return Ok(user);
        }
        
        [HttpPost("LoginUser")]
        public async Task<ActionResult<ResponseModel<UserStandardModel>>> LoginUser(UserStandardLoginDto userStandardLoginDto)
        {
            var user = await _userStandardInterface.LoginUser(userStandardLoginDto);
            return Ok(user);
        }
    }
}
