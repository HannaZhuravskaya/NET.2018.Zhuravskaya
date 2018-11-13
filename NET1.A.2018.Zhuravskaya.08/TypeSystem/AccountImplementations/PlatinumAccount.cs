using System;

namespace TypeSystem.AccountImplementations
{
    public class PlatinumAccount : Account
    {
        private static decimal _benefitsPoints;

        public static readonly decimal CreditLimit;

        static PlatinumAccount()
        {
            _benefitsPoints = 5m;
            CreditLimit = -1000m;
        }
   
        protected override void CreateTypeAccount(Client client)
        {
        }

        protected override decimal CalculateBenefitsPoints(decimal changeBalance)
        {
            throw new NotImplementedException();
        }

        protected override bool IsCreditAllowed(decimal balance)
        {
            return balance >= CreditLimit;
        }
    }
}
