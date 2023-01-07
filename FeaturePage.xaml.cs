using Proiect_Magazin_Mobile.Models;

namespace Proiect_Magazin_Mobile;

public partial class FeaturePage : ContentPage
{
    ShopCart sc;
	public FeaturePage(ShopCart slist)
	{
		InitializeComponent();
        sc = slist;
	}
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Feature f;
        if (listView.SelectedItem != null)
        {
            f = listView.SelectedItem as Feature;
            var lf = new ListFeature()
            {
                ShopCartID = sc.ID,
                FeatureID = f.ID
            };
            await App.Database.SaveListFeatureAsync(lf);
            f.ListFeatures = new List<ListFeature> { lf };
            await Navigation.PopAsync();
        }
    }


        async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var feature = (Feature)BindingContext;
        await App.Database.SaveFeatureAsync(feature);
        listView.ItemsSource = await App.Database.GetFeaturesAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var feature = listView.SelectedItem as Feature;
        await App.Database.DeleteFeatureAsync(feature);
        listView.ItemsSource = await App.Database.GetFeaturesAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetFeaturesAsync();
    }
}