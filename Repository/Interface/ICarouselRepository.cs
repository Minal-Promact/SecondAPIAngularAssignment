using SecondAPIAngularAssignment.Model;

namespace SecondAPIAngularAssignment.Repository.Interface
{
    public interface ICarouselRepository 
    {
        Task<List<Carousel>> GetAllCarousel();
        Task<Carousel> CheckImageUrlExistsInCarousel(string imageUrl);
        Task<Carousel> AddedCarousel(Carousel carousel);
        void DeletedCarousel(Carousel carousel);
    }
}
