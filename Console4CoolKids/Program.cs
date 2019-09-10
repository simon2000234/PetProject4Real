using System;
using Core.ApplicationService.Impl;
using Infrastructure.Data.Repository;

namespace Console4CoolKids
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer printer = new Printer(new PetService(new PetRepository()));
            printer.run();
        }
    }
}
