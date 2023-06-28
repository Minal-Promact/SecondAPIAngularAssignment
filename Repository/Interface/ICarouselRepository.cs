using SecondAPIAngularAssignment.DTO;
using SecondAPIAngularAssignment.Model;

namespace SecondAPIAngularAssignment.Repository.Interface
{
    public interface ICarouselRepository 
    {
        Task<List<Carousel>> GetAllCarousel();
        Task<Carousel> CheckImageUrlExistsInCarousel(string imageUrl);
        Task<Carousel> CheckIdExistsInCarousel(int id);
        Task<Carousel> AddedCarousel(CarouselRequestDTO carousel);
        void DeletedCarousel(Carousel carousel);
    }
}
