namespace APIs.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign Keys


        //Navigation Properties
        public virtual List<MovieActor> ActorMovies { get; set; }
    }
}
