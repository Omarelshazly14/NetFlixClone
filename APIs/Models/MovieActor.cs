using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models
{
    public class MovieActor
    {
        //Foreign Keys
        [ForeignKey("Movie")]
        [Key, Column(Order = 1)]
        public int Movie_Id { get; set; }

        [ForeignKey("Actor")]
        [Key, Column(Order = 2)]
        public int Actor_Id { get; set; }

        //Navigation Properties
        public virtual Movie Movie { get; set; }
        public virtual Actor Actor { get; set; }
    }
}
