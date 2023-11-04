using System;
using System.Globalization;

using AutoMapper;

using PetStore.Models;
using PetStore.Models.Enums;
using PetStore.Services.Models.Pets.InputModels;
using PetStore.Services.Models.Pets.OutputModels;

namespace PetStore.Mapping
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            this.CreateMap<AddPetInputModel, Pet>()
                .ForMember(x => x.Breed.Name, y => y.MapFrom(x => x.Breed))
                .ForMember(x => x.Category.Name, y => y.MapFrom(x => x.Category))
                .ForMember(x => x.Gender, y => y.MapFrom(x => Enum.Parse(typeof(Gender), x.Gender)))
                .ForMember(x => x.DateOfBirth, y => y.MapFrom(x => DateTime.ParseExact(x.DateOfBirth, "d", CultureInfo.InvariantCulture)));

            this.CreateMap<Pet, GetPetsOutputModel>()
                .ForMember(x => x.Gender, y => y.MapFrom(x => x.Gender.ToString()))
                .ForMember(x => x.DateOfBirth, y => y.MapFrom(x => x.DateOfBirth.ToString("d", CultureInfo.InvariantCulture)))
                .ForMember(x => x.Breed, y => y.MapFrom(x => x.Breed.Name))
                .ForMember(x => x.Category, y => y.MapFrom(x => x.Category.Name));

            this.CreateMap<EditPetInputModel, Pet>()
                .ForMember(x => x.Breed.Name, y => y.MapFrom(x => x.Breed))
                .ForMember(x => x.Category.Name, y => y.MapFrom(x => x.Category))
                .ForMember(x => x.Gender, y => y.MapFrom(x => Enum.Parse(typeof(Gender), x.Gender)))
                .ForMember(x => x.DateOfBirth, y => y.MapFrom(x => DateTime.ParseExact(x.DateOfBirth, "d", CultureInfo.InvariantCulture)));
        }
    }
}
