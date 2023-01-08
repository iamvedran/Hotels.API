using Hotels.API.Contracts;
using Hotels.API.Data;
using System.Diagnostics.Metrics;
using GeoCoordinatePortable;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;

namespace Hotels.API.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository    
    {
        private readonly HotelsDbContext _context;

        public HotelsRepository(HotelsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> FindCheapestAndNearesHotel(double latitude, double longitude)
        {
            var coord = new GeoCoordinate(latitude, longitude);
            var nearest = _context.Hotels.Select(x => new GeoCoordinate(x.Latutude, x.Longitude))
                .OrderBy(x => x.GetDistanceTo(coord))
                .ToListAsync();
            return await _context.Hotels.ToListAsync();
        }

       
    }
}
