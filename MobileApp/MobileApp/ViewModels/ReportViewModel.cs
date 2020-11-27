using System;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class ReportViewModel : BaseViewModel
    {
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

        public ReportViewModel(IPageService pageService)
            :base(pageService)
        {
            ShowPayedAmmountCommand = new Command(ShowPayedAmmount);
        }

        private async void ShowPayedAmmount()
        {
            if (DateTo < DateFrom)
            {
                await PageService.DisplayAlert("Greška", "Datum do mora biti veći od početnog datuma!", "OK");
                return;
            }

            var payedAmmount = await new HttpClient().GetStringAsync(Consts.baseApiUrl + "/api/intervention/GetPayedAmmountForCurrentMonth/" + DateFrom.ToString(@"yyyy-MM-dd") + "/" + DateTo.ToString(@"yyyy-MM-dd"));
            PayedAmmount = "Ukupna zarada: " + payedAmmount;
            MyCut = "Moj deo: " + decimal.Multiply(decimal.Parse(payedAmmount), 0.4M).ToString();
        }
    }
}
