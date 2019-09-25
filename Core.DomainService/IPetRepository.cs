using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.DomainService
{
    public interface IPetRepository
    {
        List<Pet> GetAllPets(Filter filter = null);

        Pet CreatePet(Pet pet);

        Pet RemovePet(int id);

        Pet UpdatePet(Pet pet);

        int Count();

    }
}
