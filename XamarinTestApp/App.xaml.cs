using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTestApp.Services;
using XamarinTestApp.Views;

namespace XamarinTestApp
{
    public partial class App : Application
    {

        public static string FolderPath { get; private set; }

        public App()
        {
            InitializeComponent();
            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            MainPage = new AppShell();
        }
        //public App()
        //{
        //  InitializeComponent();

        //DependencyService.Register<MockDataStore>();
        //MainPage = new AppShell();
        //}

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
