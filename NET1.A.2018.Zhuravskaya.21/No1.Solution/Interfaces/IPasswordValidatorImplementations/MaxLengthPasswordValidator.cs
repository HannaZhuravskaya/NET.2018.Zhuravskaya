using System;

namespace No1.Solution.Interfaces.IPasswordValidatorImplementations
{
    /// <summary>
    /// Password validator.
    /// </summary>
    public class MaxLengthPasswordValidator : IPasswordValidator
    {
        private readonly int _maxPasswordLength;

        /// <summary>
        /// Initializes a new instance of MinLengthPasswordValidator.
        /// </summary>
        /// <param name="maxPasswordLength">
        /// max password length.
        /// </param>
        /// <exception cref="ArgumentException">
        /// minPasswordLength must be greater than 0
        /// </exception>
        public MaxLengthPasswordValidator(int maxPasswordLength)
        {
            if (maxPasswordLength <= 0)
            {
                throw new ArgumentException(nameof(maxPasswordLength) + "must be greater than 0.");
            }

            _maxPasswordLength = maxPasswordLength;
        }

        /// <summary>
        /// valid if the password length is not greater than minPasswordValue.
        /// </summary>
        /// <param name="password">
        /// password to validate.
        /// </param>
        /// <returns>
        /// is passport valid and some info.
        /// </returns>
        public (bool, string) IsValid(string password)
        {
            if (password.Length > _maxPasswordLength)
            {
                return (false, $"{password} length too long");
            }

            return (true, "Password is Ok. User was created");
        }
    }
}
