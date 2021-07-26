using KeyManagementApp.Models;
using KeyManagementApp.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace KeyManagementApp.ViewModels
{
    class AddPropertyViewModel : BindableObject
    {
        public ICommand AddProperty { get; }
        public ICommand RemoveProperty { get; }
        public ObservableRangeCollection<Owner> OwnerList { get; set; }    
        public ObservableRangeCollection<KeyBox> KeyBoxList { get; set; }
        
        public AddPropertyViewModel()
        {
            AddProperty = new Command(OnAddProperty);
            RemoveProperty = new Command(OnRemoveProperty);
            KeyBoxList = new ObservableRangeCollection<KeyBox>();
            OwnerList = new ObservableRangeCollection<Owner>();
            Refresh();      
        }

        // Property variables
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

        // Owner variables
        Owner selectedOwner;
        public string fullName = "";

        // gets and sets owner selected, Owner Picker
        public Owner SelectedOwner 
        { 
            get => selectedOwner;
            set 
            {
                if (value == selectedOwner)
                    return;

                selectedOwner = value;
                OnPropertyChanged();
            } 
        }
        public string FullName
        {
            get => fullName;
            set
            {
                if (value == fullName)
                    return;

                fullName = value;
                OnPropertyChanged();
            }
        }
        public int OwnerID
        {
            get => (int)SelectedOwner.OwnId;
            set
            {
                if (value == SelectedOwner.OwnId)
                    return;

                SelectedOwner.OwnId = value;
                OnPropertyChanged();
            }
        }

        // Key box variables
        KeyBox selectedKeyBox;
        public string boxName = "";
        
        // gets and sets keybox selected, Keybox Picker
        public KeyBox SelectedKeyBox
        {
            get => selectedKeyBox;
            set
            {
                if (value == selectedKeyBox)
                    return;

                selectedKeyBox = value;
                OnPropertyChanged();
            }
        }
        public string BoxName
        {
            get => boxName;
            set
            {
                if (value == boxName)
                    return;

                boxName = value;
                OnPropertyChanged();
            }
        }
        public int KeyBoxID
        {
            get => (int)SelectedKeyBox.KeyBoxId;
            set
            {
                if (value == SelectedKeyBox.KeyBoxId)
                    return;

                SelectedKeyBox.KeyBoxId = value;
                OnPropertyChanged();
            }
        }
        public void OnAddProperty()
        {           
            // make sure all fields are filled out
            if(!string.IsNullOrEmpty(SelectedKeyBox.BoxName) && !string.IsNullOrEmpty(SelectedOwner.FullName) && !string.IsNullOrEmpty(Address)
                && !string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(State) && !string.IsNullOrEmpty(Zip))
            {                
                // create property
                Properties propertyToAdd = new Properties();
                propertyToAdd.OwnerId = OwnerID ;
                propertyToAdd.KeyBoxId = KeyBoxID;
                propertyToAdd.PropAdd = Address;
                propertyToAdd.PropCity = City;
                propertyToAdd.PropState = State;
                propertyToAdd.PropZip = Zip;

                DALProperties dAL = new DALProperties();
                bool exists = dAL.AddProperty(propertyToAdd);

                if (!exists)
                {
                    Application.Current.MainPage.DisplayAlert("Message", "Owner was added successfully", "Ok");
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Message", "Owner already exists", "Ok");
                }              
                ClearFields();
            }
            else
            {
                //message: all fields must be filled out
                Application.Current.MainPage.DisplayAlert("Message", "All fields must be filled out.", "Ok");
                ClearFields();
            }
        }

        private void ClearFields()
        {
            throw new NotImplementedException();
            // clear fields
        }

        public void OnRemoveProperty()
        {

        }
        
        public void Refresh()
        {
            // Updates Owner picker
            DALOwner dal = new DALOwner();
            var ownerList = dal.GetOwners();
            OwnerList.AddRange(ownerList);
            OwnerList.Clear();
            OwnerList.AddRange(ownerList);

            // Update KeyBox Picker
            DALKeyBox keyDal = new DALKeyBox();
            var boxList = keyDal.GetKeyBoxes();
            KeyBoxList.AddRange(boxList);
            KeyBoxList.Clear();
            KeyBoxList.AddRange(boxList);
        }

    }
}
