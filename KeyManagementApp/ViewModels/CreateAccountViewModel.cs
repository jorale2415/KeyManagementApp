using System;
using System.Collections.Generic;
using System.Text;
using KeyManagementApp.Models;
using KeyManagementApp.Views;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KeyManagementApp.ViewModels
{
     public class CreateAccountViewModel : BindableObject
    {
        public ICommand CreateAccountCommand { get; }

        public CreateAccountViewModel()
        {
        CreateAccountCommand = new Command(OnCreateAccount);
        }
        public string userName = "";
        public string firstName = "";
        public string lastName = "";
        public string password = "";
        public string confirmPass = "";
        public Boolean exists;
       

        public string UserName
        {
            get => userName;
            set
            {
                if (value == userName)
                    return;

                userName = value;
                OnPropertyChanged();
            }
        }
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
        public string Password
        {
            get => password;
            set
            {
                if (value == password)
                    return;

                password = value;
                OnPropertyChanged();
            }
        }
        public string ConfirmPassword
        {
            get => confirmPass;
            set
            {
                if (value == confirmPass)
                    return;

                confirmPass = value;
                OnPropertyChanged();
            }
        }

        public void OnCreateAccount()
        {
            ValidateInput(userName, firstName, lastName, password, confirmPass);
        }
        private async void ValidateInput(string u, string f, string l, string p, string cp)
        {
            // make sure all fields are filled in
            if(!string.IsNullOrEmpty(f) && !string.IsNullOrEmpty(l) && !string.IsNullOrEmpty(p) && !string.IsNullOrEmpty(cp))
            {
                Employee employee = new Employee(); // create new employee
                employee.UserName = u; 
                employee.FName = f;
                employee.LName = l;
                employee.IsPass = p;
                DALEmployee dal = new DALEmployee(); // open DAL connection

                if (p.Equals(cp)) // password and confirmed password match
                {     
                    exists = dal.AddEmployee(employee); // add employee to database

                    if (!exists)
                    {   //employee was added
                        await App.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
                    }
                    else
                    {   // clear fields
                        UserName = "";
                        FirstName = "";
                        LastName = "";
                        Password = "";
                        ConfirmPassword = "";
                    }   
                }         
            }           
        }
    }
}
