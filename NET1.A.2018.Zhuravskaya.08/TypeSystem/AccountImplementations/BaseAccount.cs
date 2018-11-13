namespace TypeSystem.AccountImplementations
{
    public sealed class BaseAccount : Account
    {
        private static readonly decimal _benefitsPoints;

        public static readonly decimal CreditLimit;

        static BaseAccount()
        {
            _benefitsPoints = 0m;
            CreditLimit = 0m;
        }

        protected override void CreateTypeAccount(Client client)
        {
        }

        protected override decimal CalculateBenefitsPoints(decimal changeBalance)
        {
            return _benefitsPoints;
        }

        protected override bool IsCreditAllowed(decimal balance)
        {
            return balance >= CreditLimit;
        }
    }
}
