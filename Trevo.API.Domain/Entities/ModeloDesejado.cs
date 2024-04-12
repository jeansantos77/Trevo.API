namespace Trevo.API.Domain.Entities
{
    public class ModeloDesejado : Base
    {
        public required int MarcaId { get; set; }
        public required Marca Marca { get; set; }
        public required int ModeloId { get; set; }
        public required Modelo Modelo { get; set; }
        public required int CorId { get; set; }
        public required Cor Cor { get; set; }

    }
}
