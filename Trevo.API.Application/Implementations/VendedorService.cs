using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Application.Models;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Domain.Entities;

namespace Trevo.API.Application.Implementations
{
    public class VendedorService : IVendedorService
    {
        private readonly IMapper _mapper;
        private readonly IVendedorRepository _vendedorRepository;

        public required string UserLogged { get; set; }

        public VendedorService(IHttpContextAccessor accessor, IMapper mapper, IVendedorRepository vendedorRepository)
        {
            _mapper = mapper;
            _vendedorRepository = vendedorRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(VendedorModel entity)
        {
            Vendedor model = _mapper.Map<Vendedor>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _vendedorRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            VendedorResultModel model = await GetById(id);

            Vendedor entity = _mapper.Map<Vendedor>(model);

            await _vendedorRepository.Delete(entity);
        }

        public async Task<List<VendedorResultModel>> GetAll()
        {
            var entities = await _vendedorRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<VendedorResultModel>>(entities).OrderBy(x => x.Nome).ToList();
        }

        public async Task<VendedorResultModel> GetById(int id)
        {
            Vendedor entity = await _vendedorRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Vendedor com [Id = {id}] não encontrado.");
            }

            return _mapper.Map<VendedorResultModel>(entity);
        }

        public async Task Update(int id, VendedorModel entity)
        {
            Vendedor existentRecord = _mapper.Map<Vendedor>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Nome))
                existentRecord.Nome = entity.Nome;

            if (!string.IsNullOrEmpty(entity.Email))
                existentRecord.Email = entity.Email;

            if (!string.IsNullOrEmpty(entity.Telefone))
                existentRecord.Telefone = entity.Telefone;

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

            await _vendedorRepository.Update(existentRecord);

        }

    }

}
