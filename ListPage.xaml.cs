using Proiect_Magazin_Mobile.Models;
namespace Proiect_Magazin_Mobile;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
       // var items = await App.Database.GetStoresAsync();
       // StorePicker.ItemsSource = (System.Collections.IList)items;
       // StorePicker.ItemDisplayBinding = new Binding("ShopDetails");
       
        var shopc = (ShopCart)BindingContext;

        
        listView.ItemsSource = await App.Database.GetListFeaturesAsync(shopc.ID);
    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FeaturePage((ShopCart)
       this.BindingContext)
        {
            BindingContext = new Feature()
        });

    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopCart)BindingContext;
        slist.Date = DateTime.UtcNow;
        //Store selectedStore = (StorePicker.SelectedItem as Store);
        //slist.StoreID = selectedStore.ID;
        await App.Database.SaveShopCartAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopCart)BindingContext;
        await App.Database.DeleteShopCartAsync(slist);
        await Navigation.PopAsync();
    }

    async void OnDeleteFeatureListClicked(object sender, EventArgs e)
    {
        var slist= (ShopCart)BindingContext;
        var f = listView.SelectedItem as Feature;
        var lf = App.Database.GetListFeatureAsync(slist.ID, f.ID);
        await App.Database.DeleteListFeatureAsync(await lf);
        await Navigation.PopAsync();

    }
}