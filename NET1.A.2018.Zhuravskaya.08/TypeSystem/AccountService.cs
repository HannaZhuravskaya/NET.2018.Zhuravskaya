using System;
using System.Collections.Generic;
using System.Linq;
using TypeSystem.Interfaces;
using TypeSystem.IRepositoryImplementations;

namespace TypeSystem
{
    public class AccountService
    {
        private IRepository<string, Client> _repository;

        public AccountService(IRepository<string, Client> repository)
        {
            _repository = repository;
        }

        public string OpenAccount(Client client, Account account)
        {
           account.CreateAccount(client);
           client.AddAccount(account);

            return account.Id;
        }

        public void CloseAccount(Account account)
        {
            account.CloseAccount();
        }

        public void WithdrawAccount(Account account, decimal money)
        {
            account.WithdrawMoney(money);
        }

        public void DepositAccount(Account account, decimal money)
        {
            account.DepositMoney(money);
        }

        public void AddNewClient(string firstName, string lastName, string passportId)
        {
            _repository.Create(new Client(firstName, lastName, passportId, new AccountsRepository()));
        }

        public void AddNewClient(string firstName, string lastName, string passportId, string email)
        {
            _repository.Create(new Client(firstName, lastName, passportId, email, new AccountsRepository()));
        }

        public IEnumerable<Client> GetClients()
        {
            var rep = _repository.GetAll();
            foreach (var client in rep)
            {
                yield return client;
            }
        }
    }
}