using System;
using System.IO;
using Xamarin.Forms;
using XamarinTestApp.Models;



namespace XamarinTestApp.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class RenderEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadRenderTest(value);
            }
        }

        public RenderEntryPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new RenderTest();
        }

        void LoadRenderTest(string filename)
        {
            try
            {
                // Retrieve the RenderTest and set it as the BindingContext of the page.
                RenderTest RenderTest = new RenderTest
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename),
                    Date = File.GetCreationTime(filename)
                };
                BindingContext = RenderTest;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load RenderTest.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var RenderTest = (RenderTest)BindingContext;

            if (string.IsNullOrWhiteSpace(RenderTest.Filename))
            {
                // Save the file.
                var filename = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.RenderTests.txt");
                File.WriteAllText(filename, RenderTest.Text);
            }
            else
            {
                // Update the file.
                File.WriteAllText(RenderTest.Filename, RenderTest.Text);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var RenderTest = (RenderTest)BindingContext;

            // Delete the file.
            if (File.Exists(RenderTest.Filename))
            {
                File.Delete(RenderTest.Filename);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}