using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Application.Models;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;

namespace Trevo.API.Application.Implementations
{
    public class CidadeService : ICidadeService
    {
        private readonly IMapper _mapper;
        private readonly ICidadeRepository _cidadeRepository;

        public required string UserLogged { get; set; }

        public CidadeService(IHttpContextAccessor accessor, IMapper mapper, ICidadeRepository CidadeRepository)
        {
            _mapper = mapper;
            _cidadeRepository = CidadeRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(CidadeModel entity)
        {
            Cidade model = _mapper.Map<Cidade>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _cidadeRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            CidadeResultModel model = await GetById(id);

            Cidade entity = _mapper.Map<Cidade>(model);

            await _cidadeRepository.Delete(entity);
        }

        public async Task<List<CidadeResultModel>> GetAll()
        {
            var entities = await _cidadeRepository.GetAll(t => t.Id > 0);

            return _mapper.Map<List<CidadeResultModel>>(entities).OrderBy(x => x.Nome).ToList();
        }

        public async Task<CidadeResultModel> GetById(int id)
        {
            Cidade entity = await _cidadeRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Cidade com [Id = {id}] não encontrada.");
            }

            return _mapper.Map<CidadeResultModel>(entity);
        }

        public async Task Update(int id, CidadeModel entity)
        {
            Cidade existentRecord = _mapper.Map<Cidade>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Nome))
                existentRecord.Nome = entity.Nome;

            if (entity.EstadoId.HasValue && existentRecord.EstadoId != entity.EstadoId)
                existentRecord.EstadoId = entity.EstadoId.Value;

            existentRecord.AtualizadoPor = UserLogged;

            await _cidadeRepository.Update(existentRecord);
        }
    }

}
