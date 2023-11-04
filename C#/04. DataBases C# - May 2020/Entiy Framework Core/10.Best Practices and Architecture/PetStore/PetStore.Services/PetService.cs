using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using PetStore.Common;
using PetStore.Data;
using PetStore.Models;
using PetStore.Services.Contracts;
using PetStore.Services.Models.Pets.InputModels;
using PetStore.Services.Models.Pets.OutputModels;

namespace PetStore.Services
{
    public class PetService : IPetService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public PetService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddPet(AddPetInputModel model)
        {
            Pet pet = this.mapper.Map<Pet>(model);

            this.dbContext.Pets.Add(pet);
            this.dbContext.SaveChanges();
        }

        public void EditPet(int id, EditPetInputModel model)
        {
            Pet newPet = this.mapper.Map<Pet>(model);

            Pet petToUpdate = this.dbContext
                .Pets
                .FirstOrDefault(p => p.Id == id);

            if (petToUpdate == null)
            {
                throw new ArgumentException(ExceptionMessages.PetNotFound);
            }

            petToUpdate.Name = newPet.Name;
            petToUpdate.Price = newPet.Price;
            petToUpdate.Gender = newPet.Gender;
            petToUpdate.IsSold = newPet.IsSold;
            petToUpdate.Breed.Name = newPet.Breed.Name;
            petToUpdate.Category.Name = newPet.Category.Name;
            petToUpdate.Desctiption = newPet.Desctiption;

            this.dbContext.Pets.Update(petToUpdate);
            this.dbContext.SaveChanges();
        }

        public IEnumerable<GetPetsOutputModel> GetAllPets()
        {
            List<GetPetsOutputModel> pets = this.dbContext
                 .Pets
                 .Where(p => p.IsSold == false)
                 .ProjectTo<GetPetsOutputModel>(this.mapper.ConfigurationProvider)
                 .OrderBy(p => p.Category)
                 .ThenBy(p => p.Breed)
                 .ThenBy(p => p.Price)
                 .ToList();

            return pets;
        }

        public IEnumerable<GetPetsOutputModel> GetAllPetsByBreed(string breedName)
        {
            List<GetPetsOutputModel> pets = this.dbContext
                .Pets
                .Where(p => p.IsSold == false
                    && p.Breed.Name == breedName)
                .ProjectTo<GetPetsOutputModel>(this.mapper.ConfigurationProvider)
                .OrderBy(p => p.Category)
                .ThenBy(p => p.Price)
                .ToList();

            return pets;
        }

        public IEnumerable<GetPetsOutputModel> GetAllPetsByCategory(string categoryName)
        {
            List<GetPetsOutputModel> pets = this.dbContext
               .Pets
               .Where(p => p.IsSold == false
                   && p.Category.Name == categoryName)
               .ProjectTo<GetPetsOutputModel>(this.mapper.ConfigurationProvider)
               .OrderBy(p => p.Breed)
               .ThenBy(p => p.Price)
               .ToList();

            return pets;
        }

        public bool RemoveById(int id)
        {
            Pet petToRemove = this.dbContext
                .Pets
                .FirstOrDefault(p => p.Id == id);

            if (petToRemove == null)
            {
                throw new ArgumentException(ExceptionMessages.PetNotFound);
            }

            this.dbContext.Pets.Remove(petToRemove);
            int affectedRows = this.dbContext.SaveChanges();

            bool isSuccessfull = affectedRows == 1;

            return isSuccessfull;
        }
    }
}
