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
    public partial class RenderPage : ContentPage
    {
        public RenderPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var RenderTests = new List<RenderTest>();

            // Create a RenderTest object from each file.
            var files = Directory.EnumerateFiles(App.FolderPath, "*.RenderTests.txt");
            foreach (var filename in files)
            {
                RenderTests.Add(new RenderTest
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                });
            }

            // Set the data source for the CollectionView to a
            // sorted collection of RenderTests.
            collectionView.ItemsSource = RenderTests
                .OrderBy(d => d.Date)
                .ToList();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the RenderTestEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(RenderEntryPage));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the RenderTestEntryPage, passing the filename as a query parameter.
                RenderTest RenderTest = (RenderTest)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(RenderEntryPage)}?{nameof(RenderEntryPage.ItemId)}={RenderTest.Filename}");
            }
        }
    }
}