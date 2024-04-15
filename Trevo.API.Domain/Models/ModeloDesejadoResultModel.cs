namespace Trevo.API.Domain.Models
{
    public class ModeloDesejadoResultModel : BaseResult
    {
        public string? Marca { get; set; }
        public int? ModeloId { get; set; }
        public string? Modelo { get; set; }
        public int? VersaoId { get; set; }
        public string? Versao { get; set; }
        public int? CorId { get; set; }
        public string? Cor { get; set; }
        public int? ClienteId { get; set; }
    }
}
