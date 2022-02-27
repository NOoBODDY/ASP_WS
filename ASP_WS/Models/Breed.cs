namespace ASP_WS.Models
{
    public class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Dog> Dogs { get; set; }
        
        public Breed()
        {
            Dogs = new List<Dog>();
        }
    }
}
