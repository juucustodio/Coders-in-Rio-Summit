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

            Session.ApiKey = "SUA API KEY";

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
