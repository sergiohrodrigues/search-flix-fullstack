

using Filmes.Dto.UserStandard;
using Filmes.Models;

namespace Filmes.Services.UserStardard
{
    public interface IUserStardardInterface
    {
        Task<ResponseModel<UserStandardModel>> CreateUser(UserStandardCriacaoDto userStandardDto);
        Task<ResponseModel<UserStandardModel>> LoginUser(UserStandardLoginDto userStandardDto);
    }
}
