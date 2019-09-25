using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.DomainService
{
    public interface IOwnerRepository
    {
        List<Owner> GetAllOwners(Filter filter = null);

        Owner CreateOwner(Owner owner);

        Owner RemoveOwner(int Id);

        Owner UpdateOwner(Owner owner);

        int Count();
    }
}
