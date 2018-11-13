namespace TypeSystem.Interfaces
{
    public interface IGeneratorId<out TId, in TOwner> : IGeneratorId
    {
        TId CreateId(TOwner owner);
    }
}
