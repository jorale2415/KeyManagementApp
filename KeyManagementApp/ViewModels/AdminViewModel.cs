using KeyManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KeyManagementApp.ViewModels
{
    class AdminViewModel
    {
        public Command AddOwnerCommand { get; }
        public Command AddPropertyCommand { get; }
        public Command AddKeyBoxCommand { get; }

        public AdminViewModel()
        {
            AddOwnerCommand = new Command(OnAddOwner);
            AddPropertyCommand = new Command(OnAddProperty);
            AddKeyBoxCommand = new Command(OnAddKeyBox);
        }

        private async void OnAddOwner()
        {
            await Shell.Current.GoToAsync(nameof(AddOwnerPage));
        }

        private async void OnAddProperty()
        {
            await Shell.Current.GoToAsync(nameof(AddPropertyPage));
        }

        private async void OnAddKeyBox()
        {
            await Shell.Current.GoToAsync(nameof(AddKeyBoxPage));
        }
    }
}
