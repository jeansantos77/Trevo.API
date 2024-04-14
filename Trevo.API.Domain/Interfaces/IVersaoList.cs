namespace Trevo.API.Domain.Interfaces
{
    public interface IVersaoList
    {
        public int Id { get; set; }
        public int MarcaId { get; set; }
        public string Marca { get; set; }
        public int ModeloId { get; set; }
        public string Modelo { get; set; }
        public string Descricao { get; set; }
    }
}
