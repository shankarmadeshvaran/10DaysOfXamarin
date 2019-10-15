using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using Day05OfXamarin.Models;

namespace Day05OfXamarin
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
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
            DisplayAlert(title, message, null , "OK");
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
    }
}
