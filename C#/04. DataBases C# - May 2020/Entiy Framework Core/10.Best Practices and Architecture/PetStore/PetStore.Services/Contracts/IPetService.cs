using System.Collections.Generic;

using PetStore.Services.Models.Pets.InputModels;
using PetStore.Services.Models.Pets.OutputModels;

namespace PetStore.Services.Contracts
{
    public interface IPetService
    {
        void AddPet(AddPetInputModel model);

        IEnumerable<GetPetsOutputModel> GetAllPets();

        IEnumerable<GetPetsOutputModel> GetAllPetsByCategory(string categoryName);

        IEnumerable<GetPetsOutputModel> GetAllPetsByBreed(string breedName);

        bool RemoveById(int id);

        void EditPet(int id, EditPetInputModel model);
    }
}
