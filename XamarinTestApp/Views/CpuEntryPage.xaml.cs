using System;
using System.IO;
using XamarinTestApp.Models;
using Xamarin.Forms;

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using XamarinTestApp.ViewModels;
using XamarinTestApp.Views;

namespace XamarinTestApp.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class CpuEntryyPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadCpuTest(value);
            }
        }

        public CpuEntryyPage()
        {
            object p = InitializeComponent();

            // Set the BindingContext of the page to a new CpuTest.
            BindingContext = new CpuTest();
        }

        void LoadCpuTest(string filename)
        {
            try
            {
                // Retrieve the CpuTest and set it as the BindingContext of the page.
                CpuTest CpuTest = new CpuTest
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                };
                BindingContext = CpuTest;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load CpuTest.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var CpuTest = (CpuTest)BindingContext;

            if (string.IsNullOrWhiteSpace(CpuTest.Filename))
            {
                // Save the file.
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.CpuTests.txt");
                File.WriteAllText(filename, CpuTest.Text);
            }
            else
            {
                // Update the file.
                File.WriteAllText(CpuTest.Filename, CpuTest.Text);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var CpuTest = (CpuTest)BindingContext;

            // Delete the file.
            if (File.Exists(CpuTest.Filename))
            {
                File.Delete(CpuTest.Filename);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}