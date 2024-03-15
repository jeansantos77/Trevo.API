namespace Trevo.API.Domain.Entities
{
    public class Usuario : Base
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public string? Telefone { get; set; }
        public string? CPF { get; set; }
        public required string Login { get; set; }
        public required string Senha { get; set; }
        public required int Perfil { get; set; }
        public required bool Ativo { get; set; }

    }
}
