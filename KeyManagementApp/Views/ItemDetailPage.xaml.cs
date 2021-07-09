using KeyManagementApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace KeyManagementApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}