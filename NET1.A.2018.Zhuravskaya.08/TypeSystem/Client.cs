using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TypeSystem.IGeneratorIdImplementations;
using TypeSystem.Interfaces;

namespace TypeSystem
{
    public sealed class Client
    {
        private IRepository<string, Account> _repository;

        private static readonly IGeneratorId<string, Client> _idGenerator;

        private static string _passportIdFormat;

        private static string _emailFormat;

        public string FirstName { get; }

        public string LastName { get; }

        public string Email { get; private set; }

        public string PassportId { get; }

        public string Id { get; }

        static Client()
        {
            _idGenerator = new ClientStringIdGenerator();
            _emailFormat = @" ^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            _passportIdFormat = @"(^MP[0-9]{7}$)|(^AB[0-9]{7}$)|(^BM[0-9]{7}$)|(^HB[0-9]{7}$)|(^AB[0-9]{7}$)|(^MC[0-9]{7}$)|(^KB[0-9]{7}$)|(^PP[0-9]{7}$)/";
        }

        public Client(string firstName, string lastName, string passportId, IRepository<string, Account> repository)
        {
            InputValidation(firstName, lastName, passportId, null, repository);

            FirstName = firstName;
            LastName = lastName;
            PassportId = passportId;
            Id = _idGenerator.CreateId(this);
            _repository = repository;
        }

        public Client(string firstName, string lastName, string passportId, string email, IRepository<string, Account> repository)
        {
            InputValidation(firstName, lastName, passportId, email, repository);

            FirstName = firstName;
            LastName = lastName;
            PassportId = passportId;
            Email = email;
            Id = _idGenerator.CreateId(this);
            _repository = repository;
        }

        public bool AddNewEmail(string email)
        {
            if (email is null)
            {
                throw new ArgumentNullException();
            }

            if (!Regex.IsMatch(email, _emailFormat))
            {
                throw new ArgumentException();
            }

            Email = email;

            return true;
        }

        public void AddAccount(Account account)
        {
            _repository.Create(account);
        }

        public void UpdateAccount(Account account)
        {
            if (account is null)
            {
                throw new ArgumentNullException();
            }
            account.CloseAccount();
            _repository.Update(account);
        }

        private void InputValidation(string firstName, string lastName, string passportId, string email, IRepository<string, Account> repository)
        {
            if (firstName is null || lastName is null || passportId is null || repository is null )
            {
                throw new ArgumentNullException();
            }

            if (!Regex.IsMatch(passportId, _passportIdFormat))
            {
                throw new ArgumentException();
            }

            if (!Equals(email, null) && !Regex.IsMatch(email, _emailFormat))
            {
                throw new ArgumentException();
            }
        }

        public bool IsIdAccountUnique(string id)
        {
            var accountWithTheSameId = _repository.GetBy(id);
            if (accountWithTheSameId is null)
            {
                return true;
            }

            return false;
        }

        public Account GetAccount(string accountId)
        {
            if (accountId is null)
            {
                throw new ArgumentNullException();
            }

            return _repository.GetBy(accountId);
        }
        /*
        public void AddAccount(Account bankAccount)
        {
            bankAccount.AccountHolder = AccountHolderID;
            _bankAccounts.Add(bankAccount);
        }*/
    }
}
