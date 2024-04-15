using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Domain.Models;

namespace Trevo.API.Application.Implementations
{
    public class CambioService : ICambioService
    {
        private readonly IMapper _mapper;
        private readonly ICambioRepository _CambioRepository;

        public required string UserLogged { get; set; }

        public CambioService(IHttpContextAccessor accessor, IMapper mapper, ICambioRepository CambioRepository)
        {
            _mapper = mapper;
            _CambioRepository = CambioRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(CambioModel entity)
        {
            Cambio model = _mapper.Map<Cambio>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _CambioRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            CambioResultModel model = await GetById(id);

            Cambio entity = _mapper.Map<Cambio>(model);

            await _CambioRepository.Delete(entity);
        }

        public async Task<List<CambioResultModel>> GetAll()
        {
            var entities = await _CambioRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<CambioResultModel>>(entities).OrderBy(x => x.Descricao).ToList();
        }

        public async Task<CambioResultModel> GetById(int id)
        {
            Cambio entity = await _CambioRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Cambio com [Id = {id}] não encontrado.");
            }

            return _mapper.Map<CambioResultModel>(entity);
        }

        public async Task Update(int id, CambioModel entity)
        {
            Cambio existentRecord = _mapper.Map<Cambio>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Descricao))
                existentRecord.Descricao = entity.Descricao;

            existentRecord.AtualizadoPor = UserLogged;

            await _CambioRepository.Update(existentRecord);
        }
    }
}
