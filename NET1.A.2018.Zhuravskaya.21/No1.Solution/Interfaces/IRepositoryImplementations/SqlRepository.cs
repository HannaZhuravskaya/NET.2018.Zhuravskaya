namespace No1.Solution.Interfaces.IRepositoryImplementations
{
    /// <summary>
    /// Sql repository.
    /// </summary>
    public class SqlRepository : IRepository
    {
        private string _lastString;

        /// <summary>
        /// Add line to repository.
        /// </summary>
        /// <param name="password">
        /// line to add
        /// </param>
        public void Create(string password)
        {
            _lastString = password;
        }

        /// <summary>
        /// Get last added string from repositry.
        /// </summary>
        /// <param name="lastString">
        /// last added string
        /// </param>
        /// <returns>
        /// last added string
        /// </returns>
        public string GetLastAddedString(string lastString)
        {
            return _lastString;
        }
    }
}
