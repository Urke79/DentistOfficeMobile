using Microsoft.EntityFrameworkCore;
using MobileApp.Data;
using MobileApp.Data.Interfaces;
using MobileApp.Screens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Core;

namespace MobileApp.ViewModels
{
    public class ClientsViewModel : BaseViewModel
    {
        // dependencies 
        private IBaseRepository<Client> _repository;

        // Bindable properties

        // Automatically updates UI if item is added or deleted (INotifyCollectionChanged interface) 
        // Must declare it like this
        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
        public Client SelectedClient { get; set; }
        public ICommand AddClientCommand { get; private set; }
        public ICommand SelectClientCommand { get; private set; }

        public ClientsViewModel(IBaseRepository<Client> repository, IPageService pageService)
            : base(pageService)
        {
            _repository = repository;

            // Commands with and without parameter
            AddClientCommand = new Command(AddNewClient);
            SelectClientCommand = new Command<Client>(async client => await SelectItem(client, c => new ClientDetailsPage(c)));
        }

        public void RefreshClientList(string searchParameter = null)
        {
            var clients = _repository.GetAll();

            if (searchParameter != null)
            {
                clients = clients.Where(c => c.Name.ToUpper().Contains(searchParameter.ToUpper()));
            }
            
            Clients.Clear();
            foreach (var item in clients)
            {
                // This is the way you should work with observable collection
                Clients.Add(item);
            }
        }

        private async void AddNewClient()
        {
            await PageService.PushAsync(new ClientDetailsPage(new Client()));
        }
    }
}
