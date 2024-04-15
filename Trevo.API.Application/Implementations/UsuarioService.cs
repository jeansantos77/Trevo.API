using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Domain.Models;

namespace Trevo.API.Application.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public required string UserLogged { get; set; }

        public UsuarioService(IHttpContextAccessor accessor, IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(UsuarioModel entity)
        {
            Usuario model = _mapper.Map<Usuario>(entity);

            model.Senha = CryptographyService.CryptPassword(model.Senha);
            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            ValidateProfile(entity);

            await _usuarioRepository.Add(model);
        }

        private static void ValidateProfile(UsuarioModel entity)
        {
            if (entity.Perfil == 0)
            {
                throw new Exception($"Perfil deve ser 1 (Administrador) ou 2 (Usuario).");
            }
        }

        public async Task Delete(int id)
        {
            UsuarioResultModel model = await GetById(id);

            Usuario entity = _mapper.Map<Usuario>(model);

            await _usuarioRepository.Delete(entity);
        }

        public async Task<List<UsuarioResultModel>> GetAll()
        {
            var entities = await _usuarioRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<UsuarioResultModel>>(entities).OrderBy(x => x.Nome).ToList();
        }

        public async Task<UsuarioResultModel> GetById(int id)
        {
            Usuario entity = await _usuarioRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Usuario com [Id = {id}] não encontrado.");
            }

            return _mapper.Map<UsuarioResultModel>(entity);
        }

        public async Task Update(int id, UsuarioModel entity)
        {
            Usuario existentRecord = _mapper.Map<Usuario>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Nome))
                existentRecord.Nome = entity.Nome;

            if (!string.IsNullOrEmpty(entity.Email))
                existentRecord.Email = entity.Email;

            if (!string.IsNullOrEmpty(entity.Login))
                existentRecord.Login = entity.Login;

            if (!string.IsNullOrEmpty(entity.Senha))
            {
                if (existentRecord.Senha != entity.Senha)
                {
                    existentRecord.Senha = CryptographyService.CryptPassword(entity.Senha);
                }
            }

            if (entity.Perfil != null)
            {
                ValidateProfile(entity);
                existentRecord.Perfil = entity.Perfil.Value;
            }

            if (entity.Ativo != null)
                existentRecord.Ativo = entity.Ativo.Value;

            existentRecord.AtualizadoPor = UserLogged;

            await _usuarioRepository.Update(existentRecord);
        }

        public async Task<UsuarioResultModel> GetByLogin(LoginModel model)
        {
            string cryptoSenha = CryptographyService.CryptPassword(model.Password);

            var entities = await _usuarioRepository.GetAll(t => t.Login == model.Login && t.Senha == cryptoSenha);

            if (entities.Count == 0)
            {
                throw new Exception($"Login ou senha inválidos.");
            }

            return _mapper.Map<UsuarioResultModel>(entities.FirstOrDefault());
        }
    }

}
