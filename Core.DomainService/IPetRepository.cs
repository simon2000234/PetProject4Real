using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.DomainService
{
    public interface IPetRepository
    {
        List<Pet> GetAllPets();

        Pet CreatePet(Pet pet);
    }
}
