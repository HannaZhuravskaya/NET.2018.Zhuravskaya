using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TypeSystem;
using TypeSystem.AccountImplementations;
using TypeSystem.IRepositoryImplementations;

namespace TypeSystemConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new AccountService(new ClientsRepository());
            service.AddNewClient("Hanna", "Zhuravskaya", "MP3421788");
            service.AddNewClient("Helen", "Markova", "MP1234567");
            //add email
            service.AddNewClient("Peter", "Marich", "MP1234000");
            service.AddNewClient("Veronika", "Naliboka", "MP1234567");

            var clientsCollection = service.GetClients();
            var clients = new List<Client>();
            var accountId = new List<string>();

            foreach (var client in clientsCollection)
            {
                clients.Add(client);
            }


            accountId.Add(service.OpenAccount(clients[0], new BaseAccount()));
            accountId.Add(service.OpenAccount(clients[1], new SilverAccount()));
            accountId.Add(service.OpenAccount(clients[2], new GoldAccount()));
            accountId.Add(service.OpenAccount(clients[3], new PlatinumAccount()));

            for(int i = 0; i < 4; ++i)
            {
                service.DepositAccount(clients[i].GetAccount(accountId[i]), (i + 50) * 3);
            }

            for (int i = 0; i < 4; ++i)
            {
                service.WithdrawAccount(clients[i].GetAccount(accountId[i]), 1000);
            }
        }
    }
}
