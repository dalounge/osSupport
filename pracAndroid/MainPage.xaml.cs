using SQLite;
using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;



namespace pracAndroid
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            var json = new JsonReader();
            var readJson = json.ReadJson();
            foreach (var k in readJson.Keys)
            {
                json.PKeys.Add(k);
            }
                        
            var sortedProduct = json.PKeys.OrderBy(x => x).ToList();
            guiPicker.ItemsSource = sortedProduct;

        }

        
        void OnAdd(object sender, System.EventArgs e)
        {

        }

        void OnUpdate(object sender, System.EventArgs e)
        {
        }

        void OnDelete(object sender, System.EventArgs e)
        {
        }

        async void GuiPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new osLIst(guiPicker.SelectedItem.ToString()));
        }
    }
}