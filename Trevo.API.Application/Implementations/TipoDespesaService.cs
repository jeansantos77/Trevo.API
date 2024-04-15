using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Domain.Models;

namespace Trevo.API.Application.Implementations
{
    public class TipoDespesaService : ITipoDespesaService
    {
        private readonly IMapper _mapper;
        private readonly ITipoDespesaRepository _tipoDespesaRepository;

        public required string UserLogged { get; set; }

        public TipoDespesaService(IHttpContextAccessor accessor, IMapper mapper, ITipoDespesaRepository tipoDespesaRepository)
        {
            _mapper = mapper;
            _tipoDespesaRepository = tipoDespesaRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(TipoDespesaModel entity)
        {
            TipoDespesa model = _mapper.Map<TipoDespesa>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _tipoDespesaRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            TipoDespesaResultModel model = await GetById(id);

            TipoDespesa entity = _mapper.Map<TipoDespesa>(model);

            await _tipoDespesaRepository.Delete(entity);
        }

        public async Task<List<TipoDespesaResultModel>> GetAll()
        {
            var entities = await _tipoDespesaRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<TipoDespesaResultModel>>(entities).OrderBy(x => x.Descricao).ToList();
        }

        public async Task<TipoDespesaResultModel> GetById(int id)
        {
            TipoDespesa entity = await _tipoDespesaRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Tipo de Despesa com [Id = {id}] não encontrada.");
            }

            return _mapper.Map<TipoDespesaResultModel>(entity);
        }

        public async Task Update(int id, TipoDespesaModel entity)
        {
            TipoDespesa existentRecord = _mapper.Map<TipoDespesa>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Descricao))
                existentRecord.Descricao = entity.Descricao;

            existentRecord.AtualizadoPor = UserLogged;

            await _tipoDespesaRepository.Update(existentRecord);
        }
    }
}
