using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeyManagementApp.Models;
using KeyManagementApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeyManagementApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountPage : ContentPage
    {
        public CreateAccountPage()
        {
            InitializeComponent();
            this.BindingContext = new CreateAccountViewModel();
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
      
            await App.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
        }
    }
}