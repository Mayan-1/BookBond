using BookBond.Core.Common;

namespace BookBond.Core.Interfaces;

public interface IRepository<T> where T : BaseModel
{
    void Create(T model);
    void Update(T model);
    void Delete(T model);
    Task<T> Get(Guid id);
    Task<ICollection<T>> GetAll();
}
