using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetAllPets();

        Pet GetPet(int id);

        Pet AddPet(Pet pet);

        Pet RemovePet(int id);

        Pet UpdatePer(Pet pet);

        List<Pet> GetFilteredPets(Filter filter);
    }
}
