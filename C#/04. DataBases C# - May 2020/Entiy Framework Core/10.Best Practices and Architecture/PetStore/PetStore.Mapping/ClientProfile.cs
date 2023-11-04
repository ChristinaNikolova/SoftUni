using AutoMapper;

using PetStore.Models;
using PetStore.Services.Models.Clients.InputModels;

namespace PetStore.Mapping
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            this.CreateMap<RegisterClientInputModel, Client>();

            this.CreateMap<EditClientProfileInputModel, Client>();
        }
    }
}
