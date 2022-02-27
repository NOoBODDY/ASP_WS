namespace ASP_WS.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Breed Breed { get; set; }
        public DateTime Birthday { get; set; }

        public Owner Owner { get; set; }
    }
}
