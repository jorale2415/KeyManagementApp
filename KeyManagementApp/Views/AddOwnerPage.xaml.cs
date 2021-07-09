﻿using KeyManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KeyManagementApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOwnerPage : ContentPage
    {
        public AddOwnerPage()
        {
            InitializeComponent();
            this.BindingContext = new AddOwnerViewModel();
        }
    }
}