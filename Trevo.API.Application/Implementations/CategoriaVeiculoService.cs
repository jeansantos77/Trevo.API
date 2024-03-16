using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Application.Models;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;

namespace Trevo.API.Application.Implementations
{
    public class CategoriaVeiculoService : ICategoriaVeiculoService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaVeiculoRepository _categoriaVeiculoRepository;

        public required string UserLogged { get; set; }

        public CategoriaVeiculoService(IHttpContextAccessor accessor, IMapper mapper, ICategoriaVeiculoRepository categoriaVeiculoRepository)
        {
            _mapper = mapper;
            _categoriaVeiculoRepository = categoriaVeiculoRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(CategoriaVeiculoModel entity)
        {
            CategoriaVeiculo model = _mapper.Map<CategoriaVeiculo>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _categoriaVeiculoRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            CategoriaVeiculoResultModel model = await GetById(id);

            CategoriaVeiculo entity = _mapper.Map<CategoriaVeiculo>(model);

            await _categoriaVeiculoRepository.Delete(entity);
        }

        public async Task<List<CategoriaVeiculoResultModel>> GetAll()
        {
            var entities = await _categoriaVeiculoRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<CategoriaVeiculoResultModel>>(entities).OrderBy(x => x.Descricao).ToList();
        }

        public async Task<CategoriaVeiculoResultModel> GetById(int id)
        {
            CategoriaVeiculo entity = await _categoriaVeiculoRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Categoria Veículo com [Id = {id}] não encontrada.");
            }

            return _mapper.Map<CategoriaVeiculoResultModel>(entity);
        }

        public async Task Update(int id, CategoriaVeiculoModel entity)
        {
            CategoriaVeiculo existentRecord = _mapper.Map<CategoriaVeiculo>(await GetById(id));

            if (!string.IsNullOrEmpty(entity.Descricao))
                existentRecord.Descricao = entity.Descricao;

            existentRecord.AtualizadoPor = UserLogged;

            await _categoriaVeiculoRepository.Update(existentRecord);
        }
    }
}
