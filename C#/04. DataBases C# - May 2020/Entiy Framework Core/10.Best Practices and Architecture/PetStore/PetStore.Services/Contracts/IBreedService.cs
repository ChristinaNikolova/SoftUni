using System.Collections.Generic;

using PetStore.Services.Models.Breeds.InputModels;
using PetStore.Services.Models.Breeds.OutputModels;

namespace PetStore.Services.Contracts
{
    public interface IBreedService
    {
        void AddBreed(AddBreedInputModel model);

        IEnumerable<GetBreedsOutputModel> GetAllBreeds();

        bool RemoveById(int id);
    }
}
