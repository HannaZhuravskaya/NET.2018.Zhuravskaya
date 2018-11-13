using System;
using System.Collections;
using System.Collections.Generic;
using TypeSystem.Interfaces;

namespace TypeSystem.IRepositoryImplementations
{
    public class AccountsRepository : IRepository<string, Account>
    {
        private Dictionary<string, Account> _repository = new Dictionary<string, Account>();

        public Account GetBy(string key)
        {
            foreach (var account in _repository)
            {
                if (account.Key.Equals(key))
                {
                    return account.Value;
                }
            }

            return null;
        }

        public bool Create(Account source)
        {
            InputValidation(source);

            if (!_repository.ContainsKey(source.Id))
            {
                _repository[source.Id] = source;
                return true;
            }

            return false;
        }

        public bool Update(Account source)
        {
            InputValidation(source);

            if (_repository.ContainsKey(source.Id))
            {
                _repository[source.Id] = source;
                return true;
            }

            return false;
        }

        public IEnumerable<Account> GetAll()
        {
            foreach (var account in _repository)
            {
                yield return account.Value;
            }
        }

        bool IRepository.Create(object source)
        {
            SourceTypeInputValidation(source);

            return Create((Account)source);
        }

        bool IRepository.Update(object source)
        {
            SourceTypeInputValidation(source);
            
            return Update((Account)source);
        }

        IEnumerable IRepository.GetAll()
        {
            return GetAll();
        }

        private void InputValidation(Account account)
        {
            if (account is null)
            {
                throw new ArgumentNullException();
            }
        }

        private void SourceTypeInputValidation(object source)
        {
            if (source is null)
            {
                throw  new ArgumentNullException();
            }

            if (!(source is Account account))
            {
                throw new ArgumentException();
            }
        }
    }
}