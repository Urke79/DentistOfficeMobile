using MobileApp.Data;
using MobileApp.Data.Interfaces;
using MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class InterventionsViewModel : BaseViewModel
    {

        // dependencies 
        private IInterventionRepository _repository;

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

        public InterventionsViewModel(IInterventionRepository repository, IPageService pageService)
            : base(pageService)
        {
            _repository = repository;

            AddInterventionCommand = new Command(AddIntervention);
            SelectInterventionCommand = new Command<Intervention>(async intervention => await SelectItem(intervention, i => new InterventionDetailsPage(i)));
        }

        private async void AddIntervention()
        {
            await PageService.PushAsync(new InterventionDetailsPage(new Intervention() { ClientId = ContextClient.Id, Date = DateTime.Now}));
        }

        public void RefreshInterventionList()
        {
            var interventions = _repository.GetInterventions(ContextClient.Id);

            Interventions.Clear();
            foreach (var item in interventions)
            {
                // This is the way you should work with observable collection
                Interventions.Add(item);
            }
        }
    }
}
