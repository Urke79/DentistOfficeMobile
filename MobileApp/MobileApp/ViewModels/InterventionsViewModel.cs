using MobileApp.Domain_Models;
using MobileApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class InterventionsViewModel : BaseViewModel
    {
        // Bindable properties
        public ObservableCollection<Intervention> Interventions { get; set; } = new ObservableCollection<Intervention>();
        public ICommand AddInterventionCommand { get; private set; }
        public ICommand SelectInterventionCommand { get; private set; }

        private Intervention _selectedIntervention;
        public Intervention SelectedIntervention
        {
            get { return _selectedIntervention; }
            set
            {
                SetValue(ref _selectedIntervention, value);
            }
        }
        public Client ContextClient { get; set; }

        public InterventionsViewModel(IPageService pageService)
            : base(pageService)
        {
            AddInterventionCommand = new Command(AddIntervention);
            SelectInterventionCommand = new Command<Intervention>(async intervention => await SelectItem(intervention, i => new InterventionDetailsPage(i)));
        }

        private async void AddIntervention()
        {
            await PageService.PushAsync(new InterventionDetailsPage(new Intervention() { ClientId = ContextClient.Id, Date = DateTime.Now}));
        }

        public async void RefreshInterventionList()
        {
            var response = await new HttpClient().GetStringAsync(Consts.baseApiUrl + "/api/intervention/" + ContextClient.Id);

            var interventions = JsonConvert.DeserializeObject<List<Intervention>>(response);

            Interventions.Clear();
            foreach (var item in interventions)
            {
                // This is the way you should work with observable collection
                Interventions.Add(item);
            }
        }
    }
}
