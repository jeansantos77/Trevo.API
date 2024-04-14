using Microsoft.EntityFrameworkCore;
using Trevo.API.Application.Models;
using Trevo.API.Domain.Entities;
using Trevo.API.Domain.Interfaces;
using Trevo.API.Infra.Data.Context;

namespace Trevo.API.Infra.Data.Repository
{
    public class VersaoRepository : BaseRepository<Versao>, IVersaoRepository
    {
        public VersaoRepository(TrevoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<IVersaoList>> GetList()
        {
            var query = from versao in _dbContext.Versoes
                        join modelo in _dbContext.Modelos on versao.ModeloId equals modelo.Id
                        join marca in _dbContext.Marcas on modelo.MarcaId equals marca.Id
                        select new VersaoListModel
                        {
                            Id = versao.Id,
                            MarcaId = marca.Id,
                            Marca = marca.Descricao,
                            ModeloId = modelo.Id,
                            Modelo = modelo.Descricao,
                            Descricao = versao.Descricao
                        };

            return await query.ToListAsync();
        }
    }
}
