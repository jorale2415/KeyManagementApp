using KeyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SQLite;

namespace KeyManagementApp.Models
{
    public class DALProperties : BaseViewModel
    {
        public bool AddProperty(Properties propertyToAdd)
        {
            Init();
            using (SQLiteConnection db = new SQLiteConnection(_dbPath))
            {
                bool exists = false;
                foreach (Properties p in db.Table<Properties>())
                {
                    if(p.PropAdd == propertyToAdd.PropAdd && p.PropCity == propertyToAdd.PropCity 
                        && p.PropState == propertyToAdd.PropState && p.PropZip == propertyToAdd.PropZip)
                    {
                        // property exists
                        exists = true;
                        break;
                    }
                }
                if (!exists)
                {                   
                    db.Insert(propertyToAdd);
                }
                return exists;
            }
        }
        public void RemoveProperty(Properties propertyToRemove)
        {

        }
    }
}
