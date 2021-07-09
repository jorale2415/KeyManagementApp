using KeyManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KeyManagementApp.ViewModels
{
    public class AddOwnerViewModel : BindableObject
    {
        public ICommand AddOwnerCommand { get; }

        public AddOwnerViewModel()
        {
            AddOwnerCommand = new Command(OnAddOwner);
        }
        
        //local variables
        public string firstName = "";
        public string lastName = "";
        public Boolean exists;

        //Bindable variables
        public string FirstName
        {
            get => firstName;
            set
            {
                if (value == firstName)
                    return;

                firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                if (value == lastName)
                    return;

                lastName = value;
                OnPropertyChanged();
            }
        }

        public void OnAddOwner()
        {
            // validate fields are not null or empty
            if(!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
            {
                // open db connection
                DALOwner dAL = new DALOwner();
                // create owner object
                Owner ownerToAdd = new Owner();
                ownerToAdd.FName = FirstName;
                ownerToAdd.LName = LastName;
                exists = dAL.AddOwner(ownerToAdd);

                if (!exists)
                {
                    Application.Current.MainPage.DisplayAlert("Message", "Owner was added successfully", "Ok");
                    FirstName = "";
                    LastName = "";
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Message", "Owner already exists", "Ok");
                }
            }
        }
    }
}
