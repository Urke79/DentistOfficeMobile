using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MobileApp
{
    // Used to create different colors of rows in a ListView
    // https://blog.verslu.is/stackoverflow-answers/alternate-row-color-listview/
    public class AlternateColorDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EvenTemplate { get; set; }
        public DataTemplate UnevenTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var observableListOfItems = ((ListView)container).ItemsSource as IEnumerable<dynamic>;
            var itemIndex = observableListOfItems.IndexOf(item);

            return itemIndex % 2 == 0 ? EvenTemplate : UnevenTemplate;
        }
    }
}