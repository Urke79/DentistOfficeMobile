using MobileApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class ReportViewModel : BaseViewModel
    {
        // depandencies
        private IReportRepository _repository { get; set; }

        public ICommand ShowPayedAmmountCommand { get; private set; }

        public DateTime DateFrom { get; set; } = DateTime.Now;

        public DateTime DateTo { get; set; } = DateTime.Now;

        private string _payedAmmount;
        public string PayedAmmount
        {
            get { return _payedAmmount; }
            set
            {
                SetValue(ref _payedAmmount, value);
            }
        }

        private string _myCut;
        public string MyCut
        {
            get { return _myCut; }
            set
            {
                SetValue(ref _myCut, value);
            }
        }

        public ReportViewModel(IReportRepository repository, IPageService pageService)
            :base(pageService)
        {
            _repository = repository;
            ShowPayedAmmountCommand = new Command(ShowPayedAmmount);
        }

        private void ShowPayedAmmount()
        {
            if (DateTo < DateFrom)
            {
                PageService.DisplayAlert("Greška", "Datum do mora biti veći od početnog datuma!", "OK");
                return;
            }

            var payedAmmount = _repository.GetPayedAmmountForCurrentMonth(DateFrom, DateTo);
            PayedAmmount = "Ukupna zarada: " + payedAmmount.ToString();
            MyCut = "Moj deo: " + decimal.Multiply(payedAmmount, 0.4M).ToString();
        }
    }
}
