namespace Trevo.API.Application.Models
{
    public class CidadeResultModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? EstadoId { get; set; }

        public string? CriadoPor { get; set; }
        public DateTime? CriadoEm { get; set; }
        public string? AtualizadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}
