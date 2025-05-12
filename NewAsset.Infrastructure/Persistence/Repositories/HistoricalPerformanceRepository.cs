using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAsset.Infrastructure.Persistence.Repositories
{
    public class HistoricalPerformanceRepository : IHistoricalPerformance
    {
        private readonly AppDbContext _context;
        public HistoricalPerformanceRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddHistoricalPerformance(HistoricalPerformance historicalPerformance)
        {
            var existingHistoricalPerformance = _context.HistoricalPerformances.FirstOrDefault(u => u.Id == historicalPerformance.Id);
            if (existingHistoricalPerformance != null)
            {
                _context.Entry(existingHistoricalPerformance).CurrentValues.SetValues(historicalPerformance);
            }
            else
            {
                _context.HistoricalPerformances.Add(historicalPerformance); // new entities
            }
            _context.SaveChanges();
        }

        public void DeleteHistoricalPerformance(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HistoricalPerformance> GetAllHistoricalPerformance()
        {
            return _context.HistoricalPerformances;
        }

        public HistoricalPerformance GetHistoricalPerformanceByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public void UpdateHistoricalPerformance(HistoricalPerformance historicalPerformance)
        {
            throw new NotImplementedException();
        }
    }
}
