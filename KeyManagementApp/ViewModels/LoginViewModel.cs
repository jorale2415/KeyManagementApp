using KeyManagementApp.Models;
using KeyManagementApp.Views;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeyManagementApp.ViewModels
{
    public class LoginViewModel : BindableObject
    {        
        public Command LoginNavCommand { get; }
        public Command CreateAccountNavCommand { get; }
        public Command ForgotPasswordNavCommand { get; }
        
        public LoginViewModel()
        {
            LoginNavCommand = new Command(OnLoginClicked);
            CreateAccountNavCommand = new Command(OnCreateAccountClicked);
            ForgotPasswordNavCommand = new Command(OnForgotPasswordClicked);    
        }

        public string userName = "";
        public string password = "";
        public Boolean matches;
        
        public string Username
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

        private async void OnLoginClicked(object obj)
        {
            // only if username and password fields are filled out.
            if(!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(Password))
            {
                //create employee object to check matching account
                Employee employeeToLogin = new Employee();
                employeeToLogin.UserName = userName;
                employeeToLogin.IsPass = password;

                DALEmployee dAL = new DALEmployee();

                matches = dAL.LoginEmployee(employeeToLogin);

                if (matches)
                {
                    Application.Current.MainPage = new AppShell();
                    // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                    await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                }
                else
                {
                    // TODO display a message : you enter the wrong username and password
                    // clear fields
                    Username = "";
                    Password = "";
                }
            }
            else
            {
                Username = "";
                Password = "";
            }                   
        }

        private async void OnCreateAccountClicked(object obj)
        {
            //Application.Current.MainPage = new AppShell();
            await App.Current.MainPage.Navigation.PushModalAsync(new CreateAccountPage());
        }

        private async void OnForgotPasswordClicked(object obj)
        {
            //Application.Current.MainPage = new AppShell();
            await App.Current.MainPage.Navigation.PushModalAsync(new ForgotPasswordPage());
        }
        
    }
}
