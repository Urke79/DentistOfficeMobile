using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		// dependencies 
		protected IPageService PageService { get; set; }

        public BaseViewModel(IPageService pageService)
        {
			PageService = pageService;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingField, value))
				return;

			backingField = value;

			OnPropertyChanged(propertyName);
		}

		public async Task SelectItem<T>(T item, Func<T, Page> del)
		{
			if (item != null)
			{
				await PageService.PushAsync(del(item));				
			}
		}
	}
}
