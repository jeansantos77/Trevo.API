using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Application.Models;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;

namespace Trevo.API.Application.Implementations
{
    public class CorService : ICorService
    {
        private readonly IMapper _mapper;
        private readonly ICorRepository _corRepository;

        public required string UserLogged { get; set; }

        public CorService(IHttpContextAccessor accessor, IMapper mapper, ICorRepository corRepository)
        {
            _mapper = mapper;
            _corRepository = corRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(CorModel entity)
        {
            Cor model = _mapper.Map<Cor>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _corRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            CorResultModel model = await GetById(id);

            Cor entity = _mapper.Map<Cor>(model);

            await _corRepository.Delete(entity);
        }

        public async Task<List<CorResultModel>> GetAll()
        {
            var entities = await _corRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<CorResultModel>>(entities).OrderBy(x => x.Descricao).ToList();
        }

        public async Task<CorResultModel> GetById(int id)
        {
            Cor entity = await _corRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Cor com [Id = {id}] não encontrada.");
            }

            return _mapper.Map<CorResultModel>(entity);
        }

        public async Task Update(int id, CorModel entity)
        {
            Cor existentRecord = _mapper.Map<Cor>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Descricao))
                existentRecord.Descricao = entity.Descricao;

            existentRecord.AtualizadoPor = UserLogged;

            await _corRepository.Update(existentRecord);
        }
    }
}
