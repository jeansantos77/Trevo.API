namespace Trevo.API.Domain.Models
{
    public class FinanceiraModel
    {
        public  string? Nome { get; set; }
        public  string? Email { get; set; }
        public string? Cnpj { get; set; }
        public string? Contato { get; set; }
        public  string? Telefone { get; set; }
        public  string? Cep { get; set; }
        public  string? Logradouro { get; set; }
        public  string? Numero { get; set; }
        public string? Complemento { get; set; }
        public  string? Bairro { get; set; }
        public  int? CidadeId { get; set; }
        public string? Obs { get; set; }
        public bool? Ativo { get; set; }
    }
}
