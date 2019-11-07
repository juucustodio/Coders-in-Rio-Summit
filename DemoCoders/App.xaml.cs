using System;
using DemoCoders.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoCoders
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Session.ApiKey = "2GLXCPibw5RgRK_T7XoAwQ/fsztc4-anEqp5uD23IIVUA";
            MainPage = new Views.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
