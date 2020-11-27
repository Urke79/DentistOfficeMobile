using CommonServiceLocator;
using MobileApp.Domain_Models;
using MobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InterventionDetailsPage : ContentPage
    {
        public InterventionDetailsPage(Intervention intervention)
        {
            InitializeComponent();

			ViewModel = ServiceLocator.Current.GetInstance<InterventionDetailsViewModel>();
            ViewModel.SelectedIntervention = intervention;
        }

		// used to simplify reference to a view model
		private InterventionDetailsViewModel ViewModel
		{
			get { return BindingContext as InterventionDetailsViewModel; }
			set { BindingContext = value; }
		}
	}
}