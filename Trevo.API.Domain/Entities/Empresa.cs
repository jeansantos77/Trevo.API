namespace Trevo.API.Domain.Entities
{
    public class Empresa : Base
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Telefone { get; set; }
        public required string Cnpj { get; set; }
        public required string Cep { get; set; }
        public required string Logradouro { get; set; }
        public required string Numero { get; set; }
        public required string Bairro { get; set; }
        public required int CidadeId { get; set; }
        public required Cidade Cidade { get; set; }

    }
}
