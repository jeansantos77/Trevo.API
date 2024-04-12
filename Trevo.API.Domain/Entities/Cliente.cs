using System.Collections.ObjectModel;

namespace Trevo.API.Domain.Entities
{
    public class Cliente : Base
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required DateTime Nascimento { get; set; }
        public required string Cpf { get; set; }
        public required string Telefone { get; set; }
        public required string Cep { get; set; }
        public required string Logradouro { get; set; }
        public required string Numero { get; set; }
        public required string Complemento { get; set; }
        public required string Bairro { get; set; }
        public required int CidadeId { get; set; }
        public required Cidade Cidade { get; set; }
        public required int FormaPagamentoId { get; set; }
        public required FormaPagamento FormaPagamento { get; set; }
        public string? Obs { get; set; }
        public Collection<ModeloDesejado> ModelosDesejados { get; set; } = [];

    }
}
