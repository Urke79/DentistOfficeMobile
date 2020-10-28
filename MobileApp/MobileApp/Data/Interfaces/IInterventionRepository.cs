using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Data.Interfaces
{
    public interface IInterventionRepository : IBaseRepository<Intervention>
    {
        IEnumerable<Intervention> GetInterventions(int clientId);
        //void DeleteIntervention(Intervention intervention);
        //void SaveIntervention(Intervention intervention);
        //void UpdateIntervention(Intervention intervention);
    }
}
