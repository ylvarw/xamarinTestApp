using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTestApp.Models;



namespace XamarinTestApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GpuPage : ContentPage
    {
        int Counter = 0;
        public GpuPage()
        {
            InitializeComponent();
        }

       
        void OnButtonClicked(object sender, EventArgs args)
        {
            kill();
        }
        void kill()
        {
            while (true)
                ThreadPool.QueueUserWorkItem(fill);
        }

        void fill(Object o)
        {

            List<Object> list = new List<Object>();

            while (true)
            {
                Console.WriteLine(Counter);
                Counter++;
                list.Add(new Object());
            }
        }

    }
}