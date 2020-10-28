using MobileApp.Data;
using MobileApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class InterventionDetailsViewModel : BaseViewModel
    {
        // dependencies 
        private IInterventionRepository _repository;

        // Bindable properties
        private Intervention _selectedIntervention;
        public Intervention SelectedIntervention
        {
            get { return _selectedIntervention; }
            set
            {
                SetValue(ref _selectedIntervention, value);
                (DeleteInterventionCommand as Command).ChangeCanExecute();
            }
        }

        public ICommand SaveInterventionCommand { get; private set; }
        public ICommand DeleteInterventionCommand { get; private set; }

        public InterventionDetailsViewModel(IInterventionRepository repository, IPageService pageService)
            : base(pageService)
        {
            _repository = repository;

            SaveInterventionCommand = new Command(SaveIntervention);
            DeleteInterventionCommand = new Command(DeleteIntervention, DeleteInterventionCanExecute);
        }

        private bool DeleteInterventionCanExecute(object arg)
        {
            if (SelectedIntervention != null)
            {
                return SelectedIntervention.Id != 0;
            }

            return true;
        }

        private async void DeleteIntervention(object obj)
        {
            if (await PageService.DisplayAlert("Upozorenje", "Da li ste sigurni?", "Da", "Ne"))
            {
                _repository.DeleteEntity(SelectedIntervention);

                // get back to the previous screen
                await PageService.PopAsync();
            }
        }

        private async void SaveIntervention()
        {
            if (SelectedIntervention.Id == 0)
            {
                _repository.SaveEntity(SelectedIntervention);
            }
            else
            {
                _repository.UpdateEntity(SelectedIntervention);
            }

            // get back to the previous screen
            await PageService.PopAsync();
        }
    }
}
