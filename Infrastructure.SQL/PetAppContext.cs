using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL
{
    public class PetAppContext: DbContext
    {

        public PetAppContext(DbContextOptions opt) : base(opt)
        {
            
        }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Owner> Owners { get; set; }

    }
}
