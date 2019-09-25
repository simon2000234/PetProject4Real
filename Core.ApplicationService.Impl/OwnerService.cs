using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DomainService;
using Core.Entities;

namespace Core.ApplicationService.Impl
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public List<Owner> GetAllOwner()
        {
            return _ownerRepository.GetAllOwners();
        }

        public Owner GetOwner(int id)
        {
            Owner theOwner = _ownerRepository.GetAllOwners().FirstOrDefault(owner => owner.Id == id);
            if (theOwner == null)
            {
                throw new System.NullReferenceException();
            }

            return theOwner;
        }

        public Owner AddOwner(Owner owner)
        {
            Owner theOwner = _ownerRepository.CreateOwner(owner);
            _ownerRepository.GetAllOwners().Add(theOwner);
            return theOwner;
        }

        public Owner RemoveOwner(int id)
        {
            return _ownerRepository.RemoveOwner(id);
            /**
            Owner theOwner = GetOwner(id);
            _ownerRepository.GetAllOwners().Remove(theOwner);
            return theOwner;**/
        }

        public Owner updateOwner(Owner owner)
        {
            return _ownerRepository.UpdateOwner(owner);
        }

        public List<Owner> GetFilteredPets(Filter filter)
        {
            throw new NotImplementedException();
        }
    }
}
