using System.Collections.Generic;

namespace No1.Solution.Interfaces.IPasswordValidatorImplementations
{
    public class CompositionOfPasswordValidators : IPasswordValidator
    {
        private readonly IEnumerable<IPasswordValidator> _validators;

        public CompositionOfPasswordValidators()
        {
            _validators = new List<IPasswordValidator>
            {
                new ContainsCharPasswordValidator(), new ContainsDigitPasswordValidator(),
                new MaxLengthPasswordValidator(15), new MinLengthPasswordValidator(8)
            };
        }

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