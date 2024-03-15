namespace Trevo.API.Application.Models
{
    public class UsuarioModel
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public string? Telefone { get; set; }
        public string? CPF { get; set; }
        public int? Perfil { get; set; }
        public bool? Ativo { get; set; }
    }
}
