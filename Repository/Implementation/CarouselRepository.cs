using Microsoft.EntityFrameworkCore;
using SecondAPIAngularAssignment.Data;
using SecondAPIAngularAssignment.Model;
using SecondAPIAngularAssignment.Repository.Interface;

namespace SecondAPIAngularAssignment.Repository.Implementation
{
    public class CarouselRepository: ICarouselRepository
    {
        private readonly EFDataContext dbContext;

        public CarouselRepository(EFDataContext dbContext)
        {
            this.dbContext = dbContext;            
        }

        public async Task<List<Carousel>> GetAllCarousel()
        {
            List<Carousel> lstCarousel = await dbContext.Carousels.ToListAsync();
            return lstCarousel;
        }

        public async Task<Carousel> CheckImageUrlExistsInCarousel(string imageUrl)
        {
            return await dbContext.Carousels.FirstOrDefaultAsync(a => a.ImageUrl == imageUrl);
        }

        public async Task<Carousel> AddedCarousel(Carousel carousel)
        {
            var result = await dbContext.Carousels.AddAsync(carousel);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public void DeletedCarousel(Carousel carousel)
        {
            dbContext.Carousels.Remove(carousel);
            dbContext.SaveChangesAsync();            
        }
    }
}
