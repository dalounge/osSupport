using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace pracAndroid
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class osLIst : ContentPage
    {
        public osLIst(string selected)
        {
            InitializeComponent();

            var json = new JsonReader();
            var readJson = json.ReadJson();

            foreach (var os in readJson[selected].OS)
            {
                json.PKeys.Add(os);
            }
            var sortedProduct = json.PKeys.OrderBy(x => x).ToList();
            guiListView.ItemsSource = sortedProduct;
        }
    }

    public class OSNames
    {
        public List<string> OSName = new List<string>();
    }
}