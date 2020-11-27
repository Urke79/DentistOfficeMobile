using MobileApp.API.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileApp.API.Data.Repositories
{
    public class InterventionRepository : BaseRepository<Intervention>, IInterventionRepository
    {
        public IEnumerable<Intervention> GetInterventions(int clientId)
        {
            using (var db = new AppDbContext())
            {
                return db.Interventions.Where(i => i.ClientId == clientId).ToList();
            }
        }

        public decimal GetPayedAmmountForCurrentMonth(DateTime dateFrom, DateTime dateTo)
        {
            using (var db = new AppDbContext())
            {
                var interventionsForCurrentMonth = db.Interventions.Where(i => i.Date >= dateFrom && i.Date <= dateTo).ToList();
                return interventionsForCurrentMonth.Sum(i => i.Price);
            }
        }
    }  
}
