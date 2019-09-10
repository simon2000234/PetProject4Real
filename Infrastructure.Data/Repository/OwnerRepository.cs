using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainService;
using Core.Entities;

namespace Infrastructure.Data.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private static List<Owner> theList = FakeAsFuckDataBase.listOwners.ToList();
        public List<Owner> GetAllOwners()
        {
            return theList;
        }

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = FakeAsFuckDataBase.id++;
            return owner;
        }
    }
}
