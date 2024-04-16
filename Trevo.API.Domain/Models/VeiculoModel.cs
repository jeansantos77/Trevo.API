using System.Collections.ObjectModel;

namespace Trevo.API.Domain.Models
{
    public class VeiculoModel
    {
        public string? Placa { get; set; }
        public string? Renavam { get; set; }
        public short AnoFabricacao { get; set; }
        public short AnoModelo { get; set; }
        public short Portas { get; set; }
        public string? NumeroMotor { get; set; }
        public string? Chassi { get; set; }
        public int? CategoriaVeiculoId { get; set; }
        public int? ModeloId { get; set; }
        public int? VersaoId { get; set; }
        public int? CorId { get; set; }
        public int? CombustivelId { get; set; }
        public int? CambioId { get; set; }
        public int? SituacaoVeiculoId { get; set; }
        public double? ValorVenda { get; set; }
        public double? ValorMinimoVenda { get; set; }
        public double? ValorFipeEntrada { get; set; }
        public double? ValorFipeAtual { get; set; }
        public string? CodigoFipe { get; set; }
        public string? Obs { get; set; }
        public Collection<FotoVeiculoModel> FotosVeiculo { get; set; } = [];


    }
}
