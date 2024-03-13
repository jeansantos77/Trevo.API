namespace Trevo.API.Domain.Entities
{
    public class Cidade : Base
    {
        public required string Nome { get; set; }
        public required int EstadoId { get; set; }
        public required Estado Estado { get; set; }
    }
}
