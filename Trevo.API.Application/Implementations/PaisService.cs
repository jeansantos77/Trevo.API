using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Application.Models;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;

namespace Trevo.API.Application.Implementations
{
    public class PaisService : IPaisService
    {
        private readonly IMapper _mapper;
        private readonly IPaisRepository _paisRepository;

        public required string UserLogged { get; set; }

        public PaisService(IHttpContextAccessor accessor, IMapper mapper, IPaisRepository PaisRepository)
        {
            _mapper = mapper;
            _paisRepository = PaisRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(PaisModel entity)
        {
            Pais model = _mapper.Map<Pais>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _paisRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            PaisResultModel model = await GetById(id);

            Pais entity = _mapper.Map<Pais>(model);

            await _paisRepository.Delete(entity);
        }

        public async Task<List<PaisResultModel>> GetAll()
        {
            var entities = await _paisRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<PaisResultModel>>(entities).OrderBy(x => x.Nome).ToList();
        }

        public async Task<PaisResultModel> GetById(int id)
        {
            Pais entity = await _paisRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Pais com [Id = {id}] não encontrado.");
            }

            return _mapper.Map<PaisResultModel>(entity);
        }

        public async Task Update(int id, PaisModel entity)
        {
            Pais existentRecord = _mapper.Map<Pais>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Nome))
                existentRecord.Nome = entity.Nome;

            existentRecord.AtualizadoPor = UserLogged;

            await _paisRepository.Update(existentRecord);
        }
    }
}
