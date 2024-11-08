using Filmes.Dto.Ator;
using Filmes.Dto.Filme;
using Filmes.Models;
using Filmes.Services.Ator;
using Filmes.Services.Filme;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Filmes.Enums.EnumCategorias;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Filmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeInterface _filmeInterface;
        public FilmeController(IFilmeInterface filmeInterface)
        {
            _filmeInterface = filmeInterface;
        }

        [HttpGet("ListarFilmes")]
        public async Task<ActionResult<ResponseModel<List<FilmeModel>>>> ListarFilmes()
        {
            var filmes = await _filmeInterface.ListarFilmes();
            return Ok(filmes);
        }

        [HttpGet("BuscarFilmePorAtor")]
        public async Task<ActionResult<ResponseModel<FilmeModel>>> BuscarFilmePorAtor(string nomeFilme)
        {
            var filme = await _filmeInterface.BuscarFilmePorAtor(nomeFilme);
            return Ok(filme);
        }

        [HttpGet("BuscarFilmePorId")]
        public async Task<ActionResult<ResponseModel<FilmeModel>>> BuscarFilmePorId(int idFilme)
        {
            var filme = await _filmeInterface.BuscarFilmePorId(idFilme);
            return Ok(filme);
        }

        [HttpPost("CriarFilme")]
        public async Task<ActionResult<ResponseModel<FilmeModel>>> CriarFilme(FilmeCriacaoDto filmeCriacaoDto)
        {
            var filme = await _filmeInterface.CriarFilme(filmeCriacaoDto);
            return Ok(filme);
        }


        [HttpPut("EditarFilme")]
        public async Task<ActionResult<ResponseModel<FilmeModel>>> EditarFilme(FilmeEditarDto filmeEditarDto)
        {
            var filme = await _filmeInterface.EditarFilme(filmeEditarDto);
            return Ok(filme);
        }

        [HttpDelete("ExcluirFilme")]
        public async Task<ActionResult<ResponseModel<FilmeModel>>> ExcluirFilme(int idFilme)
        {
            var filme = await _filmeInterface.ExcluirFilme(idFilme);
            return Ok(filme);
        }

        [HttpGet("BuscarCategorias")]
        public async Task<ActionResult<IEnumerable<string>>> BuscarCategorias()
        {
            var strings = Enum.GetNames(typeof(Categorias));

            return Ok(strings);
        }


    }
}
