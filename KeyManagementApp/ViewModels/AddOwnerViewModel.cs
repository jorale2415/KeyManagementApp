using KeyManagementApp.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace KeyManagementApp.ViewModels
{
    public class AddOwnerViewModel : BindableObject
    {
        public ICommand AddOwnerCommand { get; }
        public ICommand DeleteOwnerCommand { get; }
        public ObservableRangeCollection<Owner> OwnerList { get; set; }

        public AddOwnerViewModel()
        {
            AddOwnerCommand = new Command(OnAddOwner);
            DeleteOwnerCommand = new Command(OnDeleteOwner);
            OwnerList = new ObservableRangeCollection<Owner>();

            Refresh();

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
                    Refresh();
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Message", "Owner already exists", "Ok");
                }
            }
        }

        public void OnDeleteOwner()
        {
            // validate fields are not null or empty
            if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
            {
                // open db connection
                DALOwner dAL = new DALOwner();
                // create owner object
                Owner ownerToDelete = new Owner();
                ownerToDelete.FName = FirstName;
                ownerToDelete.LName = LastName;
                exists = dAL.RemoveOwner(ownerToDelete);

                if (exists)
                {
                    Application.Current.MainPage.DisplayAlert("Message", "Owner was removed successfully", "Ok");
                    FirstName = "";
                    LastName = "";                   
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Message", "Owner doesn't exists", "Ok");
                    FirstName = "";
                    LastName = "";
                }
            }
            Refresh();
        }
        public void Refresh()
        {
            DALOwner dal = new DALOwner();
            var ownerList = dal.GetOwners();
            OwnerList.AddRange(ownerList);

            OwnerList.Clear();
            OwnerList.AddRange(ownerList);
        }
    }
}
