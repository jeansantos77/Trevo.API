namespace Trevo.API.Domain.Entities
{
    public class Modelo : Base
    {
        public required string Descricao { get; set; }
        public required int MarcaId { get; set; }
        public required Marca Marca { get; set; }
    }
}
