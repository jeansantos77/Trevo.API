namespace Trevo.API.Application.Models
{
    public class EmpresaResultModel : BaseResult
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Cnpj { get; set; }
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public int? CidadeId { get; set; }
    }
}
