using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTestApp.Models;
using System.Diagnostics;

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

        void OnButtonClickedfirst(object sender, EventArgs args)
        {
            RunTestsNumberOTimes(10000);
        }


        void OnButtonClickedsecond(object sender, EventArgs args)
        {
            RunTestsNumberOTimes(50000);
        }

        void OnButtonClickedthird(object sender, EventArgs args)
        {
            RunTestsNumberOTimes(100000);
        }
        void OnButtonClickedfourth(object sender, EventArgs args)
        {
            RunTestsNumberOTimes(150000);
        }

        void RunTestsNumberOTimes(int numberOfNumbersToSearchForPrimes)
        {
            var numberOfTimesToTest = 100;
            var TimeList = new List<double>();
            for (int i = 0; i < numberOfTimesToTest; i++)
            {
                Console.WriteLine("Count: {}" + i);
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                FindPrimeNumber(numberOfNumbersToSearchForPrimes);
                stopwatch.Stop();
                var timeSpan = stopwatch.Elapsed;
                TimeList.Add(timeSpan.TotalMilliseconds);
            }

            double totalTime = 0.0;
            double longestTime = double.NegativeInfinity;
            double shortestTime = double.PositiveInfinity;
            foreach (var time in TimeList)
            {
                totalTime += time;
                if (time < shortestTime)
                    shortestTime = time;
                if (time > longestTime)
                    longestTime = time;
            }
            var meanTime = totalTime / (double)numberOfTimesToTest;
            Console.WriteLine("TestTimes Avg: {0} Longest: {1} shortest: {2}", meanTime, longestTime, shortestTime);
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