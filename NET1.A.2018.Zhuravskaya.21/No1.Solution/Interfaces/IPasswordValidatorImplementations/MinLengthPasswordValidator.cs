using System;

namespace No1.Solution.Interfaces.IPasswordValidatorImplementations
{
    /// <summary>
    /// Password validator.
    /// </summary>
    public class MinLengthPasswordValidator : IPasswordValidator
    {
        private readonly int _minPasswordLength;

        /// <summary>
        /// Initializes a new instance of MinLengthPasswordValidator.
        /// </summary>
        /// <param name="minPasswordLength">
        /// min password length.
        /// </param>
        /// <exception cref="ArgumentException">
        /// minPasswordLength must be greater than 0
        /// </exception>
        public MinLengthPasswordValidator(int minPasswordLength)
        {
            if (minPasswordLength <= 0)
            {
                throw new ArgumentException(nameof(minPasswordLength) + "must be greater than 0.");
            }

            _minPasswordLength = minPasswordLength;
        }

        /// <summary>
        /// valid if the password length is not less than minPasswordValue.
        /// </summary>
        /// <param name="password">
        /// password to validate.
        /// </param>
        /// <returns>
        /// is passport valid and some info.
        /// </returns>
        public (bool, string) IsValid(string password)
        {
            if (password.Length < _minPasswordLength)
            {
                return (false, $"{password} length too short");
            }

            return (true, "Password is Ok. User was created");
        }
    }
}
