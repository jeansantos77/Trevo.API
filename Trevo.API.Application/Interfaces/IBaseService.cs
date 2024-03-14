namespace Trevo.API.Application.Interfaces
{
    public interface IBaseService<T, T2> where T : class where T2 : class
    {
        public string UserLogged { get; set; }

        Task Add(T entity);
        Task Update(int id, T entity);
        Task Delete(int id);
        Task<T2> GetById(int id);
        Task<List<T2>> GetAll();
    }
}
