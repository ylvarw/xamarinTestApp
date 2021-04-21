using Xamarin.Forms;

using XamarinTestApp.Models;
using XamarinTestApp.ViewModels;

namespace XamarinTestApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}