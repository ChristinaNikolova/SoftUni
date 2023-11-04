using PetStore.Services.Models.Clients.InputModels;

namespace PetStore.Services.Contracts
{
    public interface IClientService
    {
        void Register(RegisterClientInputModel model);

        void EditProfile(int id, EditClientProfileInputModel model);
    }
}
