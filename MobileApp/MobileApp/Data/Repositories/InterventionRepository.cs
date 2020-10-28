using MobileApp.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MobileApp.Data.Repositories
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
    }
}
