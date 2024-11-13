using Filmes.Dto.Ator;
using Filmes.Models;
using Filmes.Services.Ator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtorController : ControllerBase
    {
        private readonly IAtorInterface _atorInterface;
        public AtorController(IAtorInterface atorInterface)
        {
            _atorInterface = atorInterface;
        }

        [HttpGet("ListarAtores")]
        public async Task<ActionResult<ResponseModel<List<AtorModel>>>> ListarAtores()
        {
            var atores = await _atorInterface.ListarAtores();
            return Ok(atores);
        }
        
        [HttpGet("BuscarAtorPorId")]
        public async Task<ActionResult<ResponseModel<AtorModel>>> BuscarAtorPorId(int idAtor)
        {
            var ator = await _atorInterface.BuscarAtorPorId(idAtor);
            return Ok(ator);
        }
        
        [HttpGet("BuscarAtoresPorFilme")]
        public async Task<ActionResult<ResponseModel<AtorModel>>> BuscarAtoresPorFilme(string filme)
        {
            var ator = await _atorInterface.BuscarAtoresPorFilme(filme);
            return Ok(ator);
        }
        
        [HttpPost("CriarAtor")]
        public async Task<ActionResult<ResponseModel<AtorModel>>> CriarAtor(AtorCriacaoDto atorCriacaoDto)
        {
            //passar filme tbm para ja fazer vinculação
            var ator = await _atorInterface.CriarAtor(atorCriacaoDto);
            return Ok(ator);
        }
        
        [HttpPut("EditarAtor")]
        public async Task<ActionResult<ResponseModel<AtorModel>>> EditarAtor(AtorEdicaoDto atorEdicaoDto)
        {
            var ator = await _atorInterface.EditarAtor(atorEdicaoDto);
            return Ok(ator);
        }
        
        [HttpDelete("ExcluirAtor")]
        public async Task<ActionResult<ResponseModel<AtorModel>>> ExcluirAtor(int idAtor)
        {
            var ator = await _atorInterface.ExcluirAtor(idAtor);
            return Ok(ator);
        }


    }
}
