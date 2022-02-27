namespace ASP_WS.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Dog> Dogs { get; set; }

        public Owner()
        {
            Dogs = new List<Dog>();
        }

    }
}
