using AutoMapper;
using Microsoft.AspNetCore.Http;
using Trevo.API.Application.Interfaces;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Domain.Models;

namespace Trevo.API.Application.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public required string UserLogged { get; set; }

        public ClienteService(IHttpContextAccessor accessor, IMapper mapper, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;

            UserLogged = accessor.HttpContext?.User?.Identity?.Name ?? "Missing User";
        }

        public async Task Add(ClienteModel entity)
        {
            Cliente model = _mapper.Map<Cliente>(entity);

            model.CriadoPor = UserLogged;
            model.AtualizadoPor = model.CriadoPor;

            foreach (var item in model.ModelosDesejados)
            {
                item.CriadoPor = UserLogged;
                item.AtualizadoPor = item.CriadoPor;
            }

            await _clienteRepository.Add(model);
        }

        public async Task Delete(int id)
        {
            ClienteResultModel model = await GetById(id);

            Cliente entity = _mapper.Map<Cliente>(model);

            await _clienteRepository.Delete(entity);
        }

        public async Task<List<ClienteResultModel>> GetAll()
        {
            var entities = await _clienteRepository.GetAll(t => t.Id > 0);
            return _mapper.Map<List<ClienteResultModel>>(entities).OrderBy(x => x.Nome).ToList();
        }

        public async Task<ClienteResultModel> GetById(int id)
        {
            Cliente entity = await _clienteRepository.GetById(x => x.Id == id);

            if (entity == null)
            {
                throw new Exception($"Cliente com [Id = {id}] não encontrado.");
            }

            return _mapper.Map<ClienteResultModel>(entity);
        }

        public async Task Update(int id, ClienteModel entity)
        {
            try
            {
                _clienteRepository.StartTransaction();

                Cliente existentRecord = _mapper.Map<Cliente>(await GetById(id));
                
                UtilService.CopyIfNotNullOrEmpty(entity, existentRecord);
                
                existentRecord.AtualizadoPor = UserLogged;
                await _clienteRepository.Update(existentRecord);

                List<ModeloDesejado> modelosDesejadosOld = new(existentRecord.ModelosDesejados);

                foreach (var modeloOld in modelosDesejadosOld)
                {
                    ModeloDesejadoModel? model = entity.ModelosDesejados.FirstOrDefault(x => x.Id == modeloOld.Id);

                    if (model != null)
                    {
                        entity.ModelosDesejados.Remove(model);
                    }
                    else
                    {
                        await _clienteRepository.RemoveModeloDesejado(modeloOld);
                    }
                }

                if (entity.ModelosDesejados.Any())
                {
                    foreach (var modelo in entity.ModelosDesejados)
                    {
                        ModeloDesejado entityModelo = _mapper.Map<ModeloDesejado>(modelo);
                        entityModelo.CriadoPor = UserLogged;
                        entityModelo.AtualizadoPor = entityModelo.CriadoPor;
                        entityModelo.ClienteId = id;

                        await _clienteRepository.AddModeloDesejado(entityModelo);
                    }
                }

                _clienteRepository.Commit();
            }
            catch (Exception)
            {
                _clienteRepository.Rollback();
                throw;
            }
        }

    }

}
