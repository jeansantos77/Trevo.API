using System.Collections.ObjectModel;

namespace Trevo.API.Domain.Models
{
    public class ClienteModel
    {
        public  string? Nome { get; set; }
        public  string? Email { get; set; }
        public DateTime? Nascimento { get; set; }
        public  string? Telefone { get; set; }
        public string? Cpf { get; set; }
        public  string? Cep { get; set; }
        public  string? Logradouro { get; set; }
        public  string? Numero { get; set; }
        public string? Complemento { get; set; }
        public  string? Bairro { get; set; }
        public  int? CidadeId { get; set; }
        public required int FormaPagamentoId { get; set; }
        public string? Obs { get; set; }
        public Collection<ModeloDesejadoModel> ModelosDesejados { get; set; } = new Collection<ModeloDesejadoModel>();

    }
}
