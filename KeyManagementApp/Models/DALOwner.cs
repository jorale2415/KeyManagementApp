using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using KeyManagementApp.ViewModels;
using SQLite;

namespace KeyManagementApp.Models
{
    public class DALOwner : BaseViewModel
    {
   
        Boolean exists;

        public DALOwner()
        {      
        }

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

        public IEnumerable<Owner> GetOwners()
        {
           Init();
           using(SQLiteConnection db = new SQLiteConnection(_dbPath))
            {                
                var ownerList = db.Table<Owner>().ToList();
                return ownerList;
            }
        }


        public bool RemoveOwner(Owner ownerToDelete)
        {
            Init();
            using (SQLiteConnection db = new SQLiteConnection(_dbPath))
            {
                exists = false;

                // verify owner exists
                foreach (Owner o in db.Table<Owner>())
                {
                    if (o.FName == ownerToDelete.FName
                        && o.LName == ownerToDelete.LName)
                    {
                        ownerToDelete.OwnId = o.OwnId;
                        // TODO update database primary keys
                        exists = true;
                        //return exists;
                    }
                }

                if (exists)
                {
                    db.Delete(ownerToDelete);
                }
                return exists;
            }
        }
     
    }
}
