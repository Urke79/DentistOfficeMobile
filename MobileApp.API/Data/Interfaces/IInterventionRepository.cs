using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.API.Data.Interfaces
{
    public interface IInterventionRepository : IBaseRepository<Intervention>
    {
        IEnumerable<Intervention> GetInterventions(int clientId);
        public decimal GetPayedAmmountForCurrentMonth(DateTime dateFrom, DateTime dateTo);     
    }
}
