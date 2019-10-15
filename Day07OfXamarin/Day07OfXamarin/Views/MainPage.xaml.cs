using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Day07OfXamarin.Model;
using Day07OfXamarin.Models;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using SQLite;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace Day07OfXamarin
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        IGeolocator locator = CrossGeolocator.Current;
        Position position;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            locator.PositionChanged += Locator_PositionChanged;
        }
        void Locator_PositionChanged(object sender, PositionEventArgs e)
        {
            position = e.Position;
        }
        private async void GetLocationPermission()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
            if (status != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                {
                    await DisplayAlert("Need your permission", "We need to access your location", "Ok");
                }
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                if (results.ContainsKey(Permission.LocationWhenInUse))
                    status = results[Permission.LocationWhenInUse];
            }
            if (status == PermissionStatus.Granted)
            {
                GetLocation();
            }
            else
            {
                await DisplayAlert("Access to location denied", "We don't have access to your location", "Ok");
            }
        }
        private async void GetLocation()
        {
            position = await locator.GetPositionAsync();
            await locator.StartListeningAsync(TimeSpan.FromMinutes(30), 500);
        }
        private void CheckIfSaveButtonEnable()
        {
            saveButton.IsEnabled = false;
            if (!string.IsNullOrWhiteSpace(titleEntry.Text) && !string.IsNullOrWhiteSpace(experienceEditor.Text))
            {
                saveButton.IsEnabled = true;
            }
        }
        void Save_Button_Clicked(object sender, System.EventArgs e)
        {
            Experience newExperience = new Experience()
            {
                Title = titleEntry.Text,
                Content = experienceEditor.Text,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                VenueName = venueNameLabel.Text,
                VenueCategory = venueCategoryLabel.Text,
                VenueLat = float.Parse(venueCoordinatesLabel.Text.Split(',')[0]),
                VenueLng = float.Parse(venueCoordinatesLabel.Text.Split(',')[1])
            };

            int insertedItems = 0;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Experience>();
                insertedItems = conn.Insert(newExperience);
            }
            if (insertedItems > 0)
            {
                titleEntry.Text = string.Empty;
                experienceEditor.Text = string.Empty;
                venueNameLabel.Text = string.Empty;
                venueCategoryLabel.Text = string.Empty;
                venueCoordinatesLabel.Text = string.Empty;
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Error", "There was an error inserting the Experience, please try again", "Ok");
            }
        }
        private void ShowAlert(string title, string message)
        {
            DisplayAlert(title, message, null, "OK");
        }
        void Cancel_Button_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
        void Experience_Editor_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            CheckIfSaveButtonEnable();
        }
        void Title_Entry_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            CheckIfSaveButtonEnable();
        }
        async void SearchEntry_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(searchEntry.Text))
            {
                string url = $"https://api.myjson.com/bins/q329e";

                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(url);

                    Search searchResult = JsonConvert.DeserializeObject<Search>(json);
                    venuesListView.IsVisible = true;
                    venuesListView.ItemsSource = searchResult.response.venues;
                }
            }
            else
            {
                venuesListView.IsVisible = false;
            }
        }
        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (venuesListView.SelectedItem != null)
            {
                selectedVenueStackLayout.IsVisible = true;
                searchEntry.Text = string.Empty;
                venuesListView.IsVisible = false;

                Venue selectedVenue = venuesListView.SelectedItem as Venue;
                venueNameLabel.Text = selectedVenue.name;
                venueCategoryLabel.Text = selectedVenue.categories.FirstOrDefault()?.name;
                venueCoordinatesLabel.Text = $"{selectedVenue.location.lat:0.000}, {selectedVenue.location.lng:0.000}";
            }
            else
            {
                selectedVenueStackLayout.IsVisible = false;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetLocationPermission();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            locator.StopListeningAsync();
        }
    }
}
