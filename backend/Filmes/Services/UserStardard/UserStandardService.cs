﻿using Filmes.Data;
using Filmes.Dto.UserStandard;
using Filmes.Models;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Services.UserStardard
{
    public class UserStandardService : IUserStardardInterface
    {
        private readonly AppDbContext _context;
        public UserStandardService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<UserStandardModel>> CriarUsuario(UserStandardCriacaoDto userStandardDto)
        {
            ResponseModel<UserStandardModel> resposta = new ResponseModel<UserStandardModel>();
            try
            {

                if (userStandardDto.User == "" || userStandardDto.Password == "" || userStandardDto.Email == "")
                {
                    resposta.Mensagem = "Por favor envie todos os dados corretamente";
                    return resposta;
                }

                var usuarioExistente = await _context.UserStandard.FirstOrDefaultAsync(userBanco => userBanco.User.ToLower() == userStandardDto.User.ToLower());

                if (usuarioExistente != null)
                {
                    resposta.Mensagem = "Usuário já cadastrado";
                    return resposta;
                }

                var user = new UserStandardModel()
                {
                    User = userStandardDto.User,
                    Password = userStandardDto.Password,
                    Email = userStandardDto.Email,
                };

                _context.Add(user);
                _context.SaveChanges();

                resposta.Dados = user;
                resposta.Mensagem = "Usuário cadastrado com sucesso!";

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