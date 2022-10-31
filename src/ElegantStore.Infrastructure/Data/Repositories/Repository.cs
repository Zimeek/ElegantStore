using Ardalis.Specification.EntityFrameworkCore;
using ElegantStore.Domain.Interfaces;

namespace ElegantStore.Infrastructure.Data.Repositories;

public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
{
    public Repository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        
    }
}