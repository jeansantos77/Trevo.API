using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Domain.Models;

namespace Trevo.API.Application.Implementations
{
    public class CombustivelService : ICombustivelService
    {
        private readonly IMapper _mapper;
        private readonly ICombustivelRepository _combustivelRepository;

        public required string UserLogged { get; set; }

        public CombustivelService(IHttpContextAccessor accessor, IMapper mapper, ICombustivelRepository combustivelRepository)
        {
            _mapper = mapper;
            _combustivelRepository = combustivelRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(CombustivelModel entity)
        {
            Combustivel model = _mapper.Map<Combustivel>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _combustivelRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            CombustivelResultModel model = await GetById(id);

            Combustivel entity = _mapper.Map<Combustivel>(model);

            await _combustivelRepository.Delete(entity);
        }

        public async Task<List<CombustivelResultModel>> GetAll()
        {
            var entities = await _combustivelRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<CombustivelResultModel>>(entities).OrderBy(x => x.Descricao).ToList();
        }

        public async Task<CombustivelResultModel> GetById(int id)
        {
            Combustivel entity = await _combustivelRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Combustivel com [Id = {id}] não encontrado.");
            }

            return _mapper.Map<CombustivelResultModel>(entity);
        }

        public async Task Update(int id, CombustivelModel entity)
        {
            Combustivel existentRecord = _mapper.Map<Combustivel>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Descricao))
                existentRecord.Descricao = entity.Descricao;

            existentRecord.AtualizadoPor = UserLogged;

            await _combustivelRepository.Update(existentRecord);
        }
    }
}
