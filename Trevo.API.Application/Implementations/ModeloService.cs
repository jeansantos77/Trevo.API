using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Application.Models;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;

namespace Trevo.API.Application.Implementations
{
    public class ModeloService : IModeloService
    {
        private readonly IMapper _mapper;
        private readonly IModeloRepository _modeloRepository;

        public required string UserLogged { get; set; }

        public ModeloService(IHttpContextAccessor accessor, IMapper mapper, IModeloRepository modeloRepository)
        {
            _mapper = mapper;
            _modeloRepository = modeloRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(ModeloModel entity)
        {
            Modelo model = _mapper.Map<Modelo>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _modeloRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            ModeloResultModel model = await GetById(id);

            Modelo entity = _mapper.Map<Modelo>(model);

            await _modeloRepository.Delete(entity);
        }

        public async Task<List<ModeloResultModel>> GetAll()
        {
            var entities = await _modeloRepository.GetAll(t => t.Id > 0);

            return _mapper.Map<List<ModeloResultModel>>(entities).OrderBy(x => x.Descricao).ToList();
        }

        public async Task<ModeloResultModel> GetById(int id)
        {
            Modelo entity = await _modeloRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Modelo com [Id = {id}] não encontrado.");
            }

            return _mapper.Map<ModeloResultModel>(entity);
        }

        public async Task Update(int id, ModeloModel entity)
        {
            Modelo existentRecord = _mapper.Map<Modelo>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Descricao))
                existentRecord.Descricao = entity.Descricao;

            if (entity.MarcaId.HasValue && existentRecord.MarcaId != entity.MarcaId)
                existentRecord.MarcaId = entity.MarcaId.Value;

            existentRecord.AtualizadoPor = UserLogged;

            await _modeloRepository.Update(existentRecord);
        }
    }

}
