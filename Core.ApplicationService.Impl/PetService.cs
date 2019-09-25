using System;
using System.Collections.Generic;
using System.IO;
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

        public Pet RemovePet(int id)
        {
            return petRepository.RemovePet(id);
            /**
            Pet thePet = petRepository.GetAllPets().FirstOrDefault(pet => pet.ID == id);
            petRepository.GetAllPets().Remove(GetPet(id));
            return thePet;**/
        }

        public Pet UpdatePer(Pet pet)
        {
            return petRepository.UpdatePet(pet);
        }

        public List<Pet> GetFilteredPets(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("Current page and items pr page must be more than 0 or 0");
            }

            if ((filter.CurrentPage - 1) * filter.ItemsPrPage >= petRepository.Count())
            {
                throw new InvalidDataException("Index out of bound to high page");
            }
            return petRepository.GetAllPets(filter);
        }
    }
}
