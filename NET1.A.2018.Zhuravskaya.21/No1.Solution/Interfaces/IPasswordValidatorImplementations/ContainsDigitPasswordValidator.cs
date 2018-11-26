using System.Linq;

namespace No1.Solution.Interfaces.IPasswordValidatorImplementations
{
    /// <summary>
    /// Password validator.
    /// </summary>
    public class ContainsDigitPasswordValidator : IPasswordValidator
    {
        /// <summary>
        /// valid if password contains digit.
        /// </summary>
        /// <param name="password">
        /// password to validate.
        /// </param>
        /// <returns>
        /// is passport valid and some info.
        /// </returns>
        public (bool, string) IsValid(string password)
        {
            if (!password.Any(char.IsNumber))
            {
                return (false, $"{password} hasn't digits");
            }

            return (true, "Password is Ok. User was created");
        }
    }
}
