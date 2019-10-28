using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.ApplicationService
{
    public interface IOwnerService
    {
        List<Owner> GetAllOwner();

        Owner GetOwner(int id);

        Owner AddOwner(Owner owner);

        Owner RemoveOwner(int id);

        Owner updateOwner(Owner owner);

        List<Owner> GetFilteredOwners(Filter filter);


    }
}
