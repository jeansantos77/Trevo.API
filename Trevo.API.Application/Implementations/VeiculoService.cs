using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Domain.Models;

namespace Trevo.API.Application.Implementations
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IMapper _mapper;
        private readonly IVeiculoRepository _veiculoRepository;

        public required string UserLogged { get; set; }

        public VeiculoService(IHttpContextAccessor accessor, IMapper mapper, IVeiculoRepository veiculoRepository)
        {
            _mapper = mapper;
            _veiculoRepository = veiculoRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(VeiculoModel entity)
        {
            Veiculo model = _mapper.Map<Veiculo>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            await _veiculoRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            VeiculoResultModel model = await GetById(id);

            Veiculo entity = _mapper.Map<Veiculo>(model);

            await _veiculoRepository.Delete(entity);
        }

        public async Task<List<VeiculoResultModel>> GetAll()
        {
            var entities = await _veiculoRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<VeiculoResultModel>>(entities).OrderBy(x => x.Placa).ToList();
        }

        public async Task<VeiculoResultModel> GetById(int id)
        {
            Veiculo entity = await _veiculoRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Veiculo com [Id = {id}] não encontrado.");
            }

            return _mapper.Map<VeiculoResultModel>(entity);
        }

        public async Task Update(int id, VeiculoModel entity)
        {
            try
            {
                _veiculoRepository.StartTransaction();

                Veiculo existentRecord = _mapper.Map<Veiculo>(await GetById(id));

                UtilService.CopyIfNotNullOrEmpty(entity, existentRecord);

                existentRecord.AtualizadoPor = UserLogged;

                await _veiculoRepository.Update(existentRecord);

                List<FotoVeiculo> fotosOld = new(existentRecord.FotosVeiculo);

                foreach (var foto in fotosOld)
                {
                    FotoVeiculoModel? model = entity.FotosVeiculo.FirstOrDefault(x => x.Id == foto.Id);

                    if (model != null)
                    {
                        entity.FotosVeiculo.Remove(model);
                    }
                    else
                    {
                        await _veiculoRepository.RemoveFotoVeiculo(foto);
                    }
                }

                if (entity.FotosVeiculo.Any())
                {
                    foreach (var foto in entity.FotosVeiculo)
                    {
                        FotoVeiculo entityFoto = _mapper.Map<FotoVeiculo>(foto);
                        entityFoto.CriadoPor = UserLogged;
                        entityFoto.AtualizadoPor = entityFoto.CriadoPor;
                        entityFoto.VeiculoId = id;

                        await _veiculoRepository.AddFotoVeiculo(entityFoto);
                    }
                }
                _veiculoRepository.Commit();
            }
            catch (Exception)
            {
                _veiculoRepository.Rollback();
                throw;
            }

        }

    }

}
