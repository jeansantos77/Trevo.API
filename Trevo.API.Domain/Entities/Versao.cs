namespace Trevo.API.Domain.Entities
{
    public class Versao : Base
    {
        public required string Descricao { get; set; }
        public required int ModeloId { get; set; }
        public required Modelo Modelo { get; set; }
    }
}
