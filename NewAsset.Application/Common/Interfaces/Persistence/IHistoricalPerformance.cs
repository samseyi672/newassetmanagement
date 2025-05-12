

namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface IHistoricalPerformance
    {
        IEnumerable<HistoricalPerformance> GetAllHistoricalPerformance();
        HistoricalPerformance GetHistoricalPerformanceByUserName(string userName);
        void AddHistoricalPerformance(HistoricalPerformance historicalPerformance);
        void UpdateHistoricalPerformance(HistoricalPerformance historicalPerformance);
        void DeleteHistoricalPerformance(int id);
    }
}
