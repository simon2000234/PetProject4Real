using System;
using System.Collections.Generic;
using System.Linq;
using Core.DomainService;
using Core.Entities;

namespace Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        private IPetRepository petRepository;

        public PetService(IPetRepository petRepository)
        {
            this.petRepository = petRepository;
        }

        public List<Pet> GetAllPets()
        {
            return petRepository.GetAllPets();
        }

        public Pet GetPet(int id)
        {
            Pet thePet = petRepository.GetAllPets().FirstOrDefault(pet => pet.ID == id);
            if (thePet == null)
            {
                throw new System.NullReferenceException();
            }
            return thePet;
        }

        public Pet AddPet(Pet pet)
        {
            Pet thePet = petRepository.CreatePet(pet);
            petRepository.GetAllPets().Add(thePet);
            return thePet;
        }

        public void RemovePet(int id)
        {
            petRepository.GetAllPets().Remove(GetPet(id));
        }
    }
}
