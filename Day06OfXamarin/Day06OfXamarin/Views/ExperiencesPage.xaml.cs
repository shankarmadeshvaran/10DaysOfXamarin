using System;
using System.Collections.Generic;
using Day06OfXamarin.Models;
using SQLite;
using Xamarin.Forms;

namespace Day06OfXamarin.Views
{
    public partial class ExperiencesPage : ContentPage
    {
        public ExperiencesPage()
        {
            InitializeComponent();
        }

        void Handle_Add_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ReadExperiences();
        }

        private void ReadExperiences()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.DatabasePath))
            {
                connection.CreateTable<Experience>();
                List<Experience> experiences = connection.Table<Experience>().ToList();
                experienceListView.ItemsSource = experiences;
            }
        }
    }
}
