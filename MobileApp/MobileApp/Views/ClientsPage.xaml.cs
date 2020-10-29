using CommonServiceLocator;
using MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Screens
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientsPage : ContentPage
    {
        public ClientsPage()
        {
            InitializeComponent();

            ViewModel = ServiceLocator.Current.GetInstance<ClientsViewModel>();
        }

        // Page life cycle events
        protected override void OnAppearing()
        {
            ViewModel.SelectedClient = null;
            ViewModel.RefreshClientList();
            
        }

        // Page events
        private  void OnClientSelected(object sender, SelectedItemChangedEventArgs e)
        {
           ViewModel.SelectClientCommand.Execute(e.SelectedItem);
        }

        // used to simplify reference to a view model
        private ClientsViewModel ViewModel
        {
            get { return BindingContext as ClientsViewModel; }
            set {BindingContext = value; }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.RefreshClientList(e.NewTextValue);
        }
    }
}
