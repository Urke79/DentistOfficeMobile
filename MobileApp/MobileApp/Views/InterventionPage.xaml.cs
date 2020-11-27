using CommonServiceLocator;
using MobileApp.Domain_Models;
using MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InterventionPage : ContentPage
    {
        public InterventionPage(Client client)
        {
            InitializeComponent();

            ViewModel = ServiceLocator.Current.GetInstance<InterventionsViewModel>();
            ViewModel.ContextClient = client;
        }

        protected override void OnAppearing()
        {
            ViewModel.RefreshInterventionList();
        }

        private void ClientsInterventionsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectInterventionCommand.Execute(e.SelectedItem);          
        }

        // used to simplify reference to a view model
        private InterventionsViewModel ViewModel
        {
            get { return BindingContext as InterventionsViewModel; }
            set { BindingContext = value; }
        }
    }
}