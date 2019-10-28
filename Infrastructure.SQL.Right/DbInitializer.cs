using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infrastructure.SQL.Right
{
    public class DbInitializer
    {
        public static void SeedDB(PetAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var owner1 = ctx.Owners.Add(new Owner()
            {
                Name = "John Hitler"
            }).Entity;

            var owner2 = ctx.Owners.Add(new Owner()
            {
                Name = "Rigtig Brian"
            }).Entity;

            var pet1 = ctx.Pets.Add(new Pet()
            {
                BirthDate = DateTime.Now,
                Price = 1,
                SoldDate = DateTime.MinValue,
                Name = "DinMor",
                Color = "Black",
                Type = "Human",
                PreviousOwners = new List<PetOwner>
                {
                    new PetOwner()
                    {
                        Owner = owner1
                    },
                    new PetOwner()
                    {
                        Owner = owner2
                    }
                }
            }).Entity;
            string password = "password";
            byte[] passwordHashUserOne, passwordSaltUserOne, passwordHashUserTwo, passwordSaltUserTwo;

            CreatePasswordHash(password, out passwordHashUserOne, out passwordSaltUserOne);
            CreatePasswordHash(password, out passwordHashUserTwo, out passwordSaltUserTwo);

            var userNormal = ctx.Users.Add(new User()
            {
               IsAdmin = false,
               Username = "DabNormal",
               PasswordSalt = passwordSaltUserOne,
               PasswordHash = passwordHashUserOne
            }).Entity;

            var userAdmin = ctx.Users.Add(new User()
            {
                IsAdmin = true,
                Username = "DabAdmin",
                PasswordSalt = passwordSaltUserTwo,
                PasswordHash = passwordHashUserTwo
            }).Entity;
            ctx.SaveChanges();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
