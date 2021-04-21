using System;
using System.IO;
using Xamarin.Forms;
using XamarinTestApp.Models;



namespace XamarinTestApp.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class GpuEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadGpuTest(value);
            }
        }

        public GpuEntryPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new GpuTest();
        }

        void LoadGpuTest(string filename)
        {
            try
            {
                // Retrieve the GpuTest and set it as the BindingContext of the page.
                GpuTest GpuTest = new GpuTest
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                };
                BindingContext = GpuTest;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load GpuTest.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var GpuTest = (GpuTest)BindingContext;

            if (string.IsNullOrWhiteSpace(GpuTest.Filename))
            {
                // Save the file.
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.GpuTests.txt");
                File.WriteAllText(filename, GpuTest.Text);
            }
            else
            {
                // Update the file.
                File.WriteAllText(GpuTest.Filename, GpuTest.Text);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var GpuTest = (GpuTest)BindingContext;

            // Delete the file.
            if (File.Exists(GpuTest.Filename))
            {
                File.Delete(GpuTest.Filename);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}