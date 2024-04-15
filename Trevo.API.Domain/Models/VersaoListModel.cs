namespace Trevo.API.Domain.Models
{
    public class VersaoListModel
    {
        public int Id { get; set; }
        public int MarcaId { get; set; }
        public required string Marca { get; set; }
        public int ModeloId { get; set; }
        public required string Modelo { get; set; }
        public required string Descricao { get; set; }
    }
}
