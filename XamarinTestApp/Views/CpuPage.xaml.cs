using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using XamarinTestApp.Models;
using XamarinTestApp.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTestApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CpuPage : ContentPage
    {
        public CpuPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var CpuTests = new List<CpuTest>();

            // Create a CpuTest object from each file.
            var files = Directory.EnumerateFiles(App.FolderPath, "*.CpuTests.txt");
            foreach (var filename in files)
            {
                CpuTests.Add(new CpuTest
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                });
            }

            // Set the data source for the CollectionView to a
            // sorted collection of CpuTests.
            collectionView.ItemsSource = CpuTests
                .OrderBy(d => d.Date)
                .ToList();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the CpuTestEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(CpuEntryPage));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the CpuTestEntryPage, passing the filename as a query parameter.
                CpuTest CpuTest = (CpuTest)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(CpuEntryPage)}?{nameof(CpuEntryPage.ItemId)}={CpuTest.Filename}");
            }
        }
    }
}