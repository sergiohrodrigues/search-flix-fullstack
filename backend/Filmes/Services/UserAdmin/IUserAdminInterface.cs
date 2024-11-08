using Filmes.Dto.UserAdmin;
using Filmes.Models;

namespace Filmes.Services.UserAdmin
{
    public interface IUserAdminInterface
    {
        Task<ResponseModel<UserAdminModel>> CriarUsuario(UserAdminCriacaoDto userAdminDto);
        Task<ResponseModel<UserAdminModel>> LogarUsuario(UserAdminLoginDto userAdminDto);

    }
}
