using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Application.Models;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;

namespace Trevo.API.Application.Implementations
{
    public class EstadoService : IEstadoService
    {
        private readonly IMapper _mapper;
        private readonly IEstadoRepository _EstadoRepository;

        public required string UserLogged { get; set; }

        public EstadoService(IHttpContextAccessor accessor, IMapper mapper, IEstadoRepository EstadoRepository)
        {
            _mapper = mapper;
            _EstadoRepository = EstadoRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(EstadoModel entity)
        {
            Estado model = _mapper.Map<Estado>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _EstadoRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            EstadoResultModel model = await GetById(id);

            Estado entity = _mapper.Map<Estado>(model);

            await _EstadoRepository.Delete(entity);
        }

        public async Task<List<EstadoResultModel>> GetAll()
        {
            var entities = await _EstadoRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<EstadoResultModel>>(entities).OrderBy(x => x.Nome).ToList();
        }

        public async Task<EstadoResultModel> GetById(int id)
        {
            Estado entity = await _EstadoRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Estado com [Id = {id}] não encontrado.");
            }

            return _mapper.Map<EstadoResultModel>(entity);
        }

        public async Task Update(int id, EstadoModel entity)
        {
            Estado existentRecord = _mapper.Map<Estado>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Nome))
                existentRecord.Nome = entity.Nome;

            if (!string.IsNullOrEmpty(entity.UF))
                existentRecord.UF = entity.UF;

            if (entity.PaisId.HasValue && existentRecord.PaisId != entity.PaisId)
                existentRecord.PaisId = entity.PaisId.Value;

            existentRecord.AtualizadoPor = UserLogged;

            await _EstadoRepository.Update(existentRecord);
        }
    }

}
