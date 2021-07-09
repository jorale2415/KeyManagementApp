using KeyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;

namespace KeyManagementApp.Models 
{
    public class DALKeyBox : BaseViewModel 
    {
        public Boolean exists;

        public void AddKeyBox(KeyBox keyboxToAdd)
        {
            Init();
            using (SQLiteConnection db = new SQLiteConnection(_dbPath))
            {
                exists = false;
                foreach(KeyBox kb in db.Table<KeyBox>())
                {
                    if(kb.KeyBoxName == keyboxToAdd.KeyBoxName)
                    {
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {
                    db.Insert(keyboxToAdd);
                    Application.Current.MainPage.DisplayAlert("Message", "You created a new key box.", "Ok");
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Message", "Key box was not created.", "Ok");
                }
                
            } 
        }

        public void RemoveKeyBox(int id)
        {
            Init();
        }
    }
}
