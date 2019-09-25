namespace Core.Entities
{
    public class PetOwner
    {
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}