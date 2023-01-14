using Hotels.API.Data;
using Hotels.API.Models;
using Hotels.API.Models.Hotel;

namespace Hotels.API.Contracts
{
    public interface IHotelsRepository : IGenericRepository<Hotel>
    {
        /// <summary>
        /// Find cheapest or nearest location
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="term">price (default), distance</param>
        /// <returns></returns>
        Task<PagedResult<HotelDTO>> FindCheapestAndNearesHotel(double latitude, double longitude, string term, QueryParameters queryParameters);
    }
}
