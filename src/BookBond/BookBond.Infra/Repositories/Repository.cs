using BookBond.Core.Common;
using BookBond.Core.Interfaces;
using BookBond.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookBond.Infra.Repositories;

public class Repository<T> : IRepository<T> where T : BaseModel
{
    protected readonly AppDbContext Context;

    public Repository(AppDbContext context)
    {
        Context = context;
    }
    public void Create(T model)
    {
        model.DateCreated = DateTime.Now.ToUniversalTime()  ;
        Context.Set<T>().Add(model);
    }

    public void Update(T model)
    {
        model.DateUpdated = DateTime.Now;
        Context.Set<T>().Update(model);
    }

    public void Delete(T model)
    {
        model.DateDeleted = DateTime.Now;
        Context.Set<T>().Remove(model);
    }

    public async Task<T> Get(Guid id)
    {
        var response = await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        return response;
    }

    public async Task<ICollection<T>> GetAll()
    {
        var response = await Context.Set<T>().ToListAsync();
        return response;
    }
}