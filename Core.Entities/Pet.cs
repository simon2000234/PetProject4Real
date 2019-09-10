using System;

namespace Core.Entities
{
    public class Pet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public Owner PreviousOwner { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return "The id is " + ID + " The name is " + Name + " it is a " + Type + " it was born on " + BirthDate.Date +
                   " it was last sold on " + SoldDate.Date + " its color is " + Color + " its previous owner was " +
                   PreviousOwner.Name + " and it cost " + Price;
        }
    }
}
