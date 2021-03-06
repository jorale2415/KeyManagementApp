using KeyManagementApp.Services;
using KeyManagementApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeyManagementApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new NavigationPage(new LoginPage());
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
