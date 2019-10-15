﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using Day06OfXamarin.Views;

namespace Day06OfXamarin
{
    public partial class App : Application
    {
        public static string DatabasePath;

        public App(string databasePath)
        {
            InitializeComponent();

            DatabasePath = databasePath;
            MainPage = new NavigationPage(new ExperiencesPage());
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ExperiencesPage());
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