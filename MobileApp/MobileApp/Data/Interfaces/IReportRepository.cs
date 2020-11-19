using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Data.Interfaces
{
    public interface IReportRepository
    {
        decimal GetPayedAmmountForCurrentMonth(DateTime dateFrom, DateTime dateTo);
    }
}
