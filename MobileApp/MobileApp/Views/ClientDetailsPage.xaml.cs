using CommonServiceLocator;
using MobileApp.Domain_Models;
using MobileApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Screens
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ClientDetailsPage : ContentPage
	{ 
		public ClientDetailsPage(Client client)
		{
			InitializeComponent();

			ViewModel = ServiceLocator.Current.GetInstance<ClientDetailsViewModel>();
			ViewModel.SelectedClient = client;
		}

		// used to simplify reference to a view model
		private ClientDetailsViewModel ViewModel
		{
			get { return BindingContext as ClientDetailsViewModel; }
			set { BindingContext = value; }
		}
    }
}