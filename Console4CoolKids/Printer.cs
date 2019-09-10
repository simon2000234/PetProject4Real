using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Transactions;
using Core.ApplicationService;
using Core.Entities;

namespace Console4CoolKids
{
    class Printer
    {
        private IPetService ps;
        private bool _isRunning = true;

        private string _mainmenuOptions = "1: Show all Pets \n" +
                                         "2: Show pets of a certain species \n" +
                                         "3: Create a Pet \n" +
                                         "4: Change a Pet \n" +
                                         "5: Sort Pets by price \n" +
                                         "6: Get 5 cheapest pets \n" +
                                         "7: Exit";
        public Printer(IPetService PetService)
        {
            ps = PetService;
        }

        public void run()
        {
            while (_isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Main Menu, Select one of the options bellow:");
                Console.WriteLine(_mainmenuOptions);

                string UserInput = Console.ReadLine();
                int ms;

                while (!int.TryParse(UserInput, out ms) || ms > 7 || ms < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Please only numbers between 1-7");
                    Console.WriteLine(_mainmenuOptions);
                    UserInput = Console.ReadLine();
                }

                switch (ms)
                {
                    case 1:
                        Console.WriteLine("Listing all pets \n" +
                                          "Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        foreach (var pet in ps.GetAllPets())
                        {
                            Console.WriteLine(pet + "\n");
                        }
                        Console.WriteLine("Pres enter to continue");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Going to search function \n" +
                                          "Press enter to continue");
                        Console.Clear();
                        Console.WriteLine("Please writer the type of pet you want to see");
                        string type = Console.ReadLine();

                        List<Pet> typePets = GetAllTypePets(type);
                        while (typePets.Count == 0)
                        {
                            Console.WriteLine("There are not pets of that type, try again");
                            type = Console.ReadLine();
                            typePets = GetAllTypePets(type);
                        }

                        foreach (var pet in typePets)
                        {
                            Console.WriteLine(pet + "\n");
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Creating a Pet \n" +
                                          "Press enter to continue");
                        Console.ReadLine();
                        CreatePet();
                        break;
                    case 4:
                        Console.WriteLine("Changing a pet \n" +
                                          "Press enter to continue");
                        Console.ReadLine();
                        UpdatePet();
                        break;
                    case 5:
                        Console.WriteLine("Sorting pets by price \n" +
                                          "Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        foreach (var pet in AllPetsOrderedByPrice())
                        {
                            Console.WriteLine(pet);
                            Console.WriteLine();
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Write("Showing the five cheapest pets \n" +
                                      "Pres enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        for (int i = 0; i < AllPetsOrderedByPrice().Count() && i < 5; i++)
                        {
                            Console.WriteLine(AllPetsOrderedByPrice().ToArray()[i]);
                            Console.WriteLine();
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("Program closing");
                        _isRunning = false;
                        break;

                }
            }

        }

        public List<Pet> GetAllTypePets(string type)
        {
            List<Pet> theList = new List<Pet>();
            foreach (var pet in ps.GetAllPets())
            {
                if (pet.Type.ToLower().Equals(type.ToLower()))
                {
                    theList.Add(pet);
                }
            }
            return theList;
        }

        public void CreatePet()
        {
            Console.Clear();
            Console.WriteLine("Please enter the name of the pet");
            string name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Please enter the species of the pet");
            string type = Console.ReadLine();

            DateTime birthday = DateTime.MinValue;
            bool canParseDate = false;
            while (!canParseDate)
            {

                Console.Clear();
                Console.WriteLine("Please enter the birthday of the pet \n" +
                                  "This most be done in the format of 01/12/2009 meaning the first of december 2009");
                try
                {
                    birthday = DateTime.Parse(Console.ReadLine());
                    canParseDate = true;
                }
                catch (Exception)
                {
                    canParseDate = false;
                    Console.WriteLine("You wrote in the wrong format, or a date that does not exist, please try again \n" +
                                      "Press enter to continue");
                    Console.ReadLine();
                }
            }

            DateTime saleday = DateTime.MinValue;
            canParseDate = false;
            while (!canParseDate)
            {

                Console.Clear();
                Console.WriteLine("Please enter the last sale day of the pet \n" +
                                  "This most be done in the format of 01/12/2009 meaning the first of december 2009");
                try
                {
                    saleday = DateTime.Parse(Console.ReadLine());
                    canParseDate = true;
                }
                catch (Exception)
                {
                    canParseDate = false;
                    Console.WriteLine("You wrote in the wrong format, or a date that does not exist, please try again \n" +
                                      "Press enter to continue");
                    Console.ReadLine();
                }
            }

            Console.Clear();
            Console.WriteLine("Please enter the color of the pet");
            string color = Console.ReadLine();


            Console.Clear();
            Console.WriteLine("Please enter the name of the previous owner");
            string previousOwner = Console.ReadLine();

            Console.Clear();
            double price;
            Console.WriteLine("Please enter the price of the pet in a number, you may use decimals");
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Enter a number dum dum");
            }

            Pet thePet = new Pet()
            {
                BirthDate = birthday,
                Color = color,
                ID = 0,
                Name = name,
                PreviousOwner = previousOwner,
                Price = price,
                SoldDate = saleday,
                Type = type
            };
            ps.AddPet(thePet);

        }

        public void UpdatePet()
        {
            Console.Clear();
            Console.WriteLine("Please enter the id of the pet that you wish to change");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please enter a whole number, please try again");
            }
            Pet thePet = ps.GetPet(id);
            while (thePet == null)
            {
                Console.WriteLine("No pet with that id exist please try again");
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Please enter a whole number, please try again");
                }
                thePet = ps.GetPet(id);
            }

            Console.Clear();
            Console.WriteLine("Please enter the name of the pet");
            string name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Please enter the species of the pet");
            string type = Console.ReadLine();

            DateTime birthday = DateTime.MinValue;
            bool canParseDate = false;
            while (!canParseDate)
            {

                Console.Clear();
                Console.WriteLine("Please enter the birthday of the pet \n" +
                                  "This most be done in the format of 01/12/2009 meaning the first of december 2009");
                try
                {
                    birthday = DateTime.Parse(Console.ReadLine());
                    canParseDate = true;
                }
                catch (Exception)
                {
                    canParseDate = false;
                    Console.WriteLine("You wrote in the wrong format, or a date that does not exist, please try again \n" +
                                      "Press enter to continue");
                    Console.ReadLine();
                }
            }

            DateTime saleday = DateTime.MinValue;
            canParseDate = false;
            while (!canParseDate)
            {

                Console.Clear();
                Console.WriteLine("Please enter the last sale day of the pet \n" +
                                  "This most be done in the format of 01/12/2009 meaning the first of december 2009");
                try
                {
                    saleday = DateTime.Parse(Console.ReadLine());
                    canParseDate = true;
                }
                catch (Exception)
                {
                    canParseDate = false;
                    Console.WriteLine("You wrote in the wrong format, or a date that does not exist, please try again \n" +
                                      "Press enter to continue");
                    Console.ReadLine();
                }
            }

            Console.Clear();
            Console.WriteLine("Please enter the color of the pet");
            string color = Console.ReadLine();


            Console.Clear();
            Console.WriteLine("Please enter the name of the previous owner");
            string previousOwner = Console.ReadLine();

            Console.Clear();
            double price;
            Console.WriteLine("Please enter the price of the pet in a number, you may use decimals");
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Enter a number dum dum");
                
            }

            thePet.Type = type;
            thePet.BirthDate = birthday;
            thePet.Color = color;
            thePet.Name = name;
            thePet.PreviousOwner = previousOwner;
            thePet.Price = price;
            thePet.SoldDate = saleday;

        }

        public IEnumerable<Pet> AllPetsOrderedByPrice()
        {
            IEnumerable<Pet> thePets = ps.GetAllPets().OrderBy(pet => pet.Price);
            return thePets;
        }
    }
}
