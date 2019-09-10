using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;

namespace Infrastructure.Data
{
    public class FakeAsFuckDataBase
    {
        internal static int id = 1;

        internal static int ownerId = 1;

        internal static IEnumerable<Owner> listOwners = makeAOwner();

        internal static IEnumerable<Pet> listPets = makeAFewPets();


        internal static List<Owner> makeAOwner()
        {
            List<Owner> listOwner = new List<Owner>();
            var owner = new Owner
            {
                Name = "John Hitler",
                Id = 42069
            };
            listOwner.Add(owner);
            return listOwner;
        }

        internal static List<Pet> makeAFewPets()
        {
            List<Pet> listPets = new List<Pet>();
            var pet1 = new Pet
            {
                ID = 666,
                BirthDate = DateTime.Now,
                Price = 1,
                SoldDate = DateTime.MinValue,
                Name = "DinMor",
                Color = "Black",
                PreviousOwner = listOwners.ToList().Find(own => own.Id == 42069),
                Type = "Human"
            };
            listPets.Add(pet1);
            var pet2 = new Pet
            {
                BirthDate = DateTime.MinValue,
                Color = "Pink",
                ID = 420,
                Name = "Dab Master",
                PreviousOwner = listOwners.ToList().Find(own => own.Id == 42069),
                Price = 69.69,
                SoldDate = DateTime.MaxValue,
                Type = "Fish"
            };
            listPets.Add(pet2);

            return listPets;
        }
    };

   
}

