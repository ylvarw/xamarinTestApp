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
    public partial class CpuPage : ContentPage
    {
        public CpuPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            FindPrimeNumber(100000000);
        }
        public long FindPrimeNumber(int n)
        {
            int count = 0;
            long a = 2;
            while (count < n)
            {
                long b = 2;
                int prime = 1;// to check if found a prime
                while (b * b <= a)
                {
                    if (a % b == 0)
                    {
                        prime = 0;
                        break;
                    }
                    b++;
                }
                if (prime > 0)
                {
                    count++;
                }
                a++;
            }
            return (--a);
        }
    }
}