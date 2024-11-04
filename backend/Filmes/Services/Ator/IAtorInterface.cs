

using Filmes.Dto.Ator;
using Filmes.Models;

namespace Filmes.Services.Ator
{
    public interface IAtorInterface
    {
        Task<ResponseModel<List<AtorModel>>> ListarAtores();
        Task<ResponseModel<AtorModel>> BuscarAtorPorId(int idAtor);
        Task<ResponseModel<AtorModel>> BuscarAtorPorFilme(string filme);
        Task<ResponseModel<List<AtorModel>>> CriarAtor(AtorCriacaoDto atorCriacaoDto);
        Task<ResponseModel<List<AtorModel>>> EditarAtor(AtorEdicaoDto atorEdicaoDto);
        Task<ResponseModel<List<AtorModel>>> ExcluirAtor(int idAtor);

    }
}
