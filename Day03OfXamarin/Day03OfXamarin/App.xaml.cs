using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Day03OfXamarin
{
    public partial class App : Application
    {
        public static string DatabasePath;

        public App(string databasePath)
        {
            InitializeComponent();
            DatabasePath = databasePath;

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
