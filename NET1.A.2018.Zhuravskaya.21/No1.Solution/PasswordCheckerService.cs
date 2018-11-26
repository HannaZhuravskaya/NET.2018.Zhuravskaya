using System;
using System.Collections.Generic;
using No1.Solution.Interfaces;

namespace No1.Solution
{
    /// <summary>
    /// Password checker service.
    /// </summary>
    public class PasswordCheckerService
    {
        private readonly IRepository _repository;

        private readonly IEnumerable<IPasswordValidator> _validators;

        /// <summary>
        /// Initializes a new instance of PasswordCheckerService.
        /// </summary>
        /// <param name="repository">
        /// password repository
        /// </param>
        /// <param name="validators">
        /// password validators
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// repository must not be null.
        /// validators must not be null.
        /// </exception>
        public PasswordCheckerService(IRepository repository, IEnumerable<IPasswordValidator> validators)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository) + "must not be null.");
            _validators = validators ?? throw new ArgumentNullException(nameof(validators) + "must not be null.");
        }

        /// <summary>
        /// Verify password and added to repository.
        /// </summary>
        /// <param name="password">
        /// password to verify
        /// </param>
        /// <returns>
        /// is passport valid and some info.
        /// </returns>
        /// <exception cref="ArgumentException">
        ///password is null arg.
        /// </exception>
        public (bool, string) VerifyPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentException($"{password} is null arg");
            }

            if (password == string.Empty)
            {
                return (false, $"{password} is empty ");
            }

            foreach (var validator in _validators)
            {
                var validatorResult = validator.IsValid(password);
                if (!validatorResult.Item1)
                {
                    return validatorResult;
                }
            }

            _repository.Create(password);

            return (true, "Password is Ok. User was created");
        }
    }
}