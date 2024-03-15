namespace Trevo.API.Domain.Entities
{
    public class Estado : Base
    {
        public required string Nome { get; set; }
        public required string UF { get; set; }
        public required int PaisId { get; set; }
        public required Pais Pais { get; set; }
    }
}
