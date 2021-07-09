using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using KeyManagementApp.ViewModels;
using SQLite;

namespace KeyManagementApp.Models
{
     public class DALOwner : BaseViewModel
    {
        Boolean exists;

        public bool AddOwner(Owner ownerToAdd)
        {
            Init();
            using (SQLiteConnection db = new SQLiteConnection(_dbPath))
            {
                exists = false;

                // verify owner doesnt already exists
                foreach(Owner o in db.Table<Owner>())
                {
                    if(o.FName == ownerToAdd.FName
                        && o.LName == ownerToAdd.LName)
                    {
                        exists = true;
                        return exists;
                    }
                }

                if (!exists)
                {
                    db.Insert(ownerToAdd);
                }
                return exists;
            }  
        }

        public void RemoveOwner(int id)
        {
            Init();
        }
    }
}
