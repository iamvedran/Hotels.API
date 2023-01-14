
using AutoMapper;
using Hotels.API.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotels.API.Data;
using Hotels.API.Models.Hotel;
using Hotels.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace Hotels.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HotelsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHotelsRepository _hotelsRepository;
        private readonly ILogger<HotelsController> _logger;

        public HotelsController( IMapper mapper, IHotelsRepository hotelsRepository, ILogger<HotelsController> logger)
        {
            _mapper = mapper;
            _hotelsRepository = hotelsRepository;
            _logger = logger;
        }

        // GET: api/Hotels
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            var hotels = await _hotelsRepository.GetAllAsync();
            return Ok(hotels);
        }

        // GET: api/Countries/?StartIndex=0&pagesize=3&PageNumber=1
        [HttpGet]
        public async Task<ActionResult<PagedResult<HotelDTO>>> GetPagedHotels([FromQuery] QueryParameters queryParameters)
        {
            var pagedCountriesResult = await _hotelsRepository.GetAllAsync<HotelDTO>(queryParameters);
            return Ok(pagedCountriesResult);
        }


        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            var hotel = await _hotelsRepository.GetAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        // PUT: api/Hotels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, UpdateHotelDTO updateHotel)
        {
            if (id != updateHotel.Id)
            {
                return BadRequest("Invalid record");
            }

            var record = await _hotelsRepository.GetAsync(id);

            if (record == null)
            {
                return NotFound();
            }

            _mapper.Map(updateHotel, record);

            try
            {
                await _hotelsRepository.UpdateAsync(record);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await HotelExists(id))
                {
                    _logger.LogWarning($"No records found in hotel update {id}");
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex, $"Error in Hotel update {id}");
                    return Problem($"Error in Hotel update {id}", statusCode: 500);
                }
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(HotelDTO createHotel)
        {
            //Hotel hotel = new Hotel
            //{
            //    Name = hotel.Name,
            //    Price = hotel.Price,
            //    Latutude = hotel.Latutude,
            //    Longitude = hotel.Longitude
            //};

            Hotel hotel = _mapper.Map<Hotel>(createHotel);

            await _hotelsRepository.AddAsync(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var hotel = await _hotelsRepository.GetAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }

            await _hotelsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> HotelExists(int id)
        {
            return await _hotelsRepository.Exists(id);
        }
    }
}
