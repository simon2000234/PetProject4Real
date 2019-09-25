using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainService;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL.Repository
{
    class PetRepository : IPetRepository
    {
        private PetAppContext _context;

        public PetRepository(PetAppContext context)
        {
            _context = context;
        }
        public List<Pet> GetAllPets()
        {
            return _context.Pets.ToList();
        }

        public Pet CreatePet(Pet pet)
        {

            _context.Attach(pet).State = EntityState.Added;
            _context.SaveChanges();
            return pet;
        }

        public Pet RemovePet(int id)
        {
            var pet = _context.Remove(new Pet{ID = id}).Entity;
            _context.SaveChanges();
            return pet;
        }

        public Pet UpdatePet(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
