using AutoMapper;
using Hotels.API.Contracts;
using Hotels.API.Models.Hotel;
using Hotels.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotels.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHotelsRepository _hotelsRepository;

        public SearchController(IMapper mapper, IHotelsRepository hotelsRepository)
        {
            _mapper = mapper;
            _hotelsRepository = hotelsRepository;
        }

        /// <summary>
        /// Find cheapest or nearest location
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="term">price (default), distance</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PagedResult<HotelDTO>>> FindNearest(double latitude, double longitude, String? term, [FromQuery] QueryParameters queryParameters)
        {
            var pagedCountriesResult = await _hotelsRepository.FindCheapestAndNearesHotel(latitude, longitude, term, queryParameters);
            return Ok(pagedCountriesResult);
        }
    }
}
