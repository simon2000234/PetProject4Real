using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainService;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL.Repository
{
    public class OwnerRepository: IOwnerRepository
    {
        private PetAppContext _context;

        public OwnerRepository(PetAppContext context)
        {
            _context = context;
        }

        public List<Owner> GetAllOwners(Filter filter)
        {
            if (filter.CurrentPage == 0 && filter.ItemsPrPage == 0)
            {
                return _context.Owners.Include(o => o.OwnedPets).ThenInclude(o => o.Pet).ToList();
            }

            return _context.Owners.
                Skip((filter.CurrentPage - 1) * filter.ItemsPrPage).
                Take(filter.ItemsPrPage).
                Include(o => o.OwnedPets).ThenInclude(o => o.Pet).ToList();
        }

        public Owner CreateOwner(Owner owner)
        {
            _context.Attach(owner).State = EntityState.Added;
            _context.SaveChanges();
            return owner;
        }

        public Owner RemoveOwner(int Id)
        {
            var owner = _context.Remove(new Owner { Id = Id }).Entity;
            _context.SaveChanges();
            return owner;
        }

        public Owner UpdateOwner(Owner owner)
        {
            var petOwnerSave = new List<PetOwner>(owner.OwnedPets);

            _context.Attach(owner).State = EntityState.Modified;

            _context.PetsOwners.RemoveRange(_context.PetsOwners.Where(o => o.OwnerId == owner.Id));

            foreach (var pos in petOwnerSave)
            {
                _context.Entry(pos).State = EntityState.Added;
            }

            _context.SaveChanges();

            return owner;
        }

        public int Count()
        {
            return _context.Owners.Count();
        }
    }
}
