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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var GpuTests = new List<GpuTest>();

            // Create a GpuTest object from each file.
            var files = Directory.EnumerateFiles(App.FolderPath, "*.GpuTests.txt");
            foreach (var filename in files)
            {
                GpuTests.Add(new GpuTest
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                });
            }

            // Set the data source for the CollectionView to a
            // sorted collection of GpuTests.
            collectionView.ItemsSource = GpuTests
                .OrderBy(d => d.Date)
                .ToList();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the GpuTestEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(GpuEntryPage));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the GpuTestEntryPage, passing the filename as a query parameter.
                GpuTest GpuTest = (GpuTest)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(GpuEntryPage)}?{nameof(GpuEntryPage.ItemId)}={GpuTest.Filename}");
            }
        }
    }
}