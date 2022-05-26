namespace APIs.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign Keys


        //Navigation Properties
        public virtual List<Movie> Movies { get; set; }
    }
}
