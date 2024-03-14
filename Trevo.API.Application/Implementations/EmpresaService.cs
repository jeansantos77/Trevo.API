using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Application.Models;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Application.Implementations
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IMapper _mapper;
        private readonly IEmpresaRepository _empresaRepository;

        public required string UserLogged { get; set; }

        public EmpresaService(IHttpContextAccessor accessor, IMapper mapper, IEmpresaRepository empresaRepository)
        {
            _mapper = mapper;
            _empresaRepository = empresaRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(EmpresaModel entity)
        {
            Empresa model = _mapper.Map<Empresa>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _empresaRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            EmpresaResultModel model = await GetById(id);

            Empresa entity = _mapper.Map<Empresa>(model);

            await _empresaRepository.Delete(entity);
        }

        public async Task<List<EmpresaResultModel>> GetAll()
        {
            var entities = await _empresaRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<EmpresaResultModel>>(entities);
        }

        public async Task<EmpresaResultModel> GetById(int id)
        {
            Empresa entity = await _empresaRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Empresa com [Id = {id}] não encontrada.");
            }

            return _mapper.Map<EmpresaResultModel>(entity);
        }

        public async Task Update(int id, EmpresaModel entity)
        {
            Empresa existentRecord = await _empresaRepository.GetById(x => x.Id == id);

            if (!string.IsNullOrEmpty(entity.Nome))
                existentRecord.Nome = entity.Nome;

            if (!string.IsNullOrEmpty(entity.Email))
                existentRecord.Email = entity.Email;

            if (!string.IsNullOrEmpty(entity.Telefone))
                existentRecord.Telefone = entity.Telefone;

            if (!string.IsNullOrEmpty(entity.Cnpj))
                existentRecord.Cnpj = entity.Cnpj;

            if (!string.IsNullOrEmpty(entity.Cep))
                existentRecord.Cep = entity.Cep;

            if (!string.IsNullOrEmpty(entity.Logradouro))
                existentRecord.Logradouro = entity.Logradouro;

            if (!string.IsNullOrEmpty(entity.Numero))
                existentRecord.Numero = entity.Numero;

            if (!string.IsNullOrEmpty(entity.Bairro))
                existentRecord.Bairro = entity.Bairro;

            if (entity.CidadeId.HasValue && existentRecord.CidadeId != entity.CidadeId)
                existentRecord.CidadeId = entity.CidadeId.Value;

            existentRecord.AtualizadoPor = UserLogged;

            await _empresaRepository.Update(existentRecord);
        }

    }

}
