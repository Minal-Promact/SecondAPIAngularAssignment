using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SecondAPIAngularAssignment.Model
{
    public class Carousel
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string SlideCaption { get; set; }
    }
}
