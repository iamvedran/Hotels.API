using Hotels.API.Data;
using System.Diagnostics.Metrics;

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
        Task<List<Hotel>> FindCheapestAndNearesHotel(double latitude, double longitude, string term);
    }
}
