using Filmes.Data;
using Filmes.Dto.Ator;
using Filmes.Models;
using Microsoft.AspNetCore.Components.Forms;
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

        public async Task<ResponseModel<AtorModel>> BuscarAtorPorFilme(string filme)
        {
            ResponseModel<AtorModel> resposta = new ResponseModel<AtorModel>();

            try
            {
                var film = await _context.Filmes
                    .Include(a => a.Ator)
                    .FirstOrDefaultAsync(filmeBanco => filmeBanco.Titulo.Contains(filme));

                if (film == null)
                {
                    resposta.Mensagem = "Nenhum registro foi encontrado!";
                    return resposta;
                }

                resposta.Dados = film.Ator;
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

        public async Task<ResponseModel<List<AtorModel>>> CriarAtor(AtorCriacaoDto atorCriacaoDto)
        {
            ResponseModel<List<AtorModel>> resposta = new ResponseModel<List<AtorModel>>();

            try
            {
                if(atorCriacaoDto.Nome == "" || atorCriacaoDto.Sobrenome == "" || atorCriacaoDto.Datanasc == DateTime.MinValue || atorCriacaoDto.Nacionalidade == "")
                {
                    resposta.Mensagem = "Por favor envie todos os dados corretamente";
                    return resposta;
                }

                var ator = new AtorModel()
                {
                    Nome = atorCriacaoDto.Nome,
                    Sobrenome = atorCriacaoDto.Sobrenome,
                    Datanasc = atorCriacaoDto.Datanasc,
                    Nacionalidade = atorCriacaoDto.Nacionalidade
                };

                _context.Add(ator);
                _context.SaveChanges();

                resposta.Dados = await _context.Atores.ToListAsync();
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

        public async Task<ResponseModel<List<AtorModel>>> EditarAtor(AtorEdicaoDto atorEdicaoDto)
        {
            ResponseModel<List<AtorModel>> resposta = new ResponseModel<List<AtorModel>>();

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

                resposta.Dados = await _context.Atores.ToListAsync();
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
