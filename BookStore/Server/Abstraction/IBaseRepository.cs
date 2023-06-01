using BookStore.Shared.Base;

namespace BookStore.Server.Abstraction
{
    public interface IBaseRepository<TEntity> where TEntity : IDocument
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(string id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(string id);
    }
}
