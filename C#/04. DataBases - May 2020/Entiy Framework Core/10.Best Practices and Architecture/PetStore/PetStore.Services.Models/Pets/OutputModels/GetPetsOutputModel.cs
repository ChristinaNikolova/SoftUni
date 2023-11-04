namespace PetStore.Services.Models.Pets.OutputModels
{
    public class GetPetsOutputModel
    {
        public string Name { get; set; }

        public string Gender { get; set; }

        public string DateOfBirth { get; set; }

        public decimal Price { get; set; }

        public string Desctiption { get; set; }

        public virtual string Breed { get; set; }

        public virtual string Category { get; set; }
    }
}
