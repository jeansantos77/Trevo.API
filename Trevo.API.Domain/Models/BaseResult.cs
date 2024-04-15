namespace Trevo.API.Domain.Models
{
    public class BaseResult
    {
        public int Id { get; set; }
        
        public string? CriadoPor { get; set; }
        public DateTime? CriadoEm { get; set; }
        public string? AtualizadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }

    }

}
