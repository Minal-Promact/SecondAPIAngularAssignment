using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondAPIAngularAssignment.Constants;
using SecondAPIAngularAssignment.DTO;
using SecondAPIAngularAssignment.Model;
using SecondAPIAngularAssignment.Repository.Interface;

namespace SecondAPIAngularAssignment.Controllers
{
    [Route("api/[controller]")]
    public class CarouselController : ControllerBase
    {
        private readonly ICarouselRepository _iCarouselRepository;

        public CarouselController(ICarouselRepository iCarouselRepository)
        {
            this._iCarouselRepository = iCarouselRepository;
        }

        [HttpGet]        
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
        
        public async Task<IActionResult> AddCarousel([FromBody] CarouselRequestDTO carouselRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var carouselRecord = await _iCarouselRepository.CheckImageUrlExistsInCarousel(carouselRequestDTO.ImageUrl);
                if (carouselRecord != null)
                {
                    return Conflict(Constant.TheRecordAlreadyExists);
                }

                var result = await _iCarouselRepository.AddedCarousel(carouselRequestDTO);

                return Created($"/{result.Id}", result);
            }
            catch (Exception ex)
            {
                return StatusCode(Constant.InternalServerError, Constant.InternalServerErrorS);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarousel(int id)
        {
            try
            {
                if (id == 0) return BadRequest(Constant.EnterId);

                var carouselRecord = await _iCarouselRepository.CheckIdExistsInCarousel(id);
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
