using Plugin.LocalNotification;
using Proiect_Magazin_Mobile.Models;
namespace Proiect_Magazin_Mobile;

public partial class StorePage : ContentPage
{
    public StorePage()
    {
        InitializeComponent();
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var store = (Store)BindingContext;
        await App.Database.SaveStoreAsync(store);
        await Navigation.PopAsync();
    }
    async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var shop = (Store)BindingContext;
        var address = shop.Adress;
        var locations = await Geocoding.GetLocationsAsync(address);

        var options = new MapLaunchOptions
        {
            Name = "Magazinul meu preferat"
        };
        var location = locations?.FirstOrDefault();
        // var myLocation = await Geolocation.GetLocationAsync();
        var myLocation = new Location(46.7731796289, 23.6213886738);
        var distance = myLocation.CalculateDistance(location,
DistanceUnits.Kilometers);
        if (distance < 4)
        {
            var request = new NotificationRequest
            {
                Title = "Ai de facut cumparaturi in apropiere!",
                Description = address,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }
        await Map.OpenAsync(location, options);

    }
}