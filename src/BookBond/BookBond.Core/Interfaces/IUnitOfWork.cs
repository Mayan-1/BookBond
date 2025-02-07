namespace BookBond.Core.Interfaces;

public interface IUnitOfWork
{
    Task Commit();
}