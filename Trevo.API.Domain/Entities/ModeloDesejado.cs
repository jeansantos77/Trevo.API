namespace Trevo.API.Domain.Entities
{
    public class ModeloDesejado : Base
    {
        public required int ModeloId { get; set; }
        public required Modelo Modelo { get; set; }
        public int? VersaoId { get; set; }
        public Versao? Versao { get; set; }
        public required int CorId { get; set; }
        public required Cor Cor { get; set; }
        public required int ClienteId { get; set; }
        public required Cliente Cliente { get; set; }

    }
}
