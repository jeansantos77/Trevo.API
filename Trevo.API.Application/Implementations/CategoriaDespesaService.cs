using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Application.Models;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;

namespace Trevo.API.Application.Implementations
{
    public class CategoriaDespesaService : ICategoriaDespesaService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaDespesaRepository _categoriaDespesaRepository;

        public required string UserLogged { get; set; }

        public CategoriaDespesaService(IHttpContextAccessor accessor, IMapper mapper, ICategoriaDespesaRepository categoriaDespesaRepository)
        {
            _mapper = mapper;
            _categoriaDespesaRepository = categoriaDespesaRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(CategoriaDespesaModel entity)
        {
            CategoriaDespesa model = _mapper.Map<CategoriaDespesa>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _categoriaDespesaRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            CategoriaDespesaResultModel model = await GetById(id);

            CategoriaDespesa entity = _mapper.Map<CategoriaDespesa>(model);

            await _categoriaDespesaRepository.Delete(entity);
        }

        public async Task<List<CategoriaDespesaResultModel>> GetAll()
        {
            var entities = await _categoriaDespesaRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<CategoriaDespesaResultModel>>(entities).OrderBy(x => x.Descricao).ToList();
        }

        public async Task<CategoriaDespesaResultModel> GetById(int id)
        {
            CategoriaDespesa entity = await _categoriaDespesaRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Categoria de Despesa com [Id = {id}] não encontrada.");
            }

            return _mapper.Map<CategoriaDespesaResultModel>(entity);
        }

        public async Task Update(int id, CategoriaDespesaModel entity)
        {
            CategoriaDespesa existentRecord = _mapper.Map<CategoriaDespesa>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Descricao))
                existentRecord.Descricao = entity.Descricao;

            existentRecord.AtualizadoPor = UserLogged;

            await _categoriaDespesaRepository.Update(existentRecord);
        }
    }
}
