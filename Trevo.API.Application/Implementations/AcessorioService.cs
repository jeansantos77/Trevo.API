using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Domain.Models;

namespace Trevo.API.Application.Implementations
{
    public class AcessorioService : IAcessorioService
    {
        private readonly IMapper _mapper;
        private readonly IAcessorioRepository _acessorioRepository;

        public required string UserLogged { get; set; }

        public AcessorioService(IHttpContextAccessor accessor, IMapper mapper, IAcessorioRepository acessorioRepository)
        {
            _mapper = mapper;
            _acessorioRepository = acessorioRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(AcessorioModel entity)
        {
            Acessorio model = _mapper.Map<Acessorio>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _acessorioRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            AcessorioResultModel model = await GetById(id);

            Acessorio entity = _mapper.Map<Acessorio>(model);

            await _acessorioRepository.Delete(entity);
        }

        public async Task<List<AcessorioResultModel>> GetAll()
        {
            var entities = await _acessorioRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<AcessorioResultModel>>(entities).OrderBy(x => x.Descricao).ToList();
        }

        public async Task<AcessorioResultModel> GetById(int id)
        {
            Acessorio entity = await _acessorioRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Acessorio com [Id = {id}] não encontrado.");
            }

            return _mapper.Map<AcessorioResultModel>(entity);
        }

        public async Task Update(int id, AcessorioModel entity)
        {
            Acessorio existentRecord = _mapper.Map<Acessorio>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Descricao))
                existentRecord.Descricao = entity.Descricao;

            existentRecord.AtualizadoPor = UserLogged;

            await _acessorioRepository.Update(existentRecord);
        }
    }
}
