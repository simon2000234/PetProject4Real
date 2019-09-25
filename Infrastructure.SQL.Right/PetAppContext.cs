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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Pet>()
                .HasMany(p => p.PreviousOwners);
            modelBuilder.Entity<Owner>()
                .HasMany(o => o.OwnedPets);*/

            modelBuilder.Entity<PetOwner>().HasKey(po => new
            {
                po.OwnerId,
                po.PetId
            });

            modelBuilder.Entity<PetOwner>().
                HasOne(po => po.Owner).
                WithMany(o => o.OwnedPets).
                HasForeignKey(po => po.OwnerId);

            modelBuilder.Entity<PetOwner>().
                HasOne(po => po.Pet).
                WithMany(p => p.PreviousOwners).
                HasForeignKey(po => po.PetId);
        }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<PetOwner> PetsOwners { get; set; }

    }
}
