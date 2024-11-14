using Filmes.Dto.UserAdmin;
using Filmes.Models;
using Filmes.Services.UserAdmin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAdminController : ControllerBase
    {

        private readonly IUserAdminInterface _userAdminInterface;
        public UserAdminController(IUserAdminInterface userAdminInterface)
        {
            _userAdminInterface = userAdminInterface;
        }

        [HttpPost("CriarUsuario")]
        public async Task<ActionResult<ResponseModel<UserAdminModel>>> CriarUsuario(UserAdminCriacaoDto userAdminCriacaoDto)
        {
            var user = await _userAdminInterface.CriarUsuario(userAdminCriacaoDto);
            return Ok(user);
        }

        [HttpPost("LogarUsuario")]
        public async Task<ActionResult<ResponseModel<UserAdminModel>>> LogarUsuario(UserAdminLoginDto userAdminLogin)
        {
            var user = await _userAdminInterface.LogarUsuario(userAdminLogin);
            return Ok(user);
        }

    }
}
