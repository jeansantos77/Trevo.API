namespace Trevo.API.Application.Models
{
    public class CategoriaDespesaResultModel
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }

        public string? CriadoPor { get; set; }
        public DateTime? CriadoEm { get; set; }
        public string? AtualizadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }
    }
}
