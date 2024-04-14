using Trevo.API.Domain.Interfaces;

namespace Trevo.API.Application.Models
{
    public class VersaoListModel : IVersaoList
    {
        public int Id { get; set; }
        public int MarcaId { get; set; }
        public required string Marca { get; set; }
        public int ModeloId { get; set; }
        public required string Modelo { get; set; }
        public required string Descricao { get; set; }
    }
}
