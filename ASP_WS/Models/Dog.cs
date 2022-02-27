namespace ASP_WS.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public string AvatarPath { get; set;}

        public int BreedId { get; set; }
        public Breed? Breed { get; set; }
        
        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }
}
