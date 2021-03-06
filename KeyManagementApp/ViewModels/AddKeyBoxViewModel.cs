using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using KeyManagementApp.Views;
using KeyManagementApp.Models;
using MvvmHelpers;

namespace KeyManagementApp.ViewModels
{
    class AddKeyBoxViewModel : BindableObject
    {
        public Command AddKeyBox { get; }
        public Command RemoveKeyBox { get; }
        public ObservableRangeCollection<KeyBox> KeyBoxList {get; set;}

        public AddKeyBoxViewModel()
        {
            AddKeyBox = new Command(OnAddKeyBox);
            RemoveKeyBox = new Command(OnRemoveKeyBox);
            KeyBoxList = new ObservableRangeCollection<KeyBox>();

            // refresh observable range collection
            Refresh();
        }
        public string name = "";
        public string location = "";
        public int slots = 0;

        public string Name
        {
            get => name;
            set
            {
                if (value == name)
                    return;

                name = value;
                OnPropertyChanged();
            }
        }
        public string Location
        {
            get => location;
            set
            {
                if (value == location)
                    return;

                location = value;
                OnPropertyChanged();
            }
        }
        public int Slots
        {
            get => slots;
            set
            {
                if (value == slots)
                    return;

                slots = value;
                OnPropertyChanged();
            }
        }
        
        private void ClearFields()
        {
            Name = "";
            Location = "";
            Slots = 0;
        }

        private void OnAddKeyBox()
        {
            //  convert slots to string to validate the field is not empty or null
            string slotString = Slots.ToString();

            // validate all fields are filled in and not null
           if(!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Location) && !string.IsNullOrEmpty(slotString))
            {
                KeyBox newKeyBox = new KeyBox();
                Slots numOfSlots = new Slots();
                newKeyBox.KeyBoxName = Name;
                newKeyBox.KeyBoxLocation = Location;
                //newKeyBox.KeyBoxSize = slotString;
                newKeyBox.KeyBoxSize = numOfSlots.SlotNum = Slots;

                // connect to db
                DALKeyBox dAL = new DALKeyBox();
                // pass object to database
                dAL.AddKeyBox(newKeyBox);
                ClearFields();
                Refresh();
            }
            else
            {
                //message: all fields must be filled out
                Application.Current.MainPage.DisplayAlert("Message", "All fields must be filled out.", "Ok");
                ClearFields();
            }
        }

        private void OnRemoveKeyBox()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                
                DALKeyBox dAL = new DALKeyBox();
                bool exists = dAL.RemoveKeyBox(Name);

                if (exists)
                {
                    Application.Current.MainPage.DisplayAlert("Message", "Key box was removed successfully", "Ok");
                    Refresh();
                    ClearFields();
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Message", "Key box doesn't exists", "Ok");                 
                }

            }
        }

        public void Refresh()
        {
            DALKeyBox dal = new DALKeyBox();
            var keyBoxList = dal.GetKeyBoxes();
            KeyBoxList.AddRange(keyBoxList);

            KeyBoxList.Clear();
            KeyBoxList.AddRange(keyBoxList);
        }
    }
}
