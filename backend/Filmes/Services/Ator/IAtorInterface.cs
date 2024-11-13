

using Filmes.Dto.Ator;
using Filmes.Models;
using Filmes.Models.Response;

namespace Filmes.Services.Ator
{
    public interface IAtorInterface
    {
        Task<ResponseModel<List<AtorModel>>> ListarAtores();
        Task<ResponseModel<AtorModel>> BuscarAtorPorId(int idAtor);
        Task<ResponseModel<List<FilmeComAtoresResponse>>> BuscarAtoresPorFilme(string filme);
        Task<ResponseModel<AtorModel>> CriarAtor(AtorCriacaoDto atorCriacaoDto);
        Task<ResponseModel<AtorModel>> EditarAtor(AtorEdicaoDto atorEdicaoDto);
        Task<ResponseModel<List<AtorModel>>> ExcluirAtor(int idAtor);

    }
}
