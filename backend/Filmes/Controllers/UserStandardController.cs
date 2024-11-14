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

        [HttpPost("CriarUsuario")]
        public async Task<ActionResult<ResponseModel<UserStandardModel>>> CriarUsuario(UserStandardCriacaoDto userStandardCriacaoDto)
        {
            var user = await _userStandardInterface.CriarUsuario(userStandardCriacaoDto);
            return Ok(user);
        }
    }
}
