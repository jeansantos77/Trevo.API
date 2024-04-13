namespace Trevo.API.Domain.Entities
{
    public class FotoVeiculo : Base
    {
        public required string Descricao { get; set; }
        public required string Caminho { get; set; }
        public required string Nome { get; set; }
        public required int VeiculoId { get; set; }
        public required Veiculo Veiculo { get; set; }
    }
}
