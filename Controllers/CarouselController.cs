using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondAPIAngularAssignment.Constants;
using SecondAPIAngularAssignment.Model;
using SecondAPIAngularAssignment.Repository.Interface;

namespace SecondAPIAngularAssignment.Controllers
{
    [EnableCors("AllowAngularOrigins")]
    [Route(Constant.Route)]
    [ApiController]
    public class CarouselController : ControllerBase
    {
        private readonly ICarouselRepository _iCarouselRepository;

        public CarouselController(ICarouselRepository iCarouselRepository)
        {
            this._iCarouselRepository = iCarouselRepository;
        }

        [HttpGet]
        [Route(Constant.GetAllCarousel)]
        public async Task<IActionResult> GetAllCarousel()
        {
            try
            {
                var carousel = await _iCarouselRepository.GetAllCarousel();
                if (carousel != null)
                {
                    return Ok(carousel);
                }
                return NotFound(Constant.RecordNotFound);

            }
            catch (Exception ex)
            {
                return StatusCode(Constant.InternalServerError, Constant.InternalServerErrorS);
            }
        }

        [HttpPost]
        [Route(Constant.AddCarousel)]
        public async Task<IActionResult> AddCarousel(Carousel carousel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var carouselRecord = await _iCarouselRepository.CheckImageUrlExistsInCarousel(carousel.ImageUrl);
                if (carouselRecord != null)
                {
                    return Conflict(Constant.TheRecordAlreadyExists);
                }

                var result = await _iCarouselRepository.AddedCarousel(carousel);

                return Created($"/{result.Id}", result);
            }
            catch (Exception ex)
            {
                return StatusCode(Constant.InternalServerError, Constant.InternalServerErrorS);
            }
        }

        [HttpDelete]
        [Route(Constant.DeleteCarousel)]
        public async Task<IActionResult> DeleteEmployee(string imageUrl)
        {
            try
            {
                if (imageUrl == string.Empty) return BadRequest(Constant.EnterImageUrl);

                var carouselRecord = await _iCarouselRepository.CheckImageUrlExistsInCarousel(imageUrl);
                if (carouselRecord != null)
                {
                    _iCarouselRepository.DeletedCarousel(carouselRecord);
                    return Ok();

                }
                return NotFound(Constant.TheKeyDoesNotExist);
            }
            catch (Exception ex)
            {
                return StatusCode(Constant.InternalServerError, Constant.InternalServerErrorS);
            }
        }
    }
}
