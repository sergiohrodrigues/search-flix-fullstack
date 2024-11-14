

using Filmes.Dto.UserStandard;
using Filmes.Models;

namespace Filmes.Services.UserStardard
{
    public interface IUserStardardInterface
    {
        Task<ResponseModel<UserStandardModel>> CriarUsuario(UserStandardCriacaoDto userStandardDto);
    }
}
