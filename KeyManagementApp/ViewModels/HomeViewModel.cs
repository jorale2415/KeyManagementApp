using System;
using System.Collections.Generic;
using System.Text;
using KeyManagementApp.Models;
using KeyManagementApp.Views;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Windows.Input;

namespace KeyManagementApp.ViewModels
{
    class HomeViewModel : BaseViewModel
    {
        public Command AdminCommand { get; }
        public ICommand FindKeyCommand { get; }

        public HomeViewModel()
        {
            Title = "Key Management";
            AdminCommand = new Command(OnAdminClicked);
            FindKeyCommand = new Command(OnFindKey);
        }

        // local variables
        public string address = "";
        public string city = "";
        public string state = "";
        public string zip = "";

        // binding variables
        public string Address
        {
            get => address;
            set
            {
                if (address == value)
                    return;

                address = value;
                OnPropertyChanged();
            }
        }
        public string City
        {
            get => city;
            set
            {
                if (city == value)
                    return;

                city = value;
                OnPropertyChanged();
            }
        }
        public string State
        {
            get => state;
            set
            {
                if (state == value)
                    return;

                state = value;
                OnPropertyChanged();
            }
        }
        public string Zip
        {
            get => zip;
            set
            {
                if (zip == value)
                    return;

                zip = value;
                OnPropertyChanged();
            }
        }

        private async void OnAdminClicked()
        {
            await Shell.Current.GoToAsync(nameof(AdminPage));
        }
        private void OnFindKey()
        {
            Properties propertyToCheck = new Properties();
            propertyToCheck.PropAdd = address;
            propertyToCheck.PropCity = city;
            propertyToCheck.PropState = state;
            propertyToCheck.PropZip = zip;

            //TODO search properties table
        }
    }
}
