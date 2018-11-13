using System;
using TypeSystem.IGeneratorIdImplementations;
using TypeSystem.Interfaces;

namespace TypeSystem
{
    public abstract class Account
    {
        private static readonly IGeneratorId<string, Account> _idGenerator;

        public Client AccountOwner { get; private set; }

        public string Id { get; private set; }

        public decimal Balance { get; private set; }

        public bool Status { get; private set; }

        static Account()
        {
            _idGenerator = new AccountStringIdGenerator();
        }

        public void CreateAccount(Client client)
        {
            InputValidation(client);

            AccountOwner = client;
            Id = VerifiedId(client);
            Balance = 0m;
            Status = true;

            CreateTypeAccount(client);
        }

        protected abstract void CreateTypeAccount(Client client);

        public void CloseAccount()
        {
            Status = false;
        }

        public void WithdrawMoney(decimal money)
        {
            if (money <= 0)
            {
                throw new ArgumentException();
            }

            decimal expectedBalance = Balance - money + CalculateBenefitsPoints(-money);

            if (expectedBalance < 0 && !IsCreditAllowed(expectedBalance))
            {
                throw new InvalidOperationException(nameof(Balance));
            }

            Balance = expectedBalance;
        }

        public void DepositMoney(decimal money)
        {
            if (money <= 0)
            {
                throw new ArgumentException();
            }

            Balance += money + CalculateBenefitsPoints(money);
        }

        protected abstract decimal CalculateBenefitsPoints(decimal changeBalance);

        protected abstract bool IsCreditAllowed(decimal balance);

        private void InputValidation(Client client)
        {
            if (client is null)
            {
                throw new ArgumentNullException();
            }
        }

        private string VerifiedId(Client client)
        {
            string id;
            do
            {
                id = _idGenerator.CreateId(this);
            } while (!client.IsIdAccountUnique(id));

            return id;
        }
    }
}