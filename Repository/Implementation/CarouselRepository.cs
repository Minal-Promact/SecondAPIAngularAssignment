using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SecondAPIAngularAssignment.Data;
using SecondAPIAngularAssignment.DTO;
using SecondAPIAngularAssignment.Model;
using SecondAPIAngularAssignment.Repository.Interface;

namespace SecondAPIAngularAssignment.Repository.Implementation
{
    public class CarouselRepository: ICarouselRepository
    {
        private readonly EFDataContext dbContext;
        private readonly IMapper _iMapper;

        public CarouselRepository(EFDataContext dbContext,IMapper _iMapper)
        {
            this.dbContext = dbContext;
            this._iMapper = _iMapper;
        }

        public async Task<List<Carousel>> GetAllCarousel()
        {
            List<Carousel> lstCarousel = await dbContext.Carousels.OrderByDescending(x => x.Id).ToListAsync();
            return lstCarousel;
        }

        public async Task<Carousel> CheckImageUrlExistsInCarousel(string imageUrl)
        {
            return await dbContext.Carousels.FirstOrDefaultAsync(a => a.ImageUrl == imageUrl);
        }

        public async Task<Carousel> CheckIdExistsInCarousel(int id)
        {
            return await dbContext.Carousels.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Carousel> AddedCarousel(CarouselRequestDTO carouselRequestDTO)
        {
            var carousel = _iMapper.Map<CarouselRequestDTO, Carousel>(carouselRequestDTO);
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
