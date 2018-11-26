using No1.Solution.Interfaces.IPasswordValidatorImplementations;
using No1.Solution.Interfaces.IRepositoryImplementations;
using NUnit.Framework;

namespace No1.Solution.Tests
{
    [TestFixture]
    public class PasswordCheckerServiceTests
    {
        [TestCase("asdfgh", ExpectedResult = false)]
        [TestCase("asdfgh1234567890", ExpectedResult = false)]
        [TestCase("asd123", ExpectedResult = false)]
        [TestCase("asdfgh123", ExpectedResult = true)]
        public bool VerifyPassword_CurrentValidation_ResultOfValidation(string password)
        {
            var repository = new SqlRepository();
            var validator = new CompositionOfPasswordValidators();

            var checker = new PasswordCheckerService(repository, new[] { validator });

            return checker.VerifyPassword(password).Item1;
        }
    }
}