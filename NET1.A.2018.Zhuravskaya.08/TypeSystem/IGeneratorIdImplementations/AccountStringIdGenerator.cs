using System;
using TypeSystem.Interfaces;

namespace TypeSystem.IGeneratorIdImplementations
{
    class AccountStringIdGenerator : IGeneratorId<string, Account>
    {
        public string CreateId(Account owner)
        {
            return owner.AccountOwner.Id + new Random().Next();
        }

        object IGeneratorId.CreateId(object owner)
        {
            if (owner is null)
            {
                throw new ArgumentNullException();
            }

            var account = owner as Account;

            if (account is null)
            {
                throw new ArgumentException();
            }

            return CreateId(account);
        }
    }
}