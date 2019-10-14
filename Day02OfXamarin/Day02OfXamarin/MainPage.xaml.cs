using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Day02OfXamarin
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CheckIfSaveButtonEnable()
        {
            saveButton.IsEnabled = false;

            if (!string.IsNullOrWhiteSpace(titleEntry.Text) && !string.IsNullOrWhiteSpace(experienceEditor.Text)) {
                saveButton.IsEnabled = true;
            }
        }
        
        void Save_Button_Clicked(object sender, System.EventArgs e)
        {
            titleEntry.Text = string.Empty;
            experienceEditor.Text = string.Empty;
        }

        void Cancel_Button_Clicked(object sender, System.EventArgs e)
        {

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
