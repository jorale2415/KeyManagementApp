using System;
using System.Collections.Generic;
using System.Text;
using KeyManagementApp.Views;
using Xamarin.Forms;

namespace KeyManagementApp.ViewModels
{
    class ForgotPasswordViewModel
    {
        public Command  ChangePasswordCommand { get; }

        public ForgotPasswordViewModel()
        {
            ChangePasswordCommand = new Command(OnChangePasswordClicked);
        }

        private async void OnChangePasswordClicked(object obj)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
        }
    }
}
