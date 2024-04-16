namespace Trevo.API.Domain.Models
{
    public class FotoVeiculoResultModel : BaseResult
    {
        public string? Descricao { get; set; }
        public string? Caminho { get; set; }
        public string? Nome { get; set; }
        public int? VeiculoId { get; set; }
    }
}
