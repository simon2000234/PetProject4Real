using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.DomainService
{
    public interface IOwnerRepository
    {
        List<Owner> GetAllOwners();

        Owner CreateOwner(Owner owner);
    }
}
