using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Domain.Models;

namespace Trevo.API.Application.Implementations
{
    public class EstadoService : IEstadoService
    {
        private readonly IMapper _mapper;
        private readonly IEstadoRepository _estadoRepository;

        public required string UserLogged { get; set; }

        public EstadoService(IHttpContextAccessor accessor, IMapper mapper, IEstadoRepository EstadoRepository)
        {
            _mapper = mapper;
            _estadoRepository = EstadoRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(EstadoModel entity)
        {
            Estado model = _mapper.Map<Estado>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _estadoRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            EstadoResultModel model = await GetById(id);

            Estado entity = _mapper.Map<Estado>(model);

            await _estadoRepository.Delete(entity);
        }

        public async Task<List<EstadoResultModel>> GetAll()
        {
            //var entities = await _estadoRepository.GetAll(t => t.Id > 0);
            var entities = await _estadoRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<EstadoResultModel>>(entities).OrderBy(x => x.Nome).ToList();
        }

        public async Task<EstadoResultModel> GetById(int id)
        {
            Estado entity = await _estadoRepository.GetById(x => x.Id == id);

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

            await _estadoRepository.Update(existentRecord);
        }
    }

}
