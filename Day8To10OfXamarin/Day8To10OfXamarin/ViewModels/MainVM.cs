using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Day8To10OfXamarin.Models;
using Day8To10OfXamarin.ViewModels.Helpers;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace Day8To10OfXamarin.ViewModels
{ 
        public class MainVM : INotifyPropertyChanged 
        {
            private string title;
            public string Title
            {
                get { return title; }
                set
                {
                    title = value;
                    OnPropertyChanged("Title");
                    OnPropertyChanged("CanSave");
                }
            }

            private string query;
            public string Query
            {
                get { return query; }
                set
                {
                    query = value;
                    if (!string.IsNullOrWhiteSpace(query))
                    {
                        GetVenues();
                        ShowVenues = true;
                    }
                    else
                    {
                        ShowVenues = false;
                    }
                    OnPropertyChanged("Query");
                }
            }

            private Venue selectedVenue; 
            public Venue SelectedVenue
            {
                get { return selectedVenue; }
                set
                {
                    selectedVenue = value;
                    if (selectedVenue != null)
                    {
                        ShowVenues = false;
                        Query = string.Empty;
                    }
                    OnPropertyChanged("SelectedVenue");
                    OnPropertyChanged("ShowSelectedVenue");
                }
            }

            private string content;
            public string Content
            {
                get { return content; }
                set
                {
                    content = value;
                    OnPropertyChanged("Content");
                    OnPropertyChanged("CanSave");
                }
            }

            public bool CanSave
            {
                get { return !string.IsNullOrWhiteSpace(Title) && !string.IsNullOrWhiteSpace(Content); }
            }

            public bool ShowSelectedVenue
            {
                get { return SelectedVenue != null; }
            }

            private bool showVenues;
            public bool ShowVenues
            {
                get { return showVenues; }
                set
                {
                    showVenues = value;
                    OnPropertyChanged("ShowVenues");
                }
            }

            public ObservableCollection<Venue> Venues { get; set; }

            public ICommand CancelCommand { get; set; }
            public ICommand SaveCommand { get; set; }

            LocationHelper locationHelper;
            public MainVM()
            {
                CancelCommand = new Command(CancelAction);
                SaveCommand = new Command<bool>(SaveAction, CanExecuteSave);
                Venues = new ObservableCollection<Venue>();
                locationHelper = new LocationHelper();
            }

            public async void GetVenues()
            {
                var response = await Search.SearchRequest(locationHelper.position.Latitude, locationHelper.position.Longitude, 500, Query);

                Venues.Clear();
                foreach (var venue in response.venues)
                {
                    Venues.Add(venue);
                }
            }

            public async void GetLocationPermission()
            {
                var status = await PermissionsHelper.GetPermission(Permission.LocationWhenInUse);

                if (status == PermissionStatus.Granted)
                {
                    await locationHelper.GetLocation(TimeSpan.FromMinutes(30), 500);
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Access to location denied", "We don't have access to your location", "Ok");
                }
            }

            public void StopListeningLocationUpdates()
            {
                locationHelper.StopListening();
            }

            bool CanExecuteSave(bool arg)
            {
                return arg;
            }

            void SaveAction(bool obj)
            {
                Experience newExperience = new Experience()
                {
                    Title = Title,
                    Content = Content,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    VenueName = SelectedVenue.name,
                    VenueCategory = SelectedVenue.MainCategory,
                    VenueLat = float.Parse(SelectedVenue.location.Coordinates.Split(',')[0]),
                    VenueLng = float.Parse(SelectedVenue.location.Coordinates.Split(',')[1])
                };

                bool insertSuccessful = newExperience.InsertExperience();

                if (insertSuccessful)
                {
                    Title = string.Empty;
                    Content = string.Empty;
                    SelectedVenue = null;
                    App.Current.MainPage.Navigation.PopAsync();
            }
                else
                {
                    App.Current.MainPage.DisplayAlert("Error", "There was an error inserting the Experience, please try again", "Ok");
                }
            }

            void CancelAction(object obj)
            {
                App.Current.MainPage.Navigation.PopAsync();
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
}
