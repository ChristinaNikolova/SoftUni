using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.Services.Contracts;
using PetStore.Services.Models.Breeds.InputModels;
using PetStore.Services.Models.Breeds.OutputModels;

namespace PetStore.Services
{
    public class BreedService : IBreedService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public BreedService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public void AddBreed(AddBreedInputModel model)
        {
            Breed breed = this.mapper.Map<Breed>(model);

            this.dbContext.Breeds.Add(breed);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<GetBreedsOutputModel> GetAllBreeds()
        {
            List<GetBreedsOutputModel> breeds = this.dbContext
                .Breeds
                .ProjectTo<GetBreedsOutputModel>(this.mapper.ConfigurationProvider)
                .OrderBy(x => x.Name)
                .ToList();

            return breeds;
        }

        public bool RemoveById(int id)
        {
            Breed breedToRemove = this.dbContext
                .Breeds
                .FirstOrDefault(p => p.Id == id);

            if (breedToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.BreedNotFound);
            }

            this.dbContext.Breeds.Remove(breedToRemove);
            int affectedRows = this.dbContext.SaveChanges();

            bool isSuccessfull = affectedRows == 1;

            return isSuccessfull;
        }
    }
}
