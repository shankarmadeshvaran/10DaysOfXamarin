using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Day06OfXamarin.Models;
using SQLite;
using Xamarin.Forms;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace Day06OfXamarin
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        IGeolocator locator = CrossGeolocator.Current;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            locator.PositionChanged += Locator_PositionChanged;
        }
        void Locator_PositionChanged(object sender, PositionEventArgs e)
        {
            var position = e.Position;
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
            var position = await locator.GetPositionAsync();
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
                UpdatedAt = DateTime.Now
            };

            int insertedItems = 0;

            using (SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Experience>();
                insertedItems = connection.Insert(newExperience);
            }

            if (insertedItems > 0)
            {
                titleEntry.Text = string.Empty;
                experienceEditor.Text = string.Empty;
                //ShowAlert(title: "Success", message: "Your Experience is inserted successfully");
                Navigation.PopAsync();
            }
            else
            {
                ShowAlert(title: "Error", message: "There was an error inserting the Experience, please try again");
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
