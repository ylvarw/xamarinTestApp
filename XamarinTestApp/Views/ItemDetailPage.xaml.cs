using System.ComponentModel;
using Xamarin.Forms;
using XamarinTestApp.ViewModels;

namespace XamarinTestApp.Views
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