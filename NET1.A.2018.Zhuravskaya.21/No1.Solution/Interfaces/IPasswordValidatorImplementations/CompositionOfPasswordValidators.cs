using System.Collections.Generic;

namespace No1.Solution.Interfaces.IPasswordValidatorImplementations
{
    /// <summary>
    /// Password validator.
    /// </summary>
    public class CompositionOfPasswordValidators : IPasswordValidator
    {
        private readonly IEnumerable<IPasswordValidator> _validators;

        /// <summary>
        /// Initializes a new instance of MinLengthPasswordValidator.
        /// </summary>
        public CompositionOfPasswordValidators()
        {
            _validators = new List<IPasswordValidator>
            {
                new ContainsCharPasswordValidator(), new ContainsDigitPasswordValidator(),
                new MaxLengthPasswordValidator(15), new MinLengthPasswordValidator(8)
            };
        }

        /// <summary>
        /// valid if the password length is not less than 8, not greater than 15, contains digit and char.
        /// </summary>
        /// <param name="password">
        /// password to validate.
        /// </param>
        /// <returns>
        /// is passport valid and some info.
        /// </returns>
        public (bool, string) IsValid(string password)
        {
            foreach (var validator in _validators)
            {
                var validatorResult = validator.IsValid(password);
                if (!validatorResult.Item1)
                {
                    return validatorResult;
                }
            }

            return (true, "Password is Ok. User was created");
        }
    }
}