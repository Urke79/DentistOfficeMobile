using CommonServiceLocator;
using Microsoft.EntityFrameworkCore;
using MobileApp.Data;
using MobileApp.Data.Interfaces;
using MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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