using AutoMapper;

using PetStore.Models;
using PetStore.Services.Models.Breeds.InputModels;
using PetStore.Services.Models.Breeds.OutputModels;

namespace PetStore.Mapping
{
    public class BreedProfile : Profile
    {
        public BreedProfile()
        {
            this.CreateMap<AddBreedInputModel, Breed>();

            this.CreateMap<Breed, GetBreedsOutputModel>();
        }
    }
}
