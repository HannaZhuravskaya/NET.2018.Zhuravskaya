namespace No1.Solution.Interfaces
{
    /// <summary>
    /// Password validator.
    /// </summary>
    public interface IPasswordValidator
    {
        /// <summary>
        /// Is password valid.
        /// </summary>
        /// <param name="password">
        /// password to validate.
        /// </param>
        /// <returns>
        /// is passport valid and some info.
        /// </returns>
        (bool, string) IsValid(string password);
    }
}
