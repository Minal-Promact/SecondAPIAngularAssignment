using System.ComponentModel.DataAnnotations;

namespace SecondAPIAngularAssignment.DTO
{
    public class CarouselRequestDTO
    {
        [Required(ErrorMessage = "Please Enter Image Url.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please Enter Slide Caption.")]
        public string SlideCaption { get; set; }
    }
}
