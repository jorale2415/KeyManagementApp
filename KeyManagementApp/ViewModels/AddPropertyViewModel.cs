using KeyManagementApp.Models;
using KeyManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KeyManagementApp.ViewModels
{
    class AddPropertyViewModel : BindableObject
    {
        public ICommand AddProperty { get; }

        public AddPropertyViewModel()
        {
            AddProperty = new Command(OnAddProperty);
        }

        public string address = "";
        public string city = "";
        public string state = "";
        public string zip = "";

        public string Address 
        { 
            get => address;
            set
            {
                if (value == address)
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
                if (value == city)
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
                if (value == state)
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
                if (value == zip)
                    return;

                zip = value;
                OnPropertyChanged();
            }
        }

        public void OnAddProperty()
        {
            // make sure all fields are filled out
            // create property
            // add variables to property
            // open connection to db
            // pass object to db
        }
    }
}
