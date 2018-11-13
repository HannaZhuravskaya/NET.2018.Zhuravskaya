using System;
using TypeSystem.Interfaces;

namespace TypeSystem.IGeneratorIdImplementations
{
    class ClientStringIdGenerator : IGeneratorId<string, Client>
    {
        public string CreateId(Client owner)
        {
            return owner.FirstName + owner.LastName + owner.PassportId;
        }

        object IGeneratorId.CreateId(object owner)
        {
            if (owner is null)
            {
                throw new ArgumentNullException();
            }

            var client = owner as Client;

            if (client is null)
            {
                throw new ArgumentException();
            }

            return CreateId(client);
        }
    }
}