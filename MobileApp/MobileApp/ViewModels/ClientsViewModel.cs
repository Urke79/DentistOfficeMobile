using MobileApp.Domain_Models;
using MobileApp.Screens;
using MobileApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class ClientsViewModel : BaseViewModel
    {
        HttpClient httpClient = new HttpClient();

        // Bindable properties

        // Automatically updates UI if item is added or deleted (INotifyCollectionChanged interface) 
        // Must declare it like this
        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
        public Client SelectedClient { get; set; }
        public ICommand AddClientCommand { get; private set; }

        public ICommand ReportCommand { get; private set; }
        public ICommand SelectClientCommand { get; private set; }

        public ClientsViewModel (IPageService pageService)
            : base(pageService)
        {
            // Commands with and without parameter
            AddClientCommand = new Command(AddNewClient);
            ReportCommand = new Command(ShowReport);
            SelectClientCommand = new Command<Client>(async client => await SelectItem(client, c => new ClientDetailsPage(c)));
        }

        private async void ShowReport(object obj)
        {
            await PageService.PushAsync(new ReportPage());
        }

        public async void RefreshClientList(string searchParameter = null)
        {
            var clients = await GetClients();

            if (searchParameter != null)
            {
                clients = (List<Client>)clients.Where(c => c.Name.ToUpper().Contains(searchParameter.ToUpper()));
            }
            
            Clients.Clear();
            foreach (var item in clients)
            {
                // This is the way you should work with observable collection
                Clients.Add(item);
            }
        }

        private async Task<List<Client>> GetClients()
        {
            var clients = await httpClient.GetStringAsync(Consts.baseApiUrl + "/api/Client");

            return JsonConvert.DeserializeObject<List<Client>>(clients);
        }

        private async void AddNewClient()
        {
            await PageService.PushAsync(new ClientDetailsPage(new Client()));
        }
    }
}
