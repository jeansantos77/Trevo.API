using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Domain.Models;

namespace Trevo.API.Application.Implementations
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IMapper _mapper;
        private readonly IFornecedorRepository _fornecedorRepository;

        public required string UserLogged { get; set; }

        public FornecedorService(IHttpContextAccessor accessor, IMapper mapper, IFornecedorRepository fornecedorRepository)
        {
            _mapper = mapper;
            _fornecedorRepository = fornecedorRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(FornecedorModel entity)
        {
            Fornecedor model = _mapper.Map<Fornecedor>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _fornecedorRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            FornecedorResultModel model = await GetById(id);

            Fornecedor entity = _mapper.Map<Fornecedor>(model);

            await _fornecedorRepository.Delete(entity);
        }

        public async Task<List<FornecedorResultModel>> GetAll()
        {
            var entities = await _fornecedorRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<FornecedorResultModel>>(entities).OrderBy(x => x.Nome).ToList();
        }

        public async Task<FornecedorResultModel> GetById(int id)
        {
            Fornecedor entity = await _fornecedorRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Fornecedor com [Id = {id}] não encontrado.");
            }

            return _mapper.Map<FornecedorResultModel>(entity);
        }

        public async Task Update(int id, FornecedorModel entity)
        {
            Fornecedor existentRecord = _mapper.Map<Fornecedor>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Nome))
                existentRecord.Nome = entity.Nome;

            if (!string.IsNullOrEmpty(entity.Email))
                existentRecord.Email = entity.Email;

            if (!string.IsNullOrEmpty(entity.TipoPessoa))
                existentRecord.TipoPessoa = entity.TipoPessoa;

            if (!string.IsNullOrEmpty(entity.Telefone))
                existentRecord.Telefone = entity.Telefone;

            if (!string.IsNullOrEmpty(entity.Contato))
                existentRecord.Contato = entity.Contato;

            if (!string.IsNullOrEmpty(entity.Cnpj))
                existentRecord.Cnpj = entity.Cnpj;

            if (!string.IsNullOrEmpty(entity.Cpf))
                existentRecord.Cpf = entity.Cpf;

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

            await _fornecedorRepository.Update(existentRecord);

        }

    }

}
