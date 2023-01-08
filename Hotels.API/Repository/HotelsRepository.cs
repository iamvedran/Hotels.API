using Hotels.API.Contracts;
using Hotels.API.Data;
using System.Diagnostics.Metrics;
using GeoCoordinatePortable;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using NuGet.Common;
using AutoMapper;

namespace Hotels.API.Repository
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository    
    {
        private readonly HotelsDbContext _context;
        private readonly IMapper _mapper;

        public HotelsRepository(HotelsDbContext context, IMapper mapper) : base(context, mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        /// <summary>
        /// Find cheapest or nearest location
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="term">price (default), distance</param>
        /// <returns></returns>
        public Task<List<Hotel>> FindCheapestAndNearesHotel(double latitude, double longitude, string term="")
        {
            var hotels = _context.Hotels.AsNoTracking().OrderBy(p => p.Price);

            var result = new List<Hotel>();
            switch (term)
            {
                case "price":
                    result = hotels.ToList();
                    break;

                case "distance":
                    var coord = new GeoCoordinate(latitude, longitude);
                    var coordList = hotels.AsNoTracking().Select(x => new GeoCoordinate(x.Latutude, x.Longitude)).ToList();
                    var ordered = coordList.OrderBy(x => x.GetDistanceTo(coord)).ToList();

                    foreach (var item in ordered)
                    {
                        var a = item.GetDistanceTo(coord);
                        var r = hotels.FirstOrDefault(f => f.Longitude == item.Longitude && f.Latutude == item.Latitude);
                        if (r != null)
                        {
                            result.Add(r);
                        }
                    }
                    break;

                default:
                    result = hotels.ToList();
                    break;
            }


            return Task.FromResult(result);
        }



    }
}
