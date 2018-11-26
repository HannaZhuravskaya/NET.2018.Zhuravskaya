using System.Linq;

namespace No1.Solution.Interfaces.IPasswordValidatorImplementations
{
    /// <summary>
    /// Password validator.
    /// </summary>
    public class ContainsCharPasswordValidator : IPasswordValidator
    {
        /// <summary>
        /// valid if password contains alphanumerical char.
        /// </summary>
        /// <param name="password">
        /// password to validate.
        /// </param>
        /// <returns>
        /// is passport valid and some info.
        /// </returns>
        public (bool, string) IsValid(string password)
        {
            if (!password.Any(char.IsLetter))
            {
                return (false, $"{password} hasn't alphanumerical chars");
            }

            return (true, "Password is Ok. User was created");
        }
    }
}
