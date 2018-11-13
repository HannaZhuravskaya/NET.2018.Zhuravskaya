using System.Collections;

namespace TypeSystem.Interfaces
{
    public interface IRepository
    {
        IEnumerable GetAll();
        bool Create(object source);
        bool Update(object source);
    }
}
