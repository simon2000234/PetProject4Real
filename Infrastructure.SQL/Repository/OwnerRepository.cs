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

        public List<Owner> GetAllOwners()
        {
            return _context.Owners.ToList();
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
            throw new NotImplementedException();
        }
    }
}
