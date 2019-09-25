using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PetOwner> OwnedPets { get; set; }

    }
}
