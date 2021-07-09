using System;
using System.Collections.Generic;
using System.Text;
using KeyManagementApp.Models;
using System.IO;
using SQLite;
using KeyManagementApp.ViewModels;

namespace KeyManagementApp.Models
{
    public class DALEmployee : BaseViewModel 
    {
        public Boolean matches;
        public Boolean exists;

        public bool AddEmployee(Employee employeeToAdd)
        {
            Init();
            using (SQLiteConnection db = new SQLiteConnection(_dbPath))
            {
                exists = false;

                // error checking to prevent adding same Employee twice
                foreach (Employee e in db.Table<Employee>())
                {
                    // username is already used
                    if(e.UserName == employeeToAdd.UserName)
                    {
                        exists = true;
                        return exists;                      
                    }      
                }
                // if Employee doesnt exist in the DB, add employee
                if (!exists)
                {   
                    db.Insert(employeeToAdd);          
                }
                return exists;
            }
        }

        public bool LoginEmployee(Employee employeeToLogin)
        {
            Init();
            using (SQLiteConnection db = new SQLiteConnection(_dbPath))
            {
                matches = false;

                foreach(Employee e in db.Table<Employee>())
                {
                    if(e.UserName == employeeToLogin.UserName
                        && e.IsPass == employeeToLogin.IsPass)
                    {
                        matches = true;
                        return matches;
                    }
                }

                return matches;
            }
        }
    }
}
