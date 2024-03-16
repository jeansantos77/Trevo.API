using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Application.Models;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;

namespace Trevo.API.Application.Implementations
{
    public class FormaPagamentoService : IFormaPagamentoService
    {
        private readonly IMapper _mapper;
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;

        public required string UserLogged { get; set; }

        public FormaPagamentoService(IHttpContextAccessor accessor, IMapper mapper, IFormaPagamentoRepository formaPagamentoRepository)
        {
            _mapper = mapper;
            _formaPagamentoRepository = formaPagamentoRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(FormaPagamentoModel entity)
        {
            FormaPagamento model = _mapper.Map<FormaPagamento>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _formaPagamentoRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            FormaPagamentoResultModel model = await GetById(id);

            FormaPagamento entity = _mapper.Map<FormaPagamento>(model);

            await _formaPagamentoRepository.Delete(entity);
        }

        public async Task<List<FormaPagamentoResultModel>> GetAll()
        {
            var entities = await _formaPagamentoRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<FormaPagamentoResultModel>>(entities).OrderBy(x => x.Descricao).ToList();
        }

        public async Task<FormaPagamentoResultModel> GetById(int id)
        {
            FormaPagamento entity = await _formaPagamentoRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Forma de Pagamento com [Id = {id}] não encontrada.");
            }

            return _mapper.Map<FormaPagamentoResultModel>(entity);
        }

        public async Task Update(int id, FormaPagamentoModel entity)
        {
            FormaPagamento existentReFormaPagamentod = _mapper.Map<FormaPagamento>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Descricao))
                existentReFormaPagamentod.Descricao = entity.Descricao;

            existentReFormaPagamentod.AtualizadoPor = UserLogged;

            await _formaPagamentoRepository.Update(existentReFormaPagamentod);
        }
    }
}
