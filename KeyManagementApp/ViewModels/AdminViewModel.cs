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
        public Command RemoveOwnerCommand { get; }
        public Command AddPropertyCommand { get; }
        public Command RemovePropertyCommand { get; }
        public Command AddKeyBoxCommand { get; }

        public AdminViewModel()
        {
            AddOwnerCommand = new Command(OnAddOwner);
            RemoveOwnerCommand = new Command(OnRemoveOwner);
            AddPropertyCommand = new Command(OnAddProperty);
            RemovePropertyCommand = new Command(OnRemoveProperty);
            AddKeyBoxCommand = new Command(OnAddKeyBox);
        }

        private async void OnAddOwner()
        {
            await Shell.Current.GoToAsync(nameof(AddOwnerPage));
        }

        private async void OnRemoveOwner()
        {
            await Shell.Current.GoToAsync(nameof(RemoveOwnerPage));
        }

        private async void OnAddProperty()
        {
            await Shell.Current.GoToAsync(nameof(AddPropertyPage));
        }

        private async void OnRemoveProperty()
        {
            await Shell.Current.GoToAsync(nameof(RemovePropertyPage));
        }

        private async void OnAddKeyBox()
        {
            await Shell.Current.GoToAsync(nameof(AddKeyBoxPage));
        }
    }
}
