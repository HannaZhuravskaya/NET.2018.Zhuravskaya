namespace No1.Solution.Interfaces
{
    /// <summary>
    /// Abstract repository.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Add line to repository.
        /// </summary>
        /// <param name="password">
        /// line to add
        /// </param>
        void Create(string password);
    }
}
