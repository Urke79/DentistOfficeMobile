using MobileApp.Domain_Models;
using MobileApp.Helpers;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class InterventionDetailsViewModel : BaseViewModel
    {
        HttpClient httpClient = new HttpClient();
        readonly string apiUrl = Consts.baseApiUrl + "/api/intervention";

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

        public InterventionDetailsViewModel(IPageService pageService)
            : base(pageService)
        {
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
                DeleteInterventionAsync();
                // get back to the previous screen
                await PageService.PopAsync();
            }
        }

        private async void DeleteInterventionAsync()
        {
            await HttpHelper.SendRequestAsync(HttpMethod.Delete, apiUrl, SelectedIntervention);
        }

        private async void SaveIntervention()
        {
            if (SelectedIntervention.Id == 0)
            {
                await HttpHelper.SendRequestAsync(HttpMethod.Post, apiUrl, SelectedIntervention);
            }
            else
            {
                await HttpHelper.SendRequestAsync(HttpMethod.Put, apiUrl, SelectedIntervention);
            }

            // get back to the previous screen
            await PageService.PopAsync();
        }
    }
}
