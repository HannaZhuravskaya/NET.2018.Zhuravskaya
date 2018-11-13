using System.Collections.Generic;

namespace TypeSystem.Interfaces
{
    public interface IRepository<TSource> : IRepository
    {
        new IEnumerable<TSource> GetAll();
        bool Create(TSource source);
        bool Update(TSource source);
    }
}