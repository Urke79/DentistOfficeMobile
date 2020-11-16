using MobileApp.Data;
using MobileApp.Data.Interfaces;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class ClientDetailsViewModel : BaseViewModel
    {
        // dependencies 
        private IBaseRepository<Client> _repository;

        // Bindable properties
        private Client _selectedClient;
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                SetValue(ref _selectedClient, value);
                (DeleteClientCommand as Command).ChangeCanExecute();
            }
        }

        public ICommand AddClientCommand { get; private set; }
        public ICommand DeleteClientCommand { get; private set; }
        public ICommand ShowInterventionsCommand { get; private set; }

        public ClientDetailsViewModel(IBaseRepository<Client> repository, IPageService pageService)
            : base (pageService)
        {
            _repository = repository;

            AddClientCommand = new Command(SaveClient);
            // To disable Delete button, you can't use IsEnabled property of the ToolBarItem
            // There's a complicated logic behind this command that does this
            // More here:  https://stackoverflow.com/questions/48887917/toolbaritem-isenabled-property-is-available-in-xaml-not-code
            DeleteClientCommand = new Command(DeleteClient, DeleteClientCanExecute);
            ShowInterventionsCommand = new Command(ShowInterventions);
        }

        private async void DeleteClient(object obj)
        {
            if (await PageService.DisplayAlert("Upozorenje", "Da li ste sigurni?", "Da", "Ne"))
            {
                _repository.DeleteEntity(SelectedClient);
                await PageService.PopAsync();
            }
        }

        private bool DeleteClientCanExecute(object arg)
        {
            if (SelectedClient != null)
            {
                return SelectedClient.Id != 0;
            }

            return true;           
        }

        private async void ShowInterventions()
        {
            await PageService.PushAsync(new InterventionPage(SelectedClient));
        }

        private async void SaveClient()
        {
            if (string.IsNullOrEmpty(SelectedClient.Name))
            {
                await PageService.DisplayAlert("Greška", "Morate uneti ime pacijenta!", "OK");
                return;
            }
            if (SelectedClient.Id == 0)
            {
                _repository.SaveEntity(SelectedClient);
            }
            else
            {
                _repository.UpdateEntity(SelectedClient);
            }

            // get back to the previous screen
            await PageService.PopAsync();
        }
    }
}