namespace PetStore.Common
{
    public static class GlobalConstants
    {
        //Breed
        public const int BreedMinNameLen = 5;
        public const int BreedMaxNameLen = 100;

        //Category
        public const int CategoryMinNameLen = 5;
        public const int CategoryMaxNameLen = 100;
        public const int CategoryDescriptionMaxLen = 1000;

        //Client
        public const int ClientMinNameLen = 3;
        public const int ClientMaxNameLen = 100;
        public const int ClientMinPasswordLen = 8;
        public const int ClientMaxPasswordLen = 100;

        //ClientProduct
        public const double MinQuantity = 1;
        public const double MaxQuantity = 200;

        //Order
        public const int AddressMixNameLen = 10;
        public const int AddressMaxNameLen = 100;
        public const int NoteMaxLen = 1000;

        //Pet
        public const int PetMinNameLen = 2;
        public const int PetMaxNameLen = 100;
        public const double PetMinPrice = 1;
        public const double petMaxPrice = 10000;
        public const int PetDescriptionMaxLen = 1000;

        //Product
        public const int ProductMinNameLen = 3;
        public const int ProductMaxNameLen = 100;
        public const double ProductMinPrice = 0.10;
        public const double ProductMaxPrice = 10000;
        public const int ProductDescriptionMaxLen = 1000;
    }
}
