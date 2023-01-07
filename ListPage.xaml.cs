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
        await App.Database.SaveShopCartAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopCart)BindingContext;
        await App.Database.DeleteShopCartAsync(slist);
        await Navigation.PopAsync();
    }
}