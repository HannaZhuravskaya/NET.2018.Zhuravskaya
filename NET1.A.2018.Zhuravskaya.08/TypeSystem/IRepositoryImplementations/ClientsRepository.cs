using System;
using System.Collections;
using System.Collections.Generic;
using TypeSystem.Interfaces;

namespace TypeSystem.IRepositoryImplementations
{
    public class ClientsRepository : IRepository<string, Client>
    {
        private Dictionary<string, Client> _repository = new Dictionary<string, Client>();

        public Client GetBy(string key)
        {
            foreach (var client in _repository)
            {
                if (client.Key.Equals(key))
                {
                    return client.Value;
                }
            }

            return null;
        }

        public bool Create(Client source)
        {
            InputValidation(source);

            if (!_repository.ContainsKey(source.Id))
            {
                _repository[source.Id] = source;
                return true;
            }

            return false;
        }

        public bool Update(Client source)
        {
            InputValidation(source);

            if (_repository.ContainsKey(source.Id))
            {
                _repository[source.Id] = source;
                return true;
            }

            return false;
        }

        public IEnumerable<Client> GetAll()
        {
            foreach (var client in _repository)
            {
                yield return client.Value;
            }
        }

        bool IRepository.Create(object source)
        {
            SourceTypeInputValidation(source);

            return Create((Client)source);
        }

        bool IRepository.Update(object source)
        {
            SourceTypeInputValidation(source);

            return Update((Client)source);
        }

        IEnumerable IRepository.GetAll()
        {
            return GetAll();
        }

        private void InputValidation(Client client)
        {
            if (client is null)
            {
                throw new ArgumentNullException();
            }
        }

        private void SourceTypeInputValidation(object source)
        {
            if (source is null)
            {
                throw new ArgumentNullException();
            }

            if (!(source is Client client))
            {
                throw new ArgumentException();
            }
        }
    }
}