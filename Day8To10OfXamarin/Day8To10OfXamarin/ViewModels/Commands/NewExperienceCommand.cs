using System;
using System.Windows.Input;

namespace Day8To10OfXamarin.ViewModels.Commands
{
    public class NewExperienceCommand : ICommand
    {
        private ExperiencesVM viewModel;
        public NewExperienceCommand(ExperiencesVM viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.NewExperience();
        }
    }
}
