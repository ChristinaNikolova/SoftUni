using System;

using AutoMapper;

using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.Services.Contracts;
using PetStore.Services.Models.Clients.InputModels;

namespace PetStore.Services
{
    public class ClientService : IClientService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public ClientService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void EditProfile(int id, EditClientProfileInputModel model)
        {
            Client newClient = this.mapper.Map<Client>(model);

            Client clientToUpdate = this.dbContext
                .Clients
                .Find(id);

            if (clientToUpdate == null)
            {
                throw new ArgumentException(ExceptionMessages.ClientNotFound);
            }

            clientToUpdate.Password = newClient.Password;
            clientToUpdate.Email = newClient.Email;
            clientToUpdate.FirstName = newClient.FirstName;
            clientToUpdate.LastName = newClient.LastName;

            this.dbContext.Clients.Update(clientToUpdate);
            this.dbContext.SaveChanges();
        }

        public void Register(RegisterClientInputModel model)
        {
            Client client = this.mapper.Map<Client>(model);

            this.dbContext.Clients.Add(client);
            this.dbContext.SaveChanges();
        }
    }
}
