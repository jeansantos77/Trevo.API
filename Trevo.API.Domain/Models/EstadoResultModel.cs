namespace Trevo.API.Domain.Models
{
    public class EstadoResultModel : BaseResult
    {
        public string? Nome { get; set; }
        public string? UF { get; set; }
        public int? PaisId { get; set; }
    }
}
