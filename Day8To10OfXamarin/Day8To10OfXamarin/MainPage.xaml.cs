using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day8To10OfXamarin.ViewModels;
using Xamarin.Forms;

namespace Day8To10OfXamarin
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainVM viewModel;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            viewModel = new MainVM();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.GetLocationPermission();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            viewModel.StopListeningLocationUpdates();
        }
    }
}
