using AutoMapper;
using Hotels.API.Contracts;
using Hotels.API.Data;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> FindNearest(double latitude, double longitude, String? term)
        {
            var hotels = await _hotelsRepository.FindCheapestAndNearesHotel(latitude, longitude, term);
            return Ok(hotels);
        }
    }
}
