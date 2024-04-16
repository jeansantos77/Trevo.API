using System.Collections.ObjectModel;

namespace Trevo.API.Domain.Entities
{
    public class Veiculo : Base
    {
        public required string Placa { get; set; }
        public required string Renavam { get; set; }
        public short AnoFabricacao { get; set; }
        public short AnoModelo { get; set; }
        public short Portas { get; set; }
        public string? NumeroMotor { get; set; }
        public string? Chassi { get; set; }
        public int CategoriaVeiculoId { get; set; }
        public required CategoriaVeiculo CategoriaVeiculo { get; set; }
        public int ModeloId { get; set; }
        public required Modelo Modelo { get; set; }
        public int VersaoId { get; set; }
        public required Versao Versao { get; set; }
        public int CorId { get; set; }
        public required Cor Cor { get; set; }
        public int CombustivelId { get; set; }
        public required Combustivel Combustivel { get; set; }
        public int CambioId { get; set; }
        public required Cambio Cambio { get; set; }
        public int SituacaoVeiculoId { get; set; }
        public required SituacaoVeiculo SituacaoVeiculo { get; set; }
        public double? ValorVenda { get; set; }
        public double? ValorMinimoVenda { get; set; }
        public double? ValorFipeEntrada { get; set; }
        public double? ValorFipeAtual { get; set; }
        public string? CodigoFipe { get; set; }
        public string? Obs { get; set; }
        public Collection<FotoVeiculo> FotosVeiculo { get; set; } = [];

    }
}
