using Proiect_Magazin_Mobile.Models;

namespace Proiect_Magazin_Mobile;

public partial class StoreEntryPage : ContentPage
{
	public StoreEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetStoresAsync();
    }
    async void OnStoreAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new StorePage
        {
            BindingContext = new Store()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new StorePage
            {
                BindingContext = e.SelectedItem as Store
            });
        }
    }

}