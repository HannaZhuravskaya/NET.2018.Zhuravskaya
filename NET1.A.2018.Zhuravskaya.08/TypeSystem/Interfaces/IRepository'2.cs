namespace TypeSystem.Interfaces
{
    public interface IRepository<in TKey, TSource> : IRepository<TSource>
    {
        TSource GetBy(TKey key);
    }
}
