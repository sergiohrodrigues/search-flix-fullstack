using Filmes.Data;
using Filmes.Dto.Ator;
using Filmes.Models;
using Filmes.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Services.Ator
{
    public class AtorService : IAtorInterface
    {
        private readonly AppDbContext _context;
        public AtorService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<AtorModel>>> ListarAtores()
        {
            ResponseModel<List<AtorModel>> resposta = new ResponseModel<List<AtorModel>>();

            try
            {

                var atores = await _context.Atores.ToListAsync();

                resposta.Dados = atores;
                resposta.Mensagem = "Todos atores foram coletados";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AtorModel>> BuscarAtorPorId(int idAtor)
        {
            ResponseModel<AtorModel> resposta = new ResponseModel<AtorModel>();

            try
            {
                var ator = await _context.Atores.FirstOrDefaultAsync(atorBanco => atorBanco.Id == idAtor);

                if(ator == null)
                {
                    resposta.Mensagem = "Nenhum registro foi encontrado!";
                    return resposta;
                }

                resposta.Dados = ator;
                resposta.Mensagem = "Ator encontrado!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FilmeComAtoresResponse>>> BuscarAtoresPorFilme(string filme)
        {
            ResponseModel<List<FilmeComAtoresResponse>> resposta = new ResponseModel<List<FilmeComAtoresResponse>>();

            try
            {
                var filmes = await _context.Filmes
                    .Include(f => f.AtorFilmes)
                    .ThenInclude(af => af.Ator)
                    .Where(filmeBanco => filmeBanco.Titulo.Contains(filme))
                    .ToListAsync();

                if (!filmes.Any())
                {
                    resposta.Mensagem = "Nenhum filme foi encontrado!";
                    return resposta;
                }

                resposta.Dados = filmes.Select(film => new FilmeComAtoresResponse
                {
                    Id = film.Id,
                    Titulo = film.Titulo,
                    Descricao = film.Descricao,
                    Categoria = film.Categoria,
                    UrlTrailler = film.UrlTrailler,
                    Atores = film.AtorFilmes.Select(af => af.Ator).ToList()
                }).ToList();

                resposta.Mensagem = "Filmes e atores encontrados!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AtorModel>> CriarAtor(AtorCriacaoDto atorCriacaoDto)
        {
            ResponseModel<AtorModel> resposta = new ResponseModel<AtorModel>();

            try
            {
                if(atorCriacaoDto.Nome == "" || atorCriacaoDto.Sobrenome == "" || atorCriacaoDto.Datanasc == DateTime.MinValue || atorCriacaoDto.Nacionalidade == "")
                {
                    resposta.Mensagem = "Por favor envie todos os dados corretamente";
                    return resposta;
                }

                var atorExistente = await _context.Atores.FirstOrDefaultAsync(atorBanco => atorBanco.Nome.ToLower() == atorCriacaoDto.Nome.ToLower());

                if (atorExistente != null)
                {
                    resposta.Mensagem = "Este Ator já existe";
                    return resposta;
                }

                var ator = new AtorModel()
                {
                    Nome = atorCriacaoDto.Nome,
                    Sobrenome = atorCriacaoDto.Sobrenome,
                    Datanasc = atorCriacaoDto.Datanasc,
                    Nacionalidade = atorCriacaoDto.Nacionalidade,
                    urlImage = atorCriacaoDto.urlImage
                };

                _context.Add(ator);
                _context.SaveChanges();

                resposta.Dados = ator;
                resposta.Mensagem = "Ator criado com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AtorModel>> EditarAtor(AtorEdicaoDto atorEdicaoDto)
        {
            ResponseModel<AtorModel> resposta = new ResponseModel<AtorModel>();

            try
            {
                var ator = await _context.Atores.FirstOrDefaultAsync(atorBanco => atorBanco.Id == atorEdicaoDto.Id);

                if (ator == null)
                {
                    resposta.Mensagem = "Nenhum ator encontrado!";
                    return resposta;
                }

                ator.Nome = atorEdicaoDto.Nome;
                ator.Sobrenome = atorEdicaoDto.Sobrenome;

                _context.Update(ator);
                _context.SaveChanges();

                resposta.Dados = ator;
                resposta.Mensagem = "Ator editado com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AtorModel>>> ExcluirAtor(int idAtor)
        {
            ResponseModel<List<AtorModel>> resposta = new ResponseModel<List<AtorModel>>();

            try
            {
                var ator = await _context.Atores.FirstOrDefaultAsync(atorBanco => atorBanco.Id == idAtor);

                if (ator == null)
                {
                    resposta.Mensagem = "Nenhum ator encontrado!";
                    return resposta;
                }

                _context.Remove(ator);
                _context.SaveChanges();

                resposta.Dados = await _context.Atores.ToListAsync();
                resposta.Mensagem = "Ator removido com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
