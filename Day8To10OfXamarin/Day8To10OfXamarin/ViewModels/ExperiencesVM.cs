using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Day8To10OfXamarin.Models;
using Day8To10OfXamarin.ViewModels.Commands;

namespace Day8To10OfXamarin.ViewModels
{
    public class ExperiencesVM : INotifyPropertyChanged
    {
        public NewExperienceCommand NewExperienceCommand { get; set; }

        public ObservableCollection<Experience> Experiences { get; set; }

        public ExperiencesVM()
        {
            NewExperienceCommand = new NewExperienceCommand(this);
            Experiences = new ObservableCollection<Experience>();
            ReadExperiences();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NewExperience()
        {
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

        public void ReadExperiences()
        {
            var experiences = Experience.GetExperiences();

            Experiences.Clear();
            foreach (var experience in experiences)
            {
                Experiences.Add(experience);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
