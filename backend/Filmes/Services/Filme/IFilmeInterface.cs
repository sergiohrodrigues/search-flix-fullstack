﻿using Filmes.Dto.Filme;
using Filmes.Models;
using Filmes.Models.Response;

namespace Filmes.Services.Filme
{
    public interface IFilmeInterface
    {
        Task<ResponseModel<List<FilmeModel>>> ListarFilmes();
        Task<ResponseModel<FilmeModel>> BuscarFilmePorId (int idFilme);
        Task<ResponseModel<List<FilmeModel>>> BuscarFilmePorAtor(string Nome);
        Task<ResponseModel<List<FilmeModel>>> CriarFilme(FilmeCriacaoDto filmeCriacaoDto);
        Task<ResponseModel<List<FilmeModel>>> EditarFilme(FilmeEditarDto filmeEditarDto);
        Task<ResponseModel<List<FilmeModel>>> ExcluirFilme (int idFilme);


    }
}
