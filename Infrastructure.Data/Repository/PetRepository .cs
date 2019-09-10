using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainService;
using Core.Entities;

namespace Infrastructure.Data.Repository
{
    public class PetRepository: IPetRepository
    {
        private static List<Pet> theList = FakeAsFuckDataBase.listPets.ToList();
        public PetRepository()
        {
        }
        public List<Pet> GetAllPets()
        {
            return theList;
        }

        public Pet CreatePet(Pet pet)
        {
            pet.ID = FakeAsFuckDataBase.id++;
            return pet;
        }
    }
}
