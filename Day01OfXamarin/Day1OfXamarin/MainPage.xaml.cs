using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Day1OfXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(username.Text)) {
                greeting_Label.Text = null;
                DisplayAlert("Error","Your username can't be empty","OK");
            } else
            {
                greeting_Label.Text = $"Hello {username.Text}!!! Welcome to Xamarin Development";
            }
        }
    }
}
