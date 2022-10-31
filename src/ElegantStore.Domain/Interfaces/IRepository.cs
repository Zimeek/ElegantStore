using Ardalis.Specification;

namespace ElegantStore.Domain.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
    
}