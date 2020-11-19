using CommonServiceLocator;
using MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportPage : ContentPage
    {
        public ReportPage()
        {
            InitializeComponent();
            ViewModel = ServiceLocator.Current.GetInstance<ReportViewModel>();
        }

        private ReportViewModel ViewModel
        {
            get { return BindingContext as ReportViewModel; }
            set { BindingContext = value; }
        }
    }
}