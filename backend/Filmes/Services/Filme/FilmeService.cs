using Filmes.Data;
using Filmes.Dto.Filme;
using Filmes.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Services.Filme
{
    public class FilmeService : IFilmeInterface
    {
        private readonly AppDbContext _context;
        public FilmeService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<FilmeModel>>> listarFilmes()
        {
            ResponseModel<List<FilmeModel>> resposta = new ResponseModel<List<FilmeModel>>();

            try
            {
                var filmes = await _context.Filmes.Include(a => a.Ator).ToListAsync();
                resposta.Dados = filmes;
                resposta.Mensagem = "Todos filmes foram coletados!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<List<FilmeModel>>> BuscarFilmePorAtor(string Nome)
        {
            ResponseModel<List<FilmeModel>> resposta = new ResponseModel<List<FilmeModel>>();

            try
            {

                var filme = await _context.Filmes
                    .Include(a => a.Ator)
                    .Where(f => f.Ator.Nome.Contains(Nome))
                    .ToListAsync();

                Console.WriteLine("teste");
                Console.WriteLine(filme);

                if (filme == null)
                {
                    resposta.Mensagem = "Nenhum ator foi encontrado";
                    return resposta;
                }

                resposta.Dados = filme;
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

        public async Task<ResponseModel<FilmeModel>> BuscarFilmePorId(int idFilme)
        {
            ResponseModel<FilmeModel> resposta = new ResponseModel<FilmeModel>();

            try
            {

                var filme = await _context.Filmes
                    .Include(a => a.Ator)
                    .FirstOrDefaultAsync(filmeBanco => filmeBanco.Id == idFilme);

                if (filme == null)
                {
                    resposta.Mensagem = "Filme nao encontrado!";
                    return resposta;
                }

                resposta.Dados = filme;
                resposta.Mensagem = "Filme encontrado com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FilmeModel>>> CriarFilme(FilmeCriacaoDto filmeCriacaoDto)
        {
            ResponseModel<List<FilmeModel>> resposta = new ResponseModel<List<FilmeModel>>();

            try
            {
                var ator = await _context.Atores.FirstOrDefaultAsync(a => a.Id == filmeCriacaoDto.Ator.Id);

                if (ator == null)
                {
                    resposta.Mensagem = "Nenhum registro de ator encontrado";
                    return resposta;
                }

                var filme = new FilmeModel()
                {
                    Titulo = filmeCriacaoDto.Titulo,
                    Descricao = filmeCriacaoDto.Descricao,
                    Ator = ator
                };

                _context.Add(filme);
                _context.SaveChanges();

                resposta.Dados = await _context.Filmes.Include(a => a.Ator).ToListAsync();
                resposta.Mensagem = "Filme criado com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FilmeModel>>> EditarFilme(FilmeEditarDto filmeEditarDto)
        {
            ResponseModel<List<FilmeModel>> resposta = new ResponseModel<List<FilmeModel>>();

            try
            {
                var filme = await _context.Filmes
                    .Include(a => a.Ator)
                    .FirstOrDefaultAsync(filmeBanco => filmeBanco.Id == filmeEditarDto.Id);

                var ator = await _context.Atores
                    .FirstOrDefaultAsync(filme => filme.Id == filmeEditarDto.Ator.Id);

                if (filme == null)
                {
                    resposta.Mensagem = "Nenhum registro de filme localizado!";
                    return resposta;
                }
                
                if (ator == null)
                {
                    resposta.Mensagem = "Nenhum registro de ator localizado!";
                    return resposta;
                }

                filme.Titulo = filmeEditarDto.Titulo;
                filme.Descricao = filmeEditarDto.Descricao;
                filme.Ator = ator;

                _context.Update(filme);
                _context.SaveChanges();

                resposta.Dados = await _context.Filmes.Include(a => a.Ator).ToListAsync();
                resposta.Mensagem = "Filme editado com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<FilmeModel>>> ExcluirFilme(int idFilme)
        {
            ResponseModel<List<FilmeModel>> resposta = new ResponseModel<List<FilmeModel>>();

            try
            {
                var filme = await _context.Filmes.FirstOrDefaultAsync(filmeBanco => filmeBanco.Id == idFilme);

                if (filme == null)
                {
                    resposta.Mensagem = "Filme não encontrado!";
                    return resposta;
                }

                _context.Remove(filme);
                _context.SaveChanges();

                resposta.Dados = await _context.Filmes.Include(a => a.Ator).ToListAsync();
                resposta.Mensagem = "Filme editado com sucesso!";

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
