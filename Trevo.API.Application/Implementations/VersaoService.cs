using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Domain.Models;

namespace Trevo.API.Application.Implementations
{
    public class VersaoService : IVersaoService
    {
        private readonly IMapper _mapper;
        private readonly IVersaoRepository _versaoRepository;

        public required string UserLogged { get; set; }

        public VersaoService(IHttpContextAccessor accessor
                           , IMapper mapper
                           , IVersaoRepository versaoRepository)
        {
            _mapper = mapper;
            _versaoRepository = versaoRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(VersaoModel entity)
        {
            Versao model = _mapper.Map<Versao>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _versaoRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            VersaoResultModel model = await GetById(id);

            Versao entity = _mapper.Map<Versao>(model);

            await _versaoRepository.Delete(entity);
        }

        public async Task<List<VersaoResultModel>> GetAll()
        {
            var entities = await _versaoRepository.GetAll(t => t.Id > 0);

            return _mapper.Map<List<VersaoResultModel>>(entities).OrderBy(x => x.Descricao).ToList();
        }

        public async Task<VersaoResultModel> GetById(int id)
        {
            Versao entity = await _versaoRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Versao com [Id = {id}] não encontrada.");
            }

            return _mapper.Map<VersaoResultModel>(entity);
        }

        public async Task Update(int id, VersaoModel entity)
        {
            Versao existentRecord = _mapper.Map<Versao>(await GetById(id));

            UtilService.CopyIfNotNullOrEmpty(entity, existentRecord);

            existentRecord.AtualizadoPor = UserLogged;

            await _versaoRepository.Update(existentRecord);
        }

        public async Task<IEnumerable<VersaoListModel>> GetList()
        {
            return await _versaoRepository.GetList();

        }
    }

}
