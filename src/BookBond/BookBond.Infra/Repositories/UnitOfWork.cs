using BookBond.Core.Interfaces;
using BookBond.Infra.Data;

namespace BookBond.Infra.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context; 
    }
    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }
}