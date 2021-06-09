using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTestApp.Models;



namespace XamarinTestApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GpuPage : ContentPage
    {
        public GpuPage()
        {
            InitializeComponent();
        }

       
        async void OnButtonClicked(object sender, EventArgs args)
        {
            await label.RelRotateTo(360, 1000);
        }


    }
}