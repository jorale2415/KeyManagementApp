using KeyManagementApp.ViewModels;
using KeyManagementApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace KeyManagementApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AdminPage), typeof(AdminPage));
            Routing.RegisterRoute(nameof(AddOwnerPage), typeof(AddOwnerPage));
            Routing.RegisterRoute(nameof(AddPropertyPage), typeof(AddPropertyPage));
            Routing.RegisterRoute(nameof(AddKeyBoxPage), typeof(AddKeyBoxPage));
        }

    }
}
