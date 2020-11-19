using MobileApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileApp.Data.Repositories
{
   public class ReportRepository : IReportRepository
    {
        public decimal GetPayedAmmountForCurrentMonth(DateTime dateFrom, DateTime dateTo)
        {
            using (var db = new AppDbContext())
            {
                var interventionsForCurrentMonth = db.Interventions.Where(i => i.Date >=dateFrom && i.Date <= dateTo).ToList();
                return interventionsForCurrentMonth.Sum(i => i.Price);
            }
        }
    }
}
