using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Domain.Models;

namespace Trevo.API.Application.Implementations
{
    public class MarcaService : IMarcaService
    {
        private readonly IMapper _mapper;
        private readonly IMarcaRepository _marcaRepository;

        public required string UserLogged { get; set; }

        public MarcaService(IHttpContextAccessor accessor, IMapper mapper, IMarcaRepository marcaRepository)
        {
            _mapper = mapper;
            _marcaRepository = marcaRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(MarcaModel entity)
        {
            Marca model = _mapper.Map<Marca>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _marcaRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            MarcaResultModel model = await GetById(id);

            Marca entity = _mapper.Map<Marca>(model);

            await _marcaRepository.Delete(entity);
        }

        public async Task<List<MarcaResultModel>> GetAll()
        {
            var entities = await _marcaRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<MarcaResultModel>>(entities).OrderBy(x => x.Descricao).ToList();
        }

        public async Task<MarcaResultModel> GetById(int id)
        {
            Marca entity = await _marcaRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Marca com [Id = {id}] não encontrada.");
            }

            return _mapper.Map<MarcaResultModel>(entity);
        }

        public async Task Update(int id, MarcaModel entity)
        {
            Marca existentRecord = _mapper.Map<Marca>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Descricao))
                existentRecord.Descricao = entity.Descricao;

            existentRecord.AtualizadoPor = UserLogged;

            await _marcaRepository.Update(existentRecord);
        }
    }
}
