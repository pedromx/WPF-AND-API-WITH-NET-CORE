using PROJECT.API.DTOs;

namespace PROJECT.API.Services
{
    public interface IStatisticsService
    {
        public StatisticsDTO GetTextStatistics(string text);
    }
}