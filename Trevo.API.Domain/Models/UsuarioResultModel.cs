namespace Trevo.API.Domain.Models
{
    public class UsuarioResultModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public int? Perfil { get; set; }
        public bool? Ativo { get; set; }

        public string? CriadoPor { get; set; }
        public DateTime? CriadoEm { get; set; }
        public string? AtualizadoPor { get; set; }
        public DateTime? AtualizadoEm { get; set; }

    }
}
