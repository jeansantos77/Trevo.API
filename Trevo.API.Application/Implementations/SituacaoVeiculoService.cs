using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Application.Models;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;

namespace Trevo.API.Application.Implementations
{
    public class SituacaoVeiculoService : ISituacaoVeiculoService
    {
        private readonly IMapper _mapper;
        private readonly ISituacaoVeiculoRepository _situacaoVeiculoRepository;

        public required string UserLogged { get; set; }

        public SituacaoVeiculoService(IHttpContextAccessor accessor, IMapper mapper, ISituacaoVeiculoRepository situacaoVeiculoRepository)
        {
            _mapper = mapper;
            _situacaoVeiculoRepository = situacaoVeiculoRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(SituacaoVeiculoModel entity)
        {
            SituacaoVeiculo model = _mapper.Map<SituacaoVeiculo>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _situacaoVeiculoRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            SituacaoVeiculoResultModel model = await GetById(id);

            SituacaoVeiculo entity = _mapper.Map<SituacaoVeiculo>(model);

            await _situacaoVeiculoRepository.Delete(entity);
        }

        public async Task<List<SituacaoVeiculoResultModel>> GetAll()
        {
            var entities = await _situacaoVeiculoRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<SituacaoVeiculoResultModel>>(entities).OrderBy(x => x.Descricao).ToList();
        }

        public async Task<SituacaoVeiculoResultModel> GetById(int id)
        {
            SituacaoVeiculo entity = await _situacaoVeiculoRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Situacao Veículo com [Id = {id}] não encontrada.");
            }

            return _mapper.Map<SituacaoVeiculoResultModel>(entity);
        }

        public async Task Update(int id, SituacaoVeiculoModel entity)
        {
            SituacaoVeiculo existentReSituacaoVeiculod = _mapper.Map<SituacaoVeiculo>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Descricao))
                existentReSituacaoVeiculod.Descricao = entity.Descricao;

            existentReSituacaoVeiculod.AtualizadoPor = UserLogged;

            await _situacaoVeiculoRepository.Update(existentReSituacaoVeiculod);
        }
    }
}
