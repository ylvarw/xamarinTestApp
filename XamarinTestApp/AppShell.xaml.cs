using System;
using Xamarin.Forms;
using XamarinTestApp.Views;

namespace XamarinTestApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(XamarinTestApp.Views.CpuEntryPage), typeof(XamarinTestApp.Views.CpuEntryPage));
            Routing.RegisterRoute(nameof(XamarinTestApp.Views.GpuEntryPage), typeof(XamarinTestApp.Views.GpuEntryPage));
            Routing.RegisterRoute(nameof(XamarinTestApp.Views.RenderEntryPage), typeof(XamarinTestApp.Views.RenderEntryPage));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
