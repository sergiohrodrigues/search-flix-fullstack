using Filmes.Data;
using Filmes.Dto.Ator;
using Filmes.Dto.UserAdmin;
using Filmes.Models;
using Filmes.Services.UserAdmin;
using Microsoft.EntityFrameworkCore;

public class UserAdminService : IUserAdminInterface
    {
            private readonly AppDbContext _context;
            public UserAdminService(AppDbContext context)
            {
                _context = context;
            }

        public async Task<ResponseModel<UserAdminModel>> CriarUsuario(UserAdminCriacaoDto userAdminDto)
        {
            ResponseModel<UserAdminModel> resposta = new ResponseModel<UserAdminModel>();
        try
        {

            if (userAdminDto.User == "" || userAdminDto.Password == "" || userAdminDto.Email == "")
            {
                resposta.Mensagem = "Por favor envie todos os dados corretamente";
                return resposta;
            }

            var usuarioExistente = await _context.UserAdmin.FirstOrDefaultAsync(userBanco => userBanco.User.ToLower() == userAdminDto.User.ToLower());

            if (usuarioExistente == null)
            {
                resposta.Mensagem = "Usuário já cadastrado!";
                return resposta;
            }

            var user = new UserAdminModel()
            {
                User = userAdminDto.User,
                Password = userAdminDto.Password,
                Email = userAdminDto.Email,
                Datanasc = userAdminDto.DataNasc
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

        public async Task<ResponseModel<UserAdminModel>> LogarUsuario(UserAdminLoginDto userAdminDto)
        {
            ResponseModel<UserAdminModel> resposta = new ResponseModel<UserAdminModel>();
            try
            {


                var user = await _context.UserAdmin.FirstOrDefaultAsync(userBanco => userBanco.User == userAdminDto.User && userBanco.Password == userAdminDto.Password);

                if (user == null)
                {
                    resposta.Mensagem = "Usuario não encontrado!";
                    return resposta;
                }

                resposta.Dados = user;
                resposta.Mensagem = "Usuário encontrado!";

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