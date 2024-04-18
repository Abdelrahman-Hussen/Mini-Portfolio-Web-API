using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Application.Features.ReviewsSection.Abstractions;
using Portfolio.Domain.Features.ReviewsSection.Dtos;

namespace Portfolio.Controllers.ReviewsSection
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController(IReviewService _reviewService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<ReviewDto>>> Get([FromQuery] RequestModel request)
            => Ok(_reviewService.Get(request));

        [AllowAnonymous]
        [HttpGet("[action]")]
        public ActionResult<ResponseModel<List<ReviewDto>>> GetById(Guid Id)
            => Ok(_reviewService.GetById(Id));

        [HttpPost("[action]")]
        public async Task<ActionResult<ResponseModel<ReviewDto>>> Create([FromForm] CreateReviewDto Dto)
             => Ok(await _reviewService.Create(Dto));

        [HttpPut("[action]")]
        public async Task<ActionResult<ResponseModel<ReviewDto>>> Update([FromForm] UpdateReviewDto Dto)
             => Ok(await _reviewService.Update(Dto));

        [HttpDelete("[action]")]
        public async Task<ActionResult<ResponseModel<string>>> Delete([FromQuery] Guid Id)
             => Ok(await _reviewService.Delete(Id));
    }
}
