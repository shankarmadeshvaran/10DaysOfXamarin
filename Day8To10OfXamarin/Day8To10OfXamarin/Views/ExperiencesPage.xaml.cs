using System;
using System.Collections.Generic;
using Day8To10OfXamarin.ViewModels;
using Xamarin.Forms;

namespace Day8To10OfXamarin.Views
{
    public partial class ExperiencesPage : ContentPage
    {
        ExperiencesVM viewModel;
        public ExperiencesPage()
        {
            InitializeComponent();
            viewModel = Resources["vm"] as ExperiencesVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.ReadExperiences();
        }
    }
}
