using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Domain.Models;

namespace Trevo.API.Application.Implementations
{
    public class FinanceiraService : IFinanceiraService
    {
        private readonly IMapper _mapper;
        private readonly IFinanceiraRepository _financeiraRepository;

        public required string UserLogged { get; set; }

        public FinanceiraService(IHttpContextAccessor accessor, IMapper mapper, IFinanceiraRepository financeiraRepository)
        {
            _mapper = mapper;
            _financeiraRepository = financeiraRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(FinanceiraModel entity)
        {
            Financeira model = _mapper.Map<Financeira>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _financeiraRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            FinanceiraResultModel model = await GetById(id);

            Financeira entity = _mapper.Map<Financeira>(model);

            await _financeiraRepository.Delete(entity);
        }

        public async Task<List<FinanceiraResultModel>> GetAll()
        {
            var entities = await _financeiraRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<FinanceiraResultModel>>(entities).OrderBy(x => x.Nome).ToList();
        }

        public async Task<FinanceiraResultModel> GetById(int id)
        {
            Financeira entity = await _financeiraRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Financeira com [Id = {id}] não encontrada.");
            }

            return _mapper.Map<FinanceiraResultModel>(entity);
        }

        public async Task Update(int id, FinanceiraModel entity)
        {
            Financeira existentRecord = _mapper.Map<Financeira>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Nome))
                existentRecord.Nome = entity.Nome;

            if (!string.IsNullOrEmpty(entity.Email))
                existentRecord.Email = entity.Email;

            if (!string.IsNullOrEmpty(entity.Telefone))
                existentRecord.Telefone = entity.Telefone;

            if (!string.IsNullOrEmpty(entity.Contato))
                existentRecord.Contato = entity.Contato;

            if (!string.IsNullOrEmpty(entity.Cnpj))
                existentRecord.Cnpj = entity.Cnpj;

            if (!string.IsNullOrEmpty(entity.Cep))
                existentRecord.Cep = entity.Cep;

            if (!string.IsNullOrEmpty(entity.Logradouro))
                existentRecord.Logradouro = entity.Logradouro;

            if (!string.IsNullOrEmpty(entity.Numero))
                existentRecord.Numero = entity.Numero;

            if (!string.IsNullOrEmpty(entity.Complemento))
                existentRecord.Complemento = entity.Complemento;

            if (!string.IsNullOrEmpty(entity.Bairro))
                existentRecord.Bairro = entity.Bairro;

            if (entity.CidadeId.HasValue && existentRecord.CidadeId != entity.CidadeId)
                existentRecord.CidadeId = entity.CidadeId.Value;

            if (!string.IsNullOrEmpty(entity.Obs))
                existentRecord.Obs = entity.Obs;

            if (entity.Ativo.HasValue && existentRecord.Ativo != entity.Ativo)
                existentRecord.Ativo = entity.Ativo.Value;

            existentRecord.AtualizadoPor = UserLogged;

            await _financeiraRepository.Update(existentRecord);

        }

    }

}
