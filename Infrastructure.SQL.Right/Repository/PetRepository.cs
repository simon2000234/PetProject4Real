using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainService;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL.Right.Repository
{
    public class PetRepository : IPetRepository
    {
        private PetAppContext _context;

        public PetRepository(PetAppContext context)
        {
            _context = context;
        }
        public List<Pet> GetAllPets(Filter filter)
        {
            if (filter == null)
            {
                return _context.Pets.Include(o => o.PreviousOwners).ThenInclude(o => o.Owner).ToList();
            }

            return _context.Pets.
                Skip((filter.CurrentPage -1) * filter.ItemsPrPage).
                Take(filter.ItemsPrPage).
                Include(o => o.PreviousOwners).ThenInclude(o => o.Owner).ToList();
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
            var petOwnerSave = new List<PetOwner>(pet.PreviousOwners);

            _context.Attach(pet).State = EntityState.Modified;

            _context.PetsOwners.RemoveRange(_context.PetsOwners.Where(o => o.PetId == pet.ID));

            /*foreach (var pos in petOwnerSave)
            {
                _context.Entry(pos).State = EntityState.Added;
            } */

            _context.SaveChanges();
            return pet;
        }

        public int Count()
        {
            return _context.Pets.Count();
        }
    }
}
