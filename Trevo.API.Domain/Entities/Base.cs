namespace Trevo.API.Domain.Entities
{
    public class Base
    {
        public int Id { get; set; }
        public required string CriadoPor { get; set; }
        public DateTime CriadoEm { get; set; }
        public required string AtualizadoPor { get; set; }
        public DateTime AtualizadoEm { get; set; }

    }
}
